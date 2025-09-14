using NOTE.Solutions.BLL.Contracts.User.Requests;

namespace NOTE.Solutions.BLL.Contracts.Branch.Requests;

public class BranchRequest
{
    public string Code { get; set; } = string.Empty;
    public int CityId { get; set; }
    public UserRequest ApplicationUser { get; set; } = default!;

}
