using Microsoft.AspNetCore.Authorization;

namespace NOTE.Solutions.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BranchesController(IBranchService branchService) : ControllerBase
{
    private readonly IBranchService _branchService = branchService;

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _branchService.GetAllAsync();
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _branchService.GetById(id);
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(BranchRequest request)
    {
        var result = await _branchService.CreateAsync(request);
        return result.IsSuccess ? CreatedAtAction(nameof(GetById), new { id = result.Value.Id }, result.Value) : result.ToProblem();
    }


    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(int id, BranchRequest request)
    {
        var result = await _branchService.UpdateAsync(id, request);
        return result.IsSuccess ? NoContent() : result.ToProblem();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _branchService.DeleteAsync(id);
        return result.IsSuccess ? NoContent() : result.ToProblem();
    }
}
