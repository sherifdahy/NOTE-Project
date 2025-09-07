using Microsoft.AspNetCore.Authorization;

namespace NOTE.Solutions.API.Controllers;

[Route("api/[controller]")]
[Authorize]
[ApiController]
public class RolesController(IRoleService roleService) : ControllerBase
{
    private readonly IRoleService _roleService = roleService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _roleService.GetAllAsync();
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpGet("{roleId:int}")]
    public async Task<IActionResult> GetById(int roleId)
    {
        var result = await _roleService.GetByIdAsync(roleId);
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RoleRequest request)
    {
        var result = await _roleService.CreateAsync(request);
        return result.IsSuccess ? CreatedAtAction(nameof(GetById), new { roleId = result.Value.Id }, result.Value) : result.ToProblem();
    }

    [HttpPut("{roleId:int}")]
    public async Task<IActionResult> Update(int roleId, [FromBody] RoleRequest request)
    {
        var result = await _roleService.UpdateAsync(roleId, request);
        return result.IsSuccess ? NoContent() : result.ToProblem();
    }

    [HttpDelete("{roleId:int}")]
    public async Task<IActionResult> Delete(int roleId)
    {
        var result = await _roleService.DeleteAsync(roleId);
        return result.IsSuccess ? NoContent() : result.ToProblem();
    }
}
