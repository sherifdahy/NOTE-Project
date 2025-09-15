using Microsoft.AspNetCore.Authorization;
using NOTE.Solutions.BLL.Contracts.Auth.Requests;
using NOTE.Solutions.BLL.Contracts.Auth.Responses;

namespace NOTE.Solutions.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    private readonly IAuthService _authService = authService;

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest authRequest,CancellationToken cancellationToken)
    {
        var result = await _authService.LoginAsync(authRequest,cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem(); 
    }


    [HttpPost("register-company")]
    public async Task<IActionResult> Register(RegisterCompanyRequest request, CancellationToken cancellationToken)
    {
        var result = await _authService.RegisterCompanyAsync(request, cancellationToken);
        return result.IsSuccess ? Created() : result.ToProblem();
    }


}
