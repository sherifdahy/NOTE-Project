using NOTE.Solutions.Entities.Entities.Address;
using NOTE.Solutions.Entities.Entities.Identity;
using NOTE.Solutions.Entities.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.Entities.Entities.Company;
public class Branch : TrackingBase
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;


    public int CompanyId { get; set; }
    public Company Company { get; set; }

    public int CityId { get; set; }
    public City City { get; set; }

    public ICollection<ApplicationUser> ApplicationUsers { get; set; } = new HashSet<ApplicationUser>();
    public ICollection<Product.Product> Products { get; set; } = new HashSet<Product.Product>();
}
