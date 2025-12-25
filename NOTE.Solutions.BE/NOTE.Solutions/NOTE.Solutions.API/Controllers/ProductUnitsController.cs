using Microsoft.AspNetCore.Authorization;
using NOTE.Solutions.BLL.Contracts.ProductUnit.Requests;

namespace NOTE.Solutions.API.Controllers;

[Route("api/products/{productId}/[controller]")]
[ApiController]
[Authorize]
public class ProductUnitsController : ControllerBase
{
    private readonly IProductUnitService _productUnitService;

    public ProductUnitsController(IProductUnitService productUnitService)
    {
        _productUnitService = productUnitService;
    }

    [HttpGet("/api/companies/{companyId}/productUnits")]
    public async Task<IActionResult> GetAll(int companyId, CancellationToken cancellationToken)
    {
        var result = await _productUnitService.GetAllAsync(companyId,cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpGet("{productUnitId:int}")]
    public async Task<IActionResult> GetById(int productUnitId, CancellationToken cancellationToken)
    {
        var result = await _productUnitService.GetByIdAsync(productUnitId,cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpPost]
    public async Task<IActionResult> Create(int productId, [FromBody] ProductUnitRequest request, CancellationToken cancellationToken)
    {
        var result = await _productUnitService.CreateAsync(productId, request,cancellationToken);
        return result.IsSuccess
            ? Created()
            : result.ToProblem();
    }

    [HttpPut("{productUnitId:int}")]
    public async Task<IActionResult> Update(int productUnitId, [FromBody] ProductUnitRequest request, CancellationToken cancellationToken)
    {
        var result = await _productUnitService.UpdateAsync(productUnitId, request,cancellationToken);
        return result.IsSuccess ? NoContent() : result.ToProblem();
    }

    [HttpDelete("{productUnitId:int}")]
    public async Task<IActionResult> Delete(int productUnitId,CancellationToken cancellationToken)
    {
        var result = await _productUnitService.ToggleStatusAsync(productUnitId,cancellationToken);
        return result.IsSuccess ? NoContent() : result.ToProblem();
    }
}
