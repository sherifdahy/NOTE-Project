using NOTE.Solutions.BLL.Contracts.Auth.Requests;

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

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request,CancellationToken cancellationToken)
    {
        var result = await _authService.RegisterAsync(request,cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }
}
