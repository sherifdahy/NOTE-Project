using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NOTE.Solutions.Entities.Entities.Product;

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

        builder
            .HasIndex(pu => new { pu.ProductId, pu.UnitId })
            .IsUnique();

        builder
            .HasIndex(pu => new { pu.ProductId, pu.InternalCode })
            .IsUnique();


        builder.HasIndex(x=> new { x.ProductId, x.UnitId }).IsUnique();

        builder.HasOne(pu => pu.Product)
               .WithMany(p => p.ProductUnits)
               .HasForeignKey(pu => pu.ProductId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pu => pu.Unit)
                .WithMany(u => u.ProductUnits)
                .HasForeignKey(pu => pu.UnitId)
                .OnDelete(DeleteBehavior.Restrict);


        builder.HasMany(pu => pu.DocumentDetails)
               .WithOne(dd => dd.ProductUnit)
               .HasForeignKey(dd => dd.ProductUnitId)
               .OnDelete(DeleteBehavior.Restrict);
        
    }
}
