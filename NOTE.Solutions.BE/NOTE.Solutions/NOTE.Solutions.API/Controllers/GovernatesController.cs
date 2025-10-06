using Microsoft.AspNetCore.Authorization;
using NOTE.Solutions.BLL.Contracts.Governate.Requests;

namespace NOTE.Solutions.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class GovernatesController(IGovernateService governateService) : ControllerBase
{
    private readonly IGovernateService _governateService = governateService;

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll()
    {
        var result = await _governateService.GetAllAsync();
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpGet("{governateId:int}")]
    public async Task<IActionResult> GetById(int governateId)
    {
        var result = await _governateService.GetByIdAsync(governateId);
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] GovernateRequest request)
    {
        var result = await _governateService.CreateAsync(request);
        return result.IsSuccess ? CreatedAtAction(nameof(GetById), new { governateId = result.Value.Id }, result.Value) : result.ToProblem();
    }

    [HttpPut("{governateId:int}")]
    public async Task<IActionResult> Update(int governateId, [FromBody] GovernateRequest request)
    {
        var result = await _governateService.UpdateAsync(governateId, request);
        return result.IsSuccess ? NoContent() : result.ToProblem();
    }

    [HttpDelete("{governateId:int}")]
    public async Task<IActionResult> Delete(int governateId)
    {
        var result = await _governateService.DeleteAsync(governateId);
        return result.IsSuccess ? NoContent() : result.ToProblem();
    }
}
