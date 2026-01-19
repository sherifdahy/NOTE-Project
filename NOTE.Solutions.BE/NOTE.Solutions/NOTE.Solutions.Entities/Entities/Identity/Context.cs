namespace NOTE.Solutions.Entities.Entities.Identity;

public class Context
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }
    public ICollection<ApplicationUserContexts> ApplicationUserContexts { get; set; } = new HashSet<ApplicationUserContexts>();
}
