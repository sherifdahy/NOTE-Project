using NOTE.Solutions.BLL.Contracts.User.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.BLL.Contracts.Auth.Requests;

public class RegisterCompanyRequest
{
    // company information
    public string Name { get; set; } = string.Empty;
    public string RIN { get; set; } = string.Empty;
    public int ActiveCodeId { get; set; }
    public BranchRequest Branch { get; set; } = default!;
}
