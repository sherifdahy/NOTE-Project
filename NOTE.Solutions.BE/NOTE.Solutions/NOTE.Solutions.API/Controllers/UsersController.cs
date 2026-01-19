using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NOTE.Solutions.API.Extensions;

namespace NOTE.Solutions.API.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UsersController(IUserService userService,IHttpContextAccessor httpContextAccessor) : ControllerBase
{
    private readonly IUserService _userService = userService;
    private readonly IHttpContextAccessor _contextAccessor = httpContextAccessor;
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await _userService.GetAllAsync(cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpGet("branches")]
    public async Task<IActionResult> GetBranches(CancellationToken cancellationToken)
    {
        var result = await _userService.GetBranchesAsync(_contextAccessor.HttpContext!.User.GetUserId());
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }
}
