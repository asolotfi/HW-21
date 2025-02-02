using HW_20.Domain.Entites.Car;
using Microsoft.AspNetCore.Mvc;

namespace HW_20.Domain.Contract.Repositoris
{
    public interface ICarModelSevice
    {
        Task<int> AddCarModelAsync(string name);
        Task<bool> DeleteCarModelAsync(int id);
        Task<IActionResult> EditCarModel(int id, string name);
        CarModel GetCarModel(int id);
    }
}
