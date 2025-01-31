using HW_20.Domain.Contract.Repositoris;
using HW_20.Domain.Entites.Car;
using HW_20.Domain.Enum;
using HW_20.Infrastructure.DB;

namespace HW_20.Infrastructure.Repositoris
{
    public class InspectionRequestRepository : IInspectionRequestRepository
    {
        private readonly AppDbContext _appDbContext;

        public InspectionRequestRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public bool AddInspectionRequest(string PhoneNumber, string codeMeli, string PlateNumber, string Car, string company, DateTime ProductionDate)
        {
            try
            {
                if (PhoneNumber == null || codeMeli.Length != 10 || PlateNumber == null || Car == null)
                {
                    return false;
                }

                var InspectionRequest = new InspectionRequest
                {
                    PhoneNumber = PhoneNumber,
                    CodeMeli = codeMeli,
                    PlateNumber = PlateNumber,
                    Car = Car,
                    RequestDate = DateTime.Now,
                    Status = RequestStatusEnum.Pending,
                    Company = company

                };

                _appDbContext.Add(InspectionRequest);
                _appDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new ApplicationException("خطا در زمان ثبت درخواست", ex);
            }
        }

        public bool AddOldCarRequest(string PhoneNumber, string codeMeli, string PlateNumber, string Car, string company, DateTime ProductionDate)
        {
            try
            {
                if (PhoneNumber == null || codeMeli.Length != 10 || PlateNumber == null || Car == null)
                {
                    return false;
                }

                var InspectionRequest = new InspectionRequest
                {
                    PhoneNumber = PhoneNumber,
                    CodeMeli = codeMeli,
                    PlateNumber = PlateNumber,
                    Car = Car,
                    RequestDate = DateTime.Now,
                    Status = RequestStatusEnum.Pending,
                    Company = company
                };

                _appDbContext.Add(InspectionRequest);
                _appDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new ApplicationException("خطا در زمان ثبت درخواست", ex);
            }
        }

        public List<InspectionRequest> Get(RequestStatusEnum status)
        {

            return _appDbContext.InspectionRequests
        .Where(r => r.Status == RequestStatusEnum.Pending) 
        .AsEnumerable() // اضافه کردن AsEnumerable در اینجا برای اجرای کوئری در حافظه
        .GroupBy(r => r.RequestDate.Date)
        .OrderBy(g => g.Key)
        .SelectMany(group => group) // مسطح کردن لیست‌ها
        .ToList();

        }
        public InspectionRequest GetInspectionRequest(int id, RequestStatusEnum status)
        {
            var result = _appDbContext.InspectionRequests.FirstOrDefault(x => x.Id == id);

            if (result != null && result.Status == RequestStatusEnum.Approved)
            {
                return result;
            }
            return null;
        }


    }




}

