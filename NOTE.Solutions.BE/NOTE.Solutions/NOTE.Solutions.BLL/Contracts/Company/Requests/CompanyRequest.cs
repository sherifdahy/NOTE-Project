namespace NOTE.Solutions.BLL.Contracts.Company.Requests;

public class CompanyRequest
{
    public string Name { get; set; } = string.Empty;
    public string RIN { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public List<int> ActiveCodes { get; set; } = [];
}
