using HW_20.Domain.Contract.Repositoris;
using HW_20.Domain.Contract.Service;
using HW_20.Domain.Entites.Car;
using HW_20.Infrastructure.DB;
using Microsoft.AspNetCore.Mvc;

namespace HW_21_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarModelController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly ICarModelSevice _CarModelSevice;
        private readonly ICarModelAppSevice _CarModelAppSevice;
        public CarModelController(AppDbContext appDbContext, ICarModelSevice CarModelSevice, ICarModelAppSevice CarModelAppSevice)
        {
            _appDbContext = appDbContext;
            _CarModelSevice = CarModelSevice;
            _CarModelAppSevice = CarModelAppSevice;

        }
   
        [HttpGet]
        public IActionResult CarModel()
        {
            var requests = _appDbContext.CarModels.ToList();
            return Ok(requests); 
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _CarModelSevice.GetCarModel(id);
            if (result == null)
            {
                return NotFound("مدل وجود ندارد.");
            }
            return Ok(result);
        }

        [HttpPost("Edit")]
        public IActionResult EditCarModel(int id, string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("لطفاً داده‌ها را به صورت صحیح وارد کنید.");
            }

            var result = _CarModelAppSevice.EditCarModel(id, name);
            if (!result)
            {
                return BadRequest("ویرایش ناموفق بود.");
            }
            return Ok("ویرایش موفق بود.");
        }

        [HttpPost("Delete")]
        public IActionResult DeletCarModel(int id)
        {
            try
            {
                var result = _CarModelAppSevice.DeleteCarModel(id);
                if (!result)
                {
                    return NotFound("مدل پیدا نشد");
                }
                return Ok("مدل تأیید شد.");
            }
            catch (Exception ex)
            {
                return BadRequest("خطایی در تأیید مدل رخ داد");
            }
        }
        [HttpPost("Add")]
        public IActionResult AddCarModele(string name)
        {
            var cardModel = new CarModel
            {
                Name = name,
            };
            if (!ModelState.IsValid)
            {
                return BadRequest("لطفاً داده‌ها را به صورت صحیح وارد کنید");
            }
            var result = _CarModelAppSevice.AddCarModel(name);
            return Ok("مدل ثبت شد.");
        }
    }
}
