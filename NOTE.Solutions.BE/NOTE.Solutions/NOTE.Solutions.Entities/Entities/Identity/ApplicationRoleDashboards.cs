using System;
using System.Collections.Generic;
using System.Text;

namespace NOTE.Solutions.Entities.Entities.Identity;

public class ApplicationRoleDashboards
{
    public int ApplicationRoleId { get; set; }
    public ApplicationRole ApplicationRole { get; set; } = default!;

    public int ApplicationDashboardId { get; set; }
    public ApplicationDashboard ApplicationDashboard { get; set; } = default!;
}
