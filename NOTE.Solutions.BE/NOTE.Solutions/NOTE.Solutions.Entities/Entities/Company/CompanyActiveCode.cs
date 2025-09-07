using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.Entities.Entities.Company;

public class CompanyActiveCode
{
    public int CompanyId { get; set; }
    public Company Company { get; set; }

    public int ActiveCodeId { get; set; }
    public ActiveCode ActiveCode { get; set; }
}
