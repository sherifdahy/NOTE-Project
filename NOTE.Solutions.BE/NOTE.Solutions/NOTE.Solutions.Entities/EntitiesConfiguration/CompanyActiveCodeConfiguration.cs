using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NOTE.Solutions.Entities.Entities.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.Entities.EntitiesConfiguration;

public class CompanyActiveCodeConfiguration : IEntityTypeConfiguration<CompanyActiveCode>
{
    public void Configure(EntityTypeBuilder<CompanyActiveCode> builder)
    {
        builder.HasKey(cac => new { cac.CompanyId, cac.ActiveCodeId });

        builder.HasOne(cac => cac.Company)
               .WithMany(c => c.CompanyActiveCodes)
               .HasForeignKey(cac => cac.CompanyId);

        builder.HasOne(cac => cac.ActiveCode)
                .WithMany(ac => ac.CompanyActiveCodes)
                .HasForeignKey(cac => cac.ActiveCodeId);
    }
}
