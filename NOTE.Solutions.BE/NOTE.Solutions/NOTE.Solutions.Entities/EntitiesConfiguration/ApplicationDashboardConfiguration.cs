using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NOTE.Solutions.Entities.Abstractions.Consts;
using NOTE.Solutions.Entities.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NOTE.Solutions.Entities.EntitiesConfiguration;

public class ApplicationDashboardConfiguration : IEntityTypeConfiguration<ApplicationDashboard>
{
    public void Configure(EntityTypeBuilder<ApplicationDashboard> builder)
    {
        builder.HasData(new ApplicationDashboard()
        {
            Id = DefaultDashboard.SystemAdminId,
            Name = DefaultDashboard.SystemAdmin
        });
    }
}
