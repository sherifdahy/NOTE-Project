using System;
using System.Collections.Generic;
using System.Text;

namespace NOTE.Solutions.Entities.Entities.Identity;

public class ApplicationDashboard
{
    public int Id { get; set; }
    public string Name { get; set; }  = string.Empty;
    public ICollection<ApplicationRoleDashboards> RoleDashboards { get; set; } = new HashSet<ApplicationRoleDashboards>();

}
