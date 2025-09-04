using NOTE.Solutions.Entities.Entities.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.Entities.Entities.Product;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int BranchId { get; set; }
    public Branch Branch { get; set; }


    public ICollection<ProductUnit> ProductUnits { get; set; } = new HashSet<ProductUnit>();
}
