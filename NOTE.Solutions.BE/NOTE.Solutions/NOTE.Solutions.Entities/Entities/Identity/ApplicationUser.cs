using Microsoft.AspNetCore.Identity;
using NOTE.Solutions.Entities.Entities.Company;

namespace NOTE.Solutions.Entities.Entities.Identity;

public class ApplicationUser : IdentityUser<int>
{
    public string Name { get; set; } = string.Empty;
    public string IdentifierNumber { get; set; } = string.Empty;
    public bool IsDisabled { get; set; }
    public bool IsDeleted { get; set; }
    public ICollection<UserCompanies> UserCompanies { get; set; } = new HashSet<UserCompanies>();
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new HashSet<RefreshToken>();
    public ICollection<UserPermissionOverride> PermissionOverrides { get; set; } = new HashSet<UserPermissionOverride>();
    public ICollection<ApplicationUserContexts> ApplicationUserContexts { get; set; } = new HashSet<ApplicationUserContexts>();
}
