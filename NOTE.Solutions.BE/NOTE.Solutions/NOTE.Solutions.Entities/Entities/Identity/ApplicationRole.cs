
using Microsoft.AspNetCore.Identity;

namespace NOTE.Solutions.Entities.Entities.Identity;
public class ApplicationRole : IdentityRole<int>
{
    public bool IsDefault { get; set; }
    public bool IsDeleted { get; set; }
    public ICollection<ApplicationRoleDashboards> RoleDashboards { get; set; } = new HashSet<ApplicationRoleDashboards>();
}
