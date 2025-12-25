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

        builder.Property(pu => pu.UnitPrice)
               .IsRequired();
    }
}
