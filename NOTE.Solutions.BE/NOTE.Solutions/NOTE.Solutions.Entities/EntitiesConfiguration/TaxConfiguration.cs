using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NOTE.Solutions.Entities.Entities.Document;

namespace NOTE.Solutions.Entities.EntitiesConfiguration;

public class TaxConfiguration : IEntityTypeConfiguration<Tax>
{
    public void Configure(EntityTypeBuilder<Tax> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x=> x.Code).IsUnique();
        builder.Property(x => x.Code).IsRequired().HasMaxLength(50);
        builder.HasMany(x => x.DocumentDetail_Taxes)
               .WithOne(x => x.Tax)
               .HasForeignKey(x => x.TaxId);
    }
}
