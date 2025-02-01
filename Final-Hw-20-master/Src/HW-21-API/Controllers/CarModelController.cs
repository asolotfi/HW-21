using HW_20.Domain.Contract.Repositoris;
using HW_20.Domain.Contract.Service;
using HW_20.Domain.Entites.Car;
using HW_20.Infrastructure.DB;
using HW_21_API.Middelware;
using Microsoft.AspNetCore.Mvc;

namespace HW_21_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarModelController : ControllerBase
    {
        private readonly AppDbContext _appDbcontext;
        private readonly ICarModelSevice _carModelSevice;
        private readonly ICarModelAppSevice _carModelAppSevice;

        public CarModelController(AppDbContext appDbContext, ICarModelSevice carModelSevice, ICarModelAppSevice carModelAppSevice)
        {
            _appDbcontext = appDbContext;
            _carModelSevice = carModelSevice;
            _carModelAppSevice = carModelAppSevice;
        }
        [HttpGet("List")]
        public async Task<List<CarModel>> CarModel()
        {
            List<CarModel> carModels = _appDbcontext.CarModels.ToList();
            return carModels;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _carModelSevice.GetCarModel(id);
            if (result == null)
            {
                return NotFound("مدل وجود ندارد.");
            }
            return Ok(result);
        }

        [HttpPost("edit")]
        public async Task<IActionResult> EditCarModel(int id, string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("لطفاً داده‌ها را به صورت صحیح وارد کنید.");
            }

            var result = await _carModelAppSevice.EditCarModel(id, name); 
            if (result==null)
            {
                return BadRequest("ویرایش ناموفق بود.");
            }
            return Ok("ویرایش با موفقیت انجام شد.");
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeletCarModel(int id)
        {
            try
            {
                var result = await _carModelAppSevice.DeleteCarModelAsync(id);
                if (!result)
                {
                    return BadRequest("مدل پیدا نشد");
                }
                return Ok("مدل تأیید شد.");
            }
            catch (Exception ex)
            {
                // لاگ کردن خطا
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                return BadRequest("خطایی در تأیید مدل رخ داد");
            }
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddCarModelAsync(string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("لطفاً داده‌ها را به صورت صحیح وارد کنید");
            }
            var result = await _carModelAppSevice.AddCarModelAsync(name); // استفاده از متد Asynchronous
            if (result == 0)
            {
                return BadRequest("مدل قبلاً وجود دارد.");
            }
            return Ok("مدل با موفقیت اضافه شد.");
        }
    }
}
