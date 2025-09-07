using NOTE.Solutions.Entities.Entities.Company;

namespace NOTE.Solutions.Entities.Entities.Product;
public class Product : AuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public int BranchId { get; set; }
    public Branch? Branch { get; set; }


    public ICollection<ProductUnit> ProductUnits { get; set; } = new HashSet<ProductUnit>();
}
