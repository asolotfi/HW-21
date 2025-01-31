
using HW_20.Domain.Entites.Car;
using HW_20.Domain.Entites.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace HW_20.Infrastructure.DB
{
    public class AppDbContext : DbContext
    {
        public DbSet<InspectionRequest> InspectionRequests { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OldCarRequest> OldCarRequest { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        


        private readonly IConfiguration _configuration;
        internal object users;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

  

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // فراخوانی رشته اتصال از appsettings.json
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<InspectionRequest>()
            //    .HasOne(y => y.Car)
            //    .WithMany(x => x.InspectionRequests)
            //    .HasForeignKey(x => x.CarId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //  // اضافه کردن محدودیت یکتایی برای ترکیب PlateNumber و Year
            //  modelBuilder.Entity<InspectionRequest>()
            //.HasIndex(r => new { r.PlateNumber, r.RequestDate.Year })
            //.IsUnique();

        }
    }

    //َAdd-Migration init
    //Update-Database
}

