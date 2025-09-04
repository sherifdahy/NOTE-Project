using NOTE.Solutions.Entities.Entities.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.Entities.Entities.Identity;
public class ApplicationUser : TrackingBase
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string SSN { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;


    public int ApplicationRoleId { get; set; }
    public ApplicationRole ApplicationRole { get; set; }

    public ICollection<Branch> Branches { get; set; } = new HashSet<Branch>();
}
