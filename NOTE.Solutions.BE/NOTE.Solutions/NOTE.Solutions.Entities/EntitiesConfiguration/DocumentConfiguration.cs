using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NOTE.Solutions.Entities.Entities.Company;
using NOTE.Solutions.Entities.Entities.Document;
using NOTE.Solutions.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.Entities.EntitiesConfiguration;

public class DocumentConfiguration : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        
        builder.Property(x => x.PaymentMethod).IsRequired();

        builder.Property(x => x.BranchId).IsRequired();

        builder.Property(x => x.DocumentTypeId).IsRequired();

        builder
            .HasOne(x => x.Buyer)
            .WithOne(w => w.Document)
            .HasForeignKey<Document>(w=>w.BuyerId);

        builder
            .HasOne(w => w.Header)
            .WithOne(w => w.Document)
            .HasForeignKey<Document>(w=>w.HeaderId);
    }
}
