using NOTE.Solutions.Entities.Entities.Company;

namespace NOTE.Solutions.Entities.Entities.Product;
public class Product : AuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }


    public int CompanyId { get; set; }
    public Company.Company Company { get; set; } = default!;
    public ICollection<ProductUnit> ProductUnits { get; set; } = new HashSet<ProductUnit>();
}
