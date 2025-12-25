using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NOTE.Solutions.BLL.Contracts.Product.Requests;

namespace NOTE.Solutions.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProductsController(IProductService productService) : ControllerBase
{
    private readonly IProductService _productService = productService;

    [HttpGet("/api/companies/{companyId:int}/[controller]")]
    public async Task<IActionResult> GetAll(int companyId, CancellationToken cancellationToken)
    {
        var result = await _productService.GetAllAsync(companyId, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpGet("{productId:int}")]
    public async Task<IActionResult> GetById(int productId, CancellationToken cancellationToken)
    {
        var result = await _productService.GetByIdAsync(productId, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpPost("~/api/companies/{companyId:int}/[controller]")]
    public async Task<IActionResult> Create(int companyId, [FromBody] ProductRequest request, CancellationToken cancellationToken)
    {
        var result = await _productService.CreateAsync(companyId, request, cancellationToken);
        return result.IsSuccess ? CreatedAtAction(nameof(GetById), new { productId = result.Value.Id }, result.Value) : result.ToProblem();
    }

    [HttpPut("/api/companies/{companyId:int}/{productId:int}")]
    public async Task<IActionResult> Update(int productId,int companyId, [FromBody] ProductRequest request, CancellationToken cancellationToken)
    {
        var result = await _productService.UpdateAsync(productId,companyId,request, cancellationToken);
        return result.IsSuccess ? NoContent() : result.ToProblem();
    }

    [HttpDelete("{productId:int}")]
    public async Task<IActionResult> Delete(int productId, CancellationToken cancellationToken)
    {
        var result = await _productService.ToggleStatusAsync(productId, cancellationToken);
        return result.IsSuccess ? NoContent() : result.ToProblem();
    }
}
