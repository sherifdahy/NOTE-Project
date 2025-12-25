using Microsoft.AspNetCore.Authorization;
using NOTE.Solutions.BLL.Authentication.Filters;
using NOTE.Solutions.BLL.Contracts.POS.Requests;
using NOTE.Solutions.Entities.Abstractions.Consts;

namespace NOTE.Solutions.API.Controllers;

[Route("api/branches/{branchId:int}/[controller]")]
[ApiController]
[Authorize]
public class POSsController(IPointOfSaleService pOSService) : ControllerBase
{
    private readonly IPointOfSaleService _pOSService = pOSService;

    [HttpGet("/api/branches/{branchId}/point-of-sales")]
    [HasPermission(Permissions.GetPointOfSales)]
    public async Task<IActionResult> GetAll(int branchId, CancellationToken cancellationToken)
    {
        var result = await _pOSService.GetAllAsync(branchId, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpGet("/api/point-of-sales/{posId}")]
    [HasPermission(Permissions.GetPointOfSales)]
    public async Task<IActionResult> GetById(int branchId, int posId, CancellationToken cancellationToken)
    {
        var result = await _pOSService.GetById(posId, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpPost("/api/branches/{branchId}/point-of-sales")]
    [HasPermission(Permissions.CreatePointOfSales)]
    public async Task<IActionResult> Create(int branchId, PointOfSaleRequest request, CancellationToken cancellationToken)
    {
        var result = await _pOSService.CreateAsync(branchId, request, cancellationToken);
        return result.IsSuccess ? Created() : result.ToProblem();
    }

    [HttpPut("/api/point-of-sales/{posId}")]
    [HasPermission(Permissions.UpdatePointOfSales)]
    public async Task<IActionResult> Update(int posId, PointOfSaleRequest request, CancellationToken cancellationToken)
    {
        var result = await _pOSService.UpdateAsync(posId, request, cancellationToken);
        return result.IsSuccess ? NoContent() : result.ToProblem();
    }

    [HttpDelete("/api/point-of-sales/{posId}")]
    [HasPermission(Permissions.ToggleStatusPointOfSales)]
    public async Task<IActionResult> Delete(int posId, CancellationToken cancellationToken)
    {
        var result = await _pOSService.ToggleStatusAsync(posId, cancellationToken);
        return result.IsSuccess ? NoContent() : result.ToProblem();
    }
}
