using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NOTE.Solutions.BLL.Contracts.Tax.Requests;

namespace NOTE.Solutions.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TaxesController(ITaxService taxService) : ControllerBase
{
    private readonly ITaxService _taxService = taxService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _taxService.GetAllAsync();
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpGet("{taxId:int}")]
    public async Task<IActionResult> GetById(int taxId)
    {
        var result = await _taxService.GetByIdAsync(taxId);
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TaxRequest request)
    {
        var result = await _taxService.CreateAsync(request);
        return result.IsSuccess ? CreatedAtAction(nameof(GetById), new { taxId = result.Value.Id }, result.Value) : result.ToProblem();
    }

    [HttpPut("{taxId:int}")]
    public async Task<IActionResult> Update(int taxId, [FromBody] TaxRequest request)
    {
        var result = await _taxService.UpdateAsync(taxId, request);
        return result.IsSuccess ? NoContent() : result.ToProblem();
    }

    [HttpDelete("{taxId:int}")]
    public async Task<IActionResult> Delete(int taxId)
    {
        var result = await _taxService.DeleteAsync(taxId);
        return result.IsSuccess ? NoContent() : result.ToProblem();
    }
}
