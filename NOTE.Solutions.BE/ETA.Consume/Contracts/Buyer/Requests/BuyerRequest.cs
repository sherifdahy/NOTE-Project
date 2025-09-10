namespace ETA.Consume.Contracts.Buyer.Requests;

public class BuyerRequest
{
    public string Type { get; set; } = string.Empty;
    public string Id { get; set; } = string.Empty;
    public string? Name { get; set; } 
    public string? MobileNumber { get; set; }
}
