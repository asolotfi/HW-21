using HW_20.Domain.Contract.Service;
using HW_20.Domain.Entites.Car;
using Microsoft.AspNetCore.Mvc;

namespace HW_20.Domain.Contract.Repositoris
{
    public class CarModelAppSevice : ICarModelAppSevice
    {
        private readonly ICarModelSevice _CarModelSevice;

        public CarModelAppSevice(ICarModelSevice CarModelSevice)
        {
            _CarModelSevice = CarModelSevice;
        }
       public Task<int> AddCarModelAsync(string name)
        {
          var result=  _CarModelSevice.AddCarModelAsync(name);
            return result;
        }

        public Task<bool> DeleteCarModelAsync(int id)
        {
          var result=  _CarModelSevice.DeleteCarModelAsync(id);
            return result;
        }

        public Task<IActionResult> EditCarModel(int id, string name)
        {
           var result= _CarModelSevice.EditCarModel(id, name);
            return result;
        }

        public CarModel GetCarModel(int id)
        {
            return _CarModelSevice.GetCarModel(id);
        }
    }
}
