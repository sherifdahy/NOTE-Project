namespace ETA.Consume.Contracts.Header.ResRequestsponses;

public class HeaderRequest
{
    public DateTime DateTimeIssued { get; set; } 
    public string ReceiptNumber { get; set; } = string.Empty;
    public string UUID { get; set; } = string.Empty;
    public string PreviousUUID { get; set; } = string.Empty;
    public string Currency { get; set; } = string.Empty;
    public decimal ExchangeRate { get; set; }

}
