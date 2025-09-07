namespace NOTE.Solutions.Entities.Entities.Company;
public class ActiveCode : AuditableEntity
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;

    public ICollection<CompanyActiveCode> CompanyActiveCodes { get; set; } = new HashSet<CompanyActiveCode>();
}
