using HW_20.Domain.Entites.Car;
using Microsoft.AspNetCore.Mvc;

namespace HW_20.Domain.Contract.Repositoris
{
    public class CarModelSevice : ICarModelSevice
    {
        private readonly ICarModelRepository _CarModelRepository;

        public CarModelSevice(ICarModelRepository CarModelRepository)
        {
            _CarModelRepository = CarModelRepository;
        }
        public Task<int> AddCarModelAsync(string name)
        {
          var result= _CarModelRepository.AddCarModelAsync(name);
            return result;
        }

        public Task<bool> DeleteCarModelAsync(int id)
        {
          var result=  _CarModelRepository.DeleteCarModelAsync(id);
            return result;
        }

        public Task<IActionResult> EditCarModel(int id, string name)
        {
          var result=  _CarModelRepository.EditCarModel(id, name);
            return result;
        }

        public CarModel GetCarModel(int id)
        {
            var result= _CarModelRepository.GetCarModelAsync(id);
            return result.Result;
        }
    }
}
