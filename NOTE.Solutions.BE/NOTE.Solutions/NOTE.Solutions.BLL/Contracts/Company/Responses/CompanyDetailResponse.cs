using NOTE.Solutions.BLL.Contracts.Manager.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.BLL.Contracts.Company.Responses;

public class CompanyDetailResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string RIN { get; set; } = string.Empty;
    public List<ActiveCodeResponse> ActiveCodes { get; set; } = [];
    public List<BranchResponse> Branches { get; set; } = [];
    public List<ManagerResponse> Managers { get; set; } = [];
}
