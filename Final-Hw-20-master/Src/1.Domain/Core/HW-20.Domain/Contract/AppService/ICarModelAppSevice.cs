using HW_20.Domain.Entites.Car;

namespace HW_20.Domain.Contract.Service
{
    public interface ICarModelAppSevice
    {
        int AddCarModel(string name);
        bool DeleteCarModel(int id);
        bool EditCarModel(int id,string name);
        CarModel GetCarModel(int id);
    }
}

