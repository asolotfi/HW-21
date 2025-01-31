using HW_20.Domain.Contract.Sevice;
using HW_20.Domain.Entites.Car;
using HW_20.Domain.Enum;
using HW_20.Infrastructure.DB;
using Microsoft.AspNetCore.Mvc;

namespace Find_HW_20.Controllers
{

    public class InspectionController : Controller
    {

        private readonly IInspectionRequestService _InspectionRequestService;
        private readonly AppDbContext _appDbContext;

        public InspectionController(IInspectionRequestService InspectionRequestService, AppDbContext appDbContext)
        {
            _InspectionRequestService = InspectionRequestService;
            _appDbContext = appDbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Show()
        {
            return View();
        }
        [HttpGet]
        public IActionResult createInspection(string PhoneNumber, string codeMeli, string PlateNumber, string Car,  string company, DateTime ProductionDate)
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateInspectionRequest(string PhoneNumber, string codeMeli, string PlateNumber, string Car, string company ,DateTime ProductionDate)
        {
            var InspectionRequestq = new InspectionRequest
            {
                PhoneNumber = PhoneNumber,
                CodeMeli = codeMeli,
                PlateNumber = PlateNumber,
                Car = Car,
                Company = company,
                ProductionDate = ProductionDate
            };
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "لطفاً داده‌ها را به صورت صحیح وارد کنید.";
                return View("Index", InspectionRequestq);
            }

            else if (!_InspectionRequestService.AddInspectionRequest(PhoneNumber, codeMeli, PlateNumber, Car, company, ProductionDate))
            {
                TempData["ErrorMessage"] = "درخواست معاینه ثبت نشد.";
                return RedirectToAction("Index");
            }

            TempData["SuccessMessage"] = "درخواست معاینه فنی ثبت شد.";
            return RedirectToAction("Index");
        }
        // متد تأیید درخواست
        [HttpPost]
        public IActionResult Approve(int id)
        {
            try
            {
                var request = _appDbContext.InspectionRequests.Find(id);
                if (request == null)
                {
                    TempData["ErrorMessage"] = "درخواست معاینه پیدا نشد.";
                    return RedirectToAction("Index");
                }

                request.Status = RequestStatusEnum.Approved;
                _appDbContext.SaveChanges();
                TempData["SuccessMessage"] = "درخواست معاینه تأیید شد.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطایی در تأیید درخواست رخ داد.";
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Reject(int id)
        {
            try
            {
                var request = _appDbContext.InspectionRequests.Find(id);
                if (request != null)
                {
                    request.Status = RequestStatusEnum.Rejected;
                    _appDbContext.SaveChanges();
                    TempData["SuccessMessage"] = "درخواست معاینه رد شد.";
                }
                else
                {
                    TempData["ErrorMessage"] = "درخواست معاینه پیدا نشد.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطایی در رد درخواست رخ داد.";
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Get(RequestStatusEnum status)
        {
            var result = _InspectionRequestService.Get(status);
            if (result == null)
            {
                TempData["ErrorMessage"] = "درخواستی وجود ندارد.";
                return RedirectToAction("Show");
            }
            else
                return View(result);
        }


        public IActionResult Success()
        {
            return View();
        }

    }
}




