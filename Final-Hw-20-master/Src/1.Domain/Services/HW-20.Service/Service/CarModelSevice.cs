using HW_20.Domain.Entites.Car;

namespace HW_20.Domain.Contract.Repositoris
{
    public class CarModelSevice : ICarModelSevice
    {
        private readonly ICarModelRepository _CarModelRepository;

        public CarModelSevice(ICarModelRepository CarModelRepository)
        {
            _CarModelRepository = CarModelRepository;
        }
        public int AddCarModel(string name)
        {
          var result= _CarModelRepository.AddCarModel(name);
            return result;
        }

        public bool DeleteCarModel(int id)
        {
            _CarModelRepository.DeleteCarModel(id);
            return true;
        }

        public bool EditCarModel(int id, string name)
        {
            _CarModelRepository.EditCarModel(id, name);
            return true;
        }

        public CarModel GetCarModel(int id)
        {
            return _CarModelRepository.GetCarModel(id);
        }
    }
}
