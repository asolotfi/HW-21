using HW_20.Domain.Entites.Car;
using Microsoft.AspNetCore.Mvc;

namespace HW_20.Domain.Contract.Repositoris
{
    public interface ICarModelRepository
    {
        Task<int> AddCarModelAsync(string name);
        Task<bool> DeleteCarModelAsync(int id);
        Task<IActionResult> EditCarModel(int id, string name);
        Task<CarModel> GetCarModelAsync(int id);
    }
}
