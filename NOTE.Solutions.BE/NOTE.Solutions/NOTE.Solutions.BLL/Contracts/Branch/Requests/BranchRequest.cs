namespace NOTE.Solutions.BLL.Contracts.Branch.Requests;

public class BranchRequest
{
    public string Code { get; set; } = string.Empty;
    public int CompanyId { get; set; }
    public int CityId { get; set; }
}
