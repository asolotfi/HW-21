using HW_20.Domain.Entites.Car;
using HW_20.Infrastructure.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace HW_20.Domain.Contract.Repositoris
{
    public class CarModelRepository : ICarModelRepository
    {
        private readonly AppDbContext _appDbContext;

        public CarModelRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<int> AddCarModelAsync(string name)
        {
            var result = await _appDbContext.CarModels.FirstOrDefaultAsync(x => x.Name == name); // استفاده از await
            try
            {
                if (name == null || result != null) // اینجا بررسی کردید آیا مدل با این نام موجود است
                {
                    return result?.Id ?? 0; // اگر موجود بود، شناسه آن را برمی‌گرداند
                }
                var carModel = new CarModel
                {
                    Name = name,
                };
                await _appDbContext.CarModels.AddAsync(carModel); // اضافه کردن مدل به صورت غیرهمزمان
                await _appDbContext.SaveChangesAsync(); // ذخیره تغییرات به صورت غیرهمزمان

                return carModel.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new ApplicationException("خطا در زمان ثبت مدل", ex);
            }
        }


        public async Task<bool> DeleteCarModelAsync(int id)
        {
            var result = await _appDbContext.CarModels.FirstOrDefaultAsync(x => x.Id == id);
            try
            {
                if (result == null)
                {
                    return false; // مدل پیدا نشد
                }

                // بررسی وابستگی‌ها به جدول دیگری
                var dependentRecords = await _appDbContext.Cars
                    .Where(x => x.CardModelId == id)
                    .ToListAsync();

                if (dependentRecords.Any())
                {
                    // اگر رکورد وابسته یافت شد، عملیات حذف را انجام ندهید
                    throw new InvalidOperationException("مدل خودرو دارای رکوردهای وابسته است و نمی‌توان آن را حذف کرد.");
                }

                // عملیات حذف مدل خودرو
                _appDbContext.CarModels.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // کنترل و ثبت خطا
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
                throw new ApplicationException("خطا در زمان حذف مدل", ex);
            }
        }


        public async Task<IActionResult> EditCarModel(int id, string name)
        {
            try
            {
                var carModel = await GetCarModelAsync(id); // استفاده از await

                if (carModel == null)
                {
                    return new BadRequestObjectResult("مدل خودرو پیدا نشد.");
                }

                carModel.Name = name;
                await _appDbContext.SaveChangesAsync();   // ذخیره به صورت غیرهمزمان
                return new OkObjectResult("ویرایش با موفقیت انجام شد.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ObjectResult("خطا در زمان ویرایش مدل")
                {
                    StatusCode = 500
                };
            }
        }

        public async Task<CarModel> GetCarModelAsync(int id)
        {
            return await _appDbContext.CarModels.FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
