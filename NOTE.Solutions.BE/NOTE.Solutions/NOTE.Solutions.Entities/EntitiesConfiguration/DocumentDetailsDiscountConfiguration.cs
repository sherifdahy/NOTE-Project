using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NOTE.Solutions.Entities.Entities.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.Entities.EntitiesConfiguration;

public class DocumentDetailsDiscountConfiguration : IEntityTypeConfiguration<DocumentDetail_Discount>
{
    public void Configure(EntityTypeBuilder<DocumentDetail_Discount> builder)
    {
        builder.HasKey(x=> new { x.DocumentDetailId, x.DiscountId });
    }
}
