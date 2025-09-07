using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NOTE.Solutions.Entities.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.Entities.EntitiesConfiguration;

public class ProductUnitConfiguration : IEntityTypeConfiguration<ProductUnit>
{
    public void Configure(EntityTypeBuilder<ProductUnit> builder)
    {
        builder.HasKey(pu => pu.Id);
        builder.Property(pu => pu.Description)
               .IsRequired()
               .HasMaxLength(200);
        builder.Property(pu => pu.InternalCode)
               .IsRequired()
               .HasMaxLength(50);
        builder.Property(pu => pu.GlobalCode)
               .IsRequired()
               .HasMaxLength(50);
        builder.Property(pu => pu.UnitPrice)
               .IsRequired();
        builder.HasOne(pu => pu.Product)
               .WithMany(p => p.ProductUnits)
               .HasForeignKey(pu => pu.ProductId)
               .OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(pu => pu.DocumentDetails)
               .WithOne(dd => dd.ProductUnit)
               .HasForeignKey(dd => dd.ProductUnitId)
               .OnDelete(DeleteBehavior.Restrict);
        
    }
}
