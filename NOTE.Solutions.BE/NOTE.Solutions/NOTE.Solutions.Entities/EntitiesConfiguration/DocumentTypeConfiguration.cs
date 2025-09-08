using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NOTE.Solutions.Entities.Entities.Document;

namespace NOTE.Solutions.Entities.EntitiesConfiguration;

public class DocumentTypeConfiguration : IEntityTypeConfiguration<DocumentType>
{
    public void Configure(EntityTypeBuilder<DocumentType> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x=> new { x.Type, x.Version }).IsUnique();
        builder.Property(x => x.Type).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Version).IsRequired().HasMaxLength(20);
    }
}
