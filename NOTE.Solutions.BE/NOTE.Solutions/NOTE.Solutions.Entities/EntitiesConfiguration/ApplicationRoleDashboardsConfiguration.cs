using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NOTE.Solutions.Entities.Abstractions.Consts;
using NOTE.Solutions.Entities.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NOTE.Solutions.Entities.EntitiesConfiguration;

internal class ApplicationRoleDashboardsConfiguration : IEntityTypeConfiguration<ApplicationRoleDashboards>
{
    public void Configure(EntityTypeBuilder<ApplicationRoleDashboards> builder)
    {
        builder.HasKey(d => new { d.ApplicationDashboardId, d.ApplicationRoleId });

        builder.HasData(new ApplicationRoleDashboards()
        {
            ApplicationDashboardId = DefaultDashboard.SystemAdminId,
            ApplicationRoleId = DefaultRoles.SystemAdminRoleId,
        });
    }
}
