namespace NOTE.Solutions.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    protected int UserId => int.Parse(User.Claims.First(c => c.Type == "UserId").Value);
    protected int CompanyId => int.Parse(User.Claims.First(c => c.Type == "CompanyId").Value);

}
