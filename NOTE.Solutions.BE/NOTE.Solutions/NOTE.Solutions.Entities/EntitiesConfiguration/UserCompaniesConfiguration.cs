using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NOTE.Solutions.Entities.Entities.Company;
using System;
using System.Collections.Generic;
using System.Text;

namespace NOTE.Solutions.Entities.EntitiesConfiguration;

public class UserCompaniesConfiguration : IEntityTypeConfiguration<UserCompanies>
{
    public void Configure(EntityTypeBuilder<UserCompanies> builder)
    {
        builder.HasKey(x=> new { x.ApplicationUserId,x.CompanyId });
    }
}
