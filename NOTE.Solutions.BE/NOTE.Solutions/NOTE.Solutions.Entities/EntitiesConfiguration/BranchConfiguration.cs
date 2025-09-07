using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NOTE.Solutions.Entities.Entities.Company;
using System.Reflection.Emit;

namespace NOTE.Solutions.Entities.EntitiesConfiguration;

public class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.Property(x => x.CompanyId).IsRequired();
        builder.Property(x => x.CityId).IsRequired();
        builder.HasIndex(b => new { b.Code, b.CompanyId, b.CityId }).IsUnique();

        builder
            .HasOne(b => b.CreatedBy)
            .WithMany()
            .HasForeignKey(b => b.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(b => b.UpdatedBy)
            .WithMany()
            .HasForeignKey(b => b.UpdatedById)
            .OnDelete(DeleteBehavior.Restrict);
    }
}