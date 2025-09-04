using NOTE.Solutions.Entities.Entities.Company;
using NOTE.Solutions.Entities.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.Entities.Entities.Unit;
public class Unit : TrackingBase
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;

    public int BranchId { get; set; }
    public Branch Branch { get; set; }

    public ICollection<ProductUnit> ProductUnits { get; set; } = new HashSet<ProductUnit>();
}
