using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NOTE.Solutions.Entities.Abstractions.Consts;
using NOTE.Solutions.Entities.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NOTE.Solutions.Entities.EntitiesConfiguration;

public class DashboardConfiguration : IEntityTypeConfiguration<Context>
{
    public void Configure(EntityTypeBuilder<Context> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasMaxLength(256);

        builder.HasData(new Context()
        {
            Id = DefaultContext.SystemAdminId,
            Name = DefaultContext.SystemAdmin,
        });
    }
}
