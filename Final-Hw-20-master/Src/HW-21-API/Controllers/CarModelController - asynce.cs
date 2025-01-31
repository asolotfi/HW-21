using HW_20.Domain.Contract.Repositoris;
using HW_20.Domain.Contract.Service;
using HW_20.Domain.Entites.Car;
using HW_20.Infrastructure.DB;
using Microsoft.AspNetCore.Mvc;

namespace HW_21_API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CarModelController1 : ControllerBase
    {
        private readonly AppDbContext _appDbcontext;
        private readonly ICarModelSevice _carModelSevice;
        private readonly ICarModelAppSevice _carModelAppSevice;

        public CarModelController1(AppDbContext appDbContext, ICarModelSevice carModelSevice, ICarModelAppSevice carModelAppSevice)
        {
            _appDbcontext = appDbContext;
            _carModelSevice = carModelSevice;
            _carModelAppSevice = carModelAppSevice;
        }

        //[HttpGet("List")]
        //public async Task<List<CarModel>> CarModel()
        //{
        //    List<CarModel> carModels =await  _appDbcontext.CarModels();
        //    return carModels; 
        //}
        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    var result = _CarModelSevice.GetCarModel(id);
        //    if (result == null)
        //    {
        //        return NotFound("مدل وجود ندارد.");
        //    }
        //    return Ok(result);
        //}

        //[HttpPost("Get-details")]
        //public CarModel EditCarModel(int id, string name)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest("لطفاً داده‌ها را به صورت صحیح وارد کنید.");
        //    }

        //    CarModel carModel = _CarModelAppSevice.EditCarModel(id, name);
        //    if (!result)
        //    {
        //        return BadRequest("ویرایش ناموفق بود.");
        //    }
        //    return carModel;
        //}

        //[HttpPost]
        //public IActionResult DeletCarModel(int id)
        //{
        //    try
        //    {
        //        var result = _CarModelAppSevice.DeleteCarModel(id);
        //        if (result == null)
        //        {
        //            return BadRequest("مدل پیدا نشد");
        //        }
        //        return Ok("مدل تأیید شد.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest("خطایی در تأیید مدل رخ داد");
        //    }
        //}
        //[HttpPost("add-product")]
        //public int AddCarModele(string name)
        //{
        //    var cardModel = new CarModel
        //    {
        //        Name = name,
        //    };
        //    if (!ModelState.IsValid)
        //    {
        //        //return res("لطفاً داده‌ها را به صورت صحیح وارد کنید");
        //    }
        //    var result = _CarModelAppSevice.AddCarModel(name);
        //    return result;
    }
}


