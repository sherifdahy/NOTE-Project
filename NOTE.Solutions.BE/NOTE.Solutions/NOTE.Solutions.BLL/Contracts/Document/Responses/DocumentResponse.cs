using NOTE.Solutions.BLL.Contracts.DocumentDetail.Responses;
using NOTE.Solutions.BLL.Contracts.DocumentType.Responses;
using NOTE.Solutions.Entities.Enums;


namespace NOTE.Solutions.BLL.Contracts.Document.Responses;

public class DocumentResponse
{
    public int Id { get; set; }
    public DateTime DateTime { get; set; }
    public string DocumentNumber { get; set; } = string.Empty;
    public string UUID { get; set; } = string.Empty;
    public string BuyerName { get; set; } = string.Empty;
    public string BuyerSSN { get; set; } = string.Empty;
    public BuyerType BuyerType { get; set; }
    public PaymentMethodType PaymentMethod { get; set; }
    public DocumentTypeResponse DocumentType { get; set; } = default!;
    public List<DocumentDetailResponse> DocumentDetails { get; set; } = [];
}
