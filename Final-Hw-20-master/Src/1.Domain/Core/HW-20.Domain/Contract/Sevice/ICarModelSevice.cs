using HW_20.Domain.Entites.Car;

namespace HW_20.Domain.Contract.Repositoris
{
    public interface ICarModelSevice
    {
        int AddCarModel(string name);
        bool DeleteCarModel(int id);
        bool EditCarModel(int id, string name);
        CarModel GetCarModel(int id);
    }
}
