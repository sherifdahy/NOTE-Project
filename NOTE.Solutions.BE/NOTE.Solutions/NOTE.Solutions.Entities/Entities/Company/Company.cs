
namespace NOTE.Solutions.Entities.Entities.Company;
public class Company 
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string RIN { get; set; } = string.Empty;
    public bool IsActive { get; set; } 

    public ICollection<Branch> Branches { get; set; } = new HashSet<Branch>();
    public ICollection<CompanyActiveCode> CompanyActiveCodes { get; set; } = new HashSet<CompanyActiveCode>();
}
