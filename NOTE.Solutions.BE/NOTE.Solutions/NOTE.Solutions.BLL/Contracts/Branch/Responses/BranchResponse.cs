using NOTE.Solutions.BLL.Contracts.City.Responses;
using NOTE.Solutions.BLL.Contracts.Employee.Responses;
using NOTE.Solutions.BLL.Contracts.POS.Requests;
using NOTE.Solutions.BLL.Contracts.POS.Responses;
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
    public string BuildingNumber { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public int CityId { get; set; }
    public bool IsDeleted { get; set; }
}
