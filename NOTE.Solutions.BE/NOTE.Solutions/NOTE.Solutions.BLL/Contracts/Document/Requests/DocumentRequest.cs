using NOTE.Solutions.BLL.Contracts.DocumentDetail.Requests;
using NOTE.Solutions.Entities.Enums;


namespace NOTE.Solutions.BLL.Contracts.Document.Requests;

public class DocumentRequest 
{
    public DocumentHeaderRequest Header { get; set; } = default!;
    public DocumentBuyerRequest Buyer { get; set; } = default!;
    public PaymentMethodType PaymentMethod { get; set; }
    public int DocumentTypeId { get; set; }
    public int ActiveCodeId { get; set; }
    public List<DocumentDetailRequest> DocumentDetails { get; set; } = [];
}
