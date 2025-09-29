using Microsoft.AspNetCore.Identity;
using NOTE.Solutions.Entities.Entities.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.Entities.Entities.Identity;
public class ApplicationUser : IdentityUser<int>
{
    public string Name { get; set; } = string.Empty;
    public string IdentifierNumber { get; set; } = string.Empty;
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new HashSet<RefreshToken>();
}
