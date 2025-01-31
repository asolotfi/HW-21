using HW_20.Domain.Entites.Car;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HW_20.Infrastructure.Configuration
{
    public class CarConfig : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            // تنظیم کلید اصلی
            builder.HasKey(c => c.Id);

            // تنظیم نام جدول
            builder.ToTable("Cars");

            // رابطه با مدل خودرو
            builder.HasOne(c => c.CarModels)
                   .WithMany() // مدل خودرو می‌تواند چندین خودرو داشته باشد
                   .HasForeignKey(c => c.CardModelId) //کلید خارجی مدل خودرو
                   .OnDelete(DeleteBehavior.Restrict);

            // رابطه با تولیدکننده خودرو
            builder.HasOne(c => c.Manufacturer)
                   .WithMany(c => c.Cars) // تولیدکننده می‌تواند چندین خودرو داشته باشد
                   .HasForeignKey(c => c.ManufacturerId) // کلید خارجی تولیدکننده خودرو
                   .OnDelete(DeleteBehavior.Restrict);

         
        }
    }
}

