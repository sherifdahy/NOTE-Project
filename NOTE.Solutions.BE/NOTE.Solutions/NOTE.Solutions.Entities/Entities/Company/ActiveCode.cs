using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.Entities.Entities.Company;
public class ActiveCode : TrackingBase
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;

    public int CompanyId { get; set; }
    public Company Company { get; set; }
}
