using Microsoft.AspNetCore.Identity;

namespace NOTE.Solutions.Entities.Entities.Identity;

public class UserPermissionOverride
{
    public int ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; } = default!;

    public int RoleClaimId { get; set; }
    public IdentityRoleClaim<int> RoleClaim { get; set; } = default!;

    public bool IsAllowed { get; set; }
}