using HW_20.Domain.Contract.Repositoris;
using HW_20.Domain.Contract.Sevice;
using HW_20.Domain.Entites.Car;
using HW_20.Domain.Enum;
using HW_20.Domain.Models;
using HW_20.Infrastructure.DB;
using Microsoft.Extensions.Options;

namespace HW_20.Service.Service
{
    public class InspectionRequestService : IInspectionRequestService
    {
        private readonly IInspectionRequestRepository _InspectionRequestRepository;
        private readonly AppDbContext _context;
        private readonly AppSettings _appSettings;

        public InspectionRequestService(
            IInspectionRequestRepository InspectionRequestRepository, IOptions<AppSettings> appSettings, AppDbContext context)
        {
            //رفع خطای nullable
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _InspectionRequestRepository = InspectionRequestRepository;
            _appSettings = appSettings.Value;
        }

        public bool AddInspectionRequest(string PhoneNumber, string codeMeli, string PlateNumber, string Car, string company, DateTime ProductionDate)
        {

            DateTime requestDate = DateTime.Now;

            int capacity = IsEvenDay(requestDate) ? _appSettings.EvenDayCapacity : _appSettings.OddDayCapacity;

            // بررسی تعداد درخواست‌های ثبت‌شده در روز جاری برای شرکت مشخص
            var existingRequestsCount = _context.InspectionRequests
                .Where(r => r.RequestDate.Date == requestDate.Date && r.Company == company)
            .Count();
            // بررسی اینکه آیا خودرو با همان شماره پلاک در سال جاری درخواست داده است
            bool alreadyRequested = _context.InspectionRequests
                .Any(r => r.PlateNumber == PlateNumber &&
                          r.RequestDate.Year == DateTime.Now.Year); // مقایسه سال درخواست

            if (existingRequestsCount >= capacity || alreadyRequested)
            {
                // اگر درخواست قبلا ثبت شده باشد، اجازه ثبت جدید را نمی‌دهیم
                // ظرفیت پر است
                return false;
            }
            else if (!IsCarOlderThanFiveYears(ProductionDate))
            {
                // ذخیره درخواست در جدول جداگانه
                _InspectionRequestRepository.AddOldCarRequest(PhoneNumber, codeMeli, PlateNumber, Car, company, ProductionDate);
                return false; // نمی‌پذیرد
            }
            // اگر ظرفیت پر نشده باشد، درخواست جدید اضافه می‌شود
            var resultF = _InspectionRequestRepository.AddInspectionRequest(PhoneNumber, codeMeli, PlateNumber, Car, company, ProductionDate);
            return resultF;
        }
        private bool IsEvenDay(DateTime date)
        {
            // بررسی روز زوج بودن
            return date.DayOfYear % 2 == 0;
        }
        private bool IsCarOlderThanFiveYears(DateTime ProductionDate)
        {
            var result = DateTime.Now.Year - ProductionDate.Year;
            return result > 5;
        }
        public bool AddOldCarRequest(string PhoneNumber, string codeMeli, string PlateNumber, string Car, string company, DateTime ProductionDate)
        {
            _InspectionRequestRepository.AddOldCarRequest(PhoneNumber, codeMeli, PlateNumber, Car, company, ProductionDate);
            _context.SaveChanges();
            return true;
        }
        public List<InspectionRequest> Get(RequestStatusEnum status)
        {
            return _InspectionRequestRepository.Get(status);
        }
    }
}