using HW_20.Domain.Entites.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HW_20.Infrastructure.Configuration
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(c => c.Id);
            builder.ToTable("Users");
            builder.Property(c => c.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            builder.Property(c => c.PhoneNumber)
                  .IsRequired()
                  .HasMaxLength(50);
            builder.HasData(new User
            {
                Id = 1,
                UserName ="aso.lotfi@gmail.com",
                PhoneNumber = "09189827366"

            });
        }
    }
}
