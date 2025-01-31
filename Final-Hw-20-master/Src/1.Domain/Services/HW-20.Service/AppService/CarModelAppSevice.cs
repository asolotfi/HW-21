using HW_20.Domain.Contract.Service;
using HW_20.Domain.Entites.Car;

namespace HW_20.Domain.Contract.Repositoris
{
    public class CarModelAppSevice : ICarModelAppSevice
    {
        private readonly ICarModelSevice _CarModelSevice;

        public CarModelAppSevice(ICarModelSevice CarModelSevice)
        {
            _CarModelSevice = CarModelSevice;
        }
        public int AddCarModel(string name)
        {
          var result=  _CarModelSevice.AddCarModel(name);
            return result;
        }

        public bool DeleteCarModel(int id)
        {
            _CarModelSevice.DeleteCarModel(id);
            return true;
        }

        public bool EditCarModel(int id, string name)
        {
            _CarModelSevice.EditCarModel(id, name);
            return true;
        }

        public CarModel GetCarModel(int id)
        {
            return _CarModelSevice.GetCarModel(id);
        }
    }
}
