
namespace NOTE.Solutions.Entities.Entities.Document;
public class DocumentType
{
    public int Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;

    public ICollection<Document> Documents { get; set; } = new HashSet<Document>();
}