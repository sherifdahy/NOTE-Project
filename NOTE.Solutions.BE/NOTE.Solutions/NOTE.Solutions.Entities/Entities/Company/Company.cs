using NOTE.Solutions.Entities.Entities.Identity;

namespace NOTE.Solutions.Entities.Entities.Company;
public class Company 
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string RIN { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }
    public ICollection<UserCompanies> UserCompanies { get; set; } = new HashSet<UserCompanies>();
    public ICollection<Branch> Branches { get; set; } = new HashSet<Branch>();
    public ICollection<ActiveCodeCompany> ActiveCodeCompanies { get; set; } = new HashSet<ActiveCodeCompany>();
    public ICollection<Product.Product> Products { get; set; } = new HashSet<Product.Product>();
}
