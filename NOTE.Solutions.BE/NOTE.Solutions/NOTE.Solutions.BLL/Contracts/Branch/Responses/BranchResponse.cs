using NOTE.Solutions.BLL.Contracts.City.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.BLL.Contracts.Branch.Responses;

public class BranchResponse
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public int CompanyId { get; set; }
    public int CityId { get; set; }

}
