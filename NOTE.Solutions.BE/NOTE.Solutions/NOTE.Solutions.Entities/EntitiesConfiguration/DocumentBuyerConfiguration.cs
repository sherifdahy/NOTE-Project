using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NOTE.Solutions.Entities.Entities.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.Entities.EntitiesConfiguration;

public class DocumentBuyerConfiguration : IEntityTypeConfiguration<DocumentBuyer>
{
    public void Configure(EntityTypeBuilder<DocumentBuyer> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

        builder.Property(x => x.SSN).IsRequired().HasMaxLength(100);

        builder.Property(x => x.Type).IsRequired();

        
    }
}
