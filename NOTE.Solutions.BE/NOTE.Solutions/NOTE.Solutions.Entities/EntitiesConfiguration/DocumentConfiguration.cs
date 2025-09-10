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
        builder.Property(x => x.DateTime).IsRequired();

        builder.Property(x => x.DocumentNumber).IsRequired();

        builder.Property(x => x.UUID).IsRequired();

        builder.Property(x => x.BuyerName).IsRequired().HasMaxLength(100);

        builder.Property(x => x.BuyerSSN).IsRequired().HasMaxLength(100);

        builder.Property(x => x.BuyerType).IsRequired();

        builder.Property(x => x.PaymentMethod).IsRequired();
        
        builder.Property(x => x.BranchId).IsRequired();
        
        builder.Property(x => x.DocumentTypeId).IsRequired();

        builder.HasIndex(x => x.UUID).IsUnique();

    }
}
