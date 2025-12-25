using Microsoft.AspNetCore.Authorization;
using NOTE.Solutions.BLL.Contracts.Common;

namespace NOTE.Solutions.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CompaniesController(ICompanyService companyService) : ControllerBase
{
    private readonly ICompanyService companyService = companyService;

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] RequestFilters filters,[FromQuery] bool includeDisabled = false,CancellationToken cancellationToken = default)
    {
        var result = await companyService.GetAllAsync(filters,includeDisabled,cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpGet("{companyId:int}")]
    public async Task<IActionResult> GetById([FromRoute]int companyId)
    {
        var result = await companyService.GetByIdAsync(companyId);
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CompanyRequest request,CancellationToken cancellationToken)
    {
        var result = await companyService.CreateAsync(request,cancellationToken);
        return result.IsSuccess ? CreatedAtAction(nameof(GetById),new {companyId = result.Value.Id},result.Value) : result.ToProblem();
    }

    [HttpPut("{companyId:int}")]
    public async Task<IActionResult> Update([FromRoute] int companyId, [FromBody] CompanyRequest request)
    {
        var result = await companyService.UpdateAsync(companyId, request);
        return result.IsSuccess ? NoContent() : result.ToProblem();
    }

    [HttpDelete("{companyId:int}")]
    public async Task<IActionResult> ToggleStatus([FromRoute] int companyId)
    {
        var result = await companyService.ToggleStatusAsync(companyId);
        return result.IsSuccess ? NoContent() : result.ToProblem();
    }

    [HttpPost("{companyId}/active-codes/{activeCodeId}")]
    public async Task<IActionResult> AddActiveCode(int companyId,int activeCodeId,CancellationToken cancellationToken)
    {
        var result = await companyService.AddActiveCodeAsync(companyId,activeCodeId,cancellationToken);
        return result.IsSuccess ? Ok() : result.ToProblem();
    }

    [HttpDelete("{companyId}/active-codes/{activeCodeId}")]
    public async Task<IActionResult> RemoveActiveCode(int companyId, int activeCodeId, CancellationToken cancellationToken)
    {
        var result = await companyService.RemoveActiveCodeAsync(companyId, activeCodeId, cancellationToken);
        return result.IsSuccess ? NoContent() : result.ToProblem();
    }
}
