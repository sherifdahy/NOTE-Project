
using NOTE.Solutions.Entities.Entities.Identity;

namespace NOTE.Solutions.Entities.Entities.Company;
public class Company 
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string RIN { get; set; } = string.Empty;

    public ICollection<Branch> Branches { get; set; } = new HashSet<Branch>();
    public ICollection<ActiveCode> ActiveCodes { get; set; } = new HashSet<ActiveCode>();
    public ICollection<ApplicationUser> ApplicationUsers { get; set; } = new HashSet<ApplicationUser>();
}
