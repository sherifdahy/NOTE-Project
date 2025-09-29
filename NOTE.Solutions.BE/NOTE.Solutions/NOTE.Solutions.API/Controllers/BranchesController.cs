using Microsoft.AspNetCore.Authorization;
using NOTE.Solutions.API.Extensions;

namespace NOTE.Solutions.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BranchesController(IBranchService branchService) : ControllerBase
{
    private readonly IBranchService _branchService = branchService;

    [HttpGet("")]
    public async Task<IActionResult> GetAll()
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

    [HttpPost("~/api/companies/{companyId}/branches")]
    public async Task<IActionResult> Create(int companyId,BranchRequest request)
    {
        var result = await _branchService.CreateAsync(companyId,request);
        return result.IsSuccess ? Created() : result.ToProblem();
    }


    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(int id, BranchRequest request)
    {
        var result = await _branchService.UpdateAsync(id,1, request);
        return result.IsSuccess ? NoContent() : result.ToProblem();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _branchService.DeleteAsync(id);
        return result.IsSuccess ? NoContent() : result.ToProblem();
    }
}
