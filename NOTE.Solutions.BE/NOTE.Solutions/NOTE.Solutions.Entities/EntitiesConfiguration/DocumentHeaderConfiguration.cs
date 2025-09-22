using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NOTE.Solutions.Entities.Entities.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.Entities.EntitiesConfiguration;

public class DocumentHeaderConfiguration : IEntityTypeConfiguration<DocumentHeader>
{
    public void Configure(EntityTypeBuilder<DocumentHeader> builder)
    {
        builder.Property(x => x.DateTime).IsRequired();

        builder.Property(x => x.DocumentNumber).IsRequired();

        builder.Property(x => x.UUID).IsRequired();

    }
}
