using HW_20.Domain.Contract.Repositoris;
using HW_20.Domain.Contract.Service;
using HW_20.Domain.Entites.Car;
using HW_20.Domain.Enum;
using HW_20.Infrastructure.DB;
using Microsoft.AspNetCore.Mvc;

namespace Find_HW_20.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarModelController : Controller
    {

        private readonly ICarModelSevice _CarModelSevice;
        private readonly AppDbContext _appDbContext;

        public CarModelController(ICarModelSevice CarModelSevice, AppDbContext appDbContext)
        {
            _CarModelSevice = CarModelSevice;
            _appDbContext = appDbContext;
        }
        [HttpGet]
        public IActionResult CarModel()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Get()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddCarModel()
        {
            return View();
        }
        public IActionResult EditCarModel()
        {
            return View();
        }
        public IActionResult DeleteCarModel()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCarModel(string name)
        {
            var cardModel = new CarModel
            {
                Name = name,
            };
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "لطفاً داده‌ها را به صورت صحیح وارد کنید.";
                return View("Index", cardModel);
            }

            TempData["SuccessMessage"] = "مدل ثبت شد.";
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DeleteCarModel(int id)
        {
            try
            {
                var request = _appDbContext.InspectionRequests.Find(id);
                if (request == null)
                {
                    TempData["ErrorMessage"] = "مدل پیدا نشد.";
                    return RedirectToAction("Index");
                }

                request.Status = RequestStatusEnum.Approved;
                _appDbContext.SaveChanges();
                TempData["SuccessMessage"] = "مدل تأیید شد.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطایی در تأیید مدل رخ داد.";
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult EditeCarModel(int id, string name)
        {
            var model = _appDbContext.CarModels.Find(id);
            if (model == null)
            {
                TempData["ErrorMessage"] = "مدل مورد نظر پیدا نشد.";
                return RedirectToAction("CarModel");
            }

            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "لطفاً داده‌ها را به صورت صحیح وارد کنید.";
                return View("Index", model);
            }

            var result = _CarModelSevice.EditCarModel(id, name);
            if (result)
            {
                TempData["SuccessMessage"] = "عملیات ویرایش با موفقیت انجام شد.";
                return RedirectToAction("CarModel");
            }
            else
            {
                TempData["ErrorMessage"] = "ویرایش ناموفق بود.";
                return View("CarModel");
            }
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = _CarModelSevice.GetCarModel(id);
            if (result == null)
            {
                TempData["ErrorMessage"] = "مدل وجود ندارد.";
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
