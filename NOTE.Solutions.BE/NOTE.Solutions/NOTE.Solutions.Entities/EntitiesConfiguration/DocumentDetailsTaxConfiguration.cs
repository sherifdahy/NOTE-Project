using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NOTE.Solutions.Entities.Entities.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.Entities.EntitiesConfiguration;

public class DocumentDetailsTaxConfiguration : IEntityTypeConfiguration<DocumentDetail_Tax>
{
    public void Configure(EntityTypeBuilder<DocumentDetail_Tax> builder)
    {
        builder
            .HasKey(x => new { x.DocumentDetailId, x.TaxId });

        builder
            .HasOne(x => x.DocumentDetail)
            .WithMany(d => d.DocumentDetail_Taxes)
            .HasForeignKey(x => x.DocumentDetailId);

        builder
            .HasOne(x => x.Tax)
            .WithMany(t => t.DocumentDetail_Taxes)
            .HasForeignKey(x => x.TaxId);

        builder
            .HasOne(x => x.DocumentDetail)
            .WithMany(d => d.DocumentDetail_Taxes)
            .HasForeignKey(x => x.DocumentDetailId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.Tax)
            .WithMany(t => t.DocumentDetail_Taxes)
            .HasForeignKey(x => x.TaxId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
