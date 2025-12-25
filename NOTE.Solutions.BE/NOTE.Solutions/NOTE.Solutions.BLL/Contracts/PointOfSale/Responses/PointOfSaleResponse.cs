namespace NOTE.Solutions.BLL.Contracts.POS.Responses;

public class PointOfSaleResponse
{
    public int Id { get; set; }
    public string POSSerial { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }
}
