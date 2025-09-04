using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.Entities.Entities.Company;
public class Company : TrackingBase
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string RIN { get; set; } = string.Empty;

    public ICollection<Branch> Branches { get; set; } = new HashSet<Branch>();
    public ICollection<ActiveCode> ActiveCodes { get; set; } = new HashSet<ActiveCode>();
}
