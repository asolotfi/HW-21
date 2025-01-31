using HW_20.Domain.Entites.Car;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class InspectionRequestConfig : IEntityTypeConfiguration<InspectionRequest>
{
    public void Configure(EntityTypeBuilder<InspectionRequest> builder)
    {
        builder.HasKey(ir => ir.Id);

      
    }
}

