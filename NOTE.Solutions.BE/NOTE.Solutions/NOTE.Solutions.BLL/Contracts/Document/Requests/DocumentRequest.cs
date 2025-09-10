using NOTE.Solutions.BLL.Contracts.DocumentDetail.Requests;
using NOTE.Solutions.Entities.Enums;


namespace NOTE.Solutions.BLL.Contracts.Document.Requests;

public class DocumentRequest 
{
    public DateTime DateTime { get; set; }
    public string DocumentNumber { get; set; } = string.Empty;
    public string BuyerName { get; set; } = string.Empty;
    public string BuyerSSN { get; set; } = string.Empty;
    public BuyerType BuyerType { get; set; }
    public PaymentMethodType PaymentMethod { get; set; }
    public int DocumentTypeId { get; set; }
    public List<DocumentDetailRequest> DocumentDetails { get; set; } = [];
}
