using HW_20.Domain.Entites.Car;
using HW_20.Infrastructure.DB;
using System.Diagnostics;

namespace HW_20.Domain.Contract.Repositoris
{
    public class CarModelRepository : ICarModelRepository
    {
        private readonly AppDbContext _appDbContext;

        public CarModelRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public int AddCarModel(string name)
        {
            var result=_appDbContext.CarModels.FirstOrDefault(x => x.Name == name);
            try
            {
                if (name == null || result==null)
                {
                    return result.Id;
                }
                var CarModel = new CarModel
                {
                    Name = name,
                };
                _appDbContext.CarModels.Add(CarModel);
                _appDbContext.SaveChanges();
                return result.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new ApplicationException("خطا در زمان ثبت مدل", ex);
            }
        }

        public bool DeleteCarModel(int id)
        {
            var result = _appDbContext.CarModels.Any(x => x.Id == id);
            try
            {
                if (id == null || !result)
                {
                    return false;
                }
                var CarModel = new CarModel
                {
                    Id = id,
                };
                _appDbContext.CarModels.Remove(CarModel);
                _appDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new ApplicationException("خطا در زمان حذف مدل", ex);
            }
        }

        public bool EditCarModel(int id, string name)
        {
            var carModel = _appDbContext.CarModels.Find(id);
            if (carModel == null)
            {
                return false; // مدل پیدا نشد
            }

            try
            {
                carModel.Name = name; // تغییر نام مدل
                _appDbContext.SaveChanges(); // ذخیره تغییرات
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new ApplicationException("خطا در زمان ویرایش مدل", ex);
            }
        }



        public CarModel GetCarModel(int id)
        {
            return _appDbContext.CarModels.FirstOrDefault(x => x.Id == id);
        }

    }
}
