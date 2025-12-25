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

public class BranchDetailResponse
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string BuildingNumber { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public CityResponse City { get; set; } = default!;
    public List<EmployeeResponse> Employees { get; set; } = [];
    public List<PointOfSaleResponse> PointOfSales { get; set; } = [];


}
