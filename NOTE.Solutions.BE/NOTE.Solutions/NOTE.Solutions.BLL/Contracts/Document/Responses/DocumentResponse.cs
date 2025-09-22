using NOTE.Solutions.BLL.Contracts.DocumentDetail.Responses;
using NOTE.Solutions.BLL.Contracts.DocumentType.Responses;
using NOTE.Solutions.Entities.Enums;


namespace NOTE.Solutions.BLL.Contracts.Document.Responses;

public class DocumentResponse
{
    public int Id { get; set; }
    public PaymentMethodType PaymentMethod { get; set; }
    public DocumentTypeResponse DocumentType { get; set; } = default!;
    public List<DocumentDetailResponse> DocumentDetails { get; set; } = [];
}
