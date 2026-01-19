using Microsoft.EntityFrameworkCore;
using NOTE.Solutions.BLL.Contracts.User.Responses;

namespace NOTE.Solutions.BLL.Services;
public class UserService(IUnitOfWork unitOfWork,RoleManager<ApplicationRole> roleManager,UserManager<ApplicationUser> userManager) : IUserService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly UserManager<ApplicationUser> _userManager = userManager;

    public async Task<Result<IEnumerable<UserResponse>>> GetAllAsync (CancellationToken cancellationToken = default (CancellationToken))
    {
        var users = _userManager.Users.ToList();
        var result = new List<UserResponse>();

        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);

            result.Add(new UserResponse()
            {
                Id = user.Id,
                Email = user.Email!,
                IsDisabled = user.IsDisabled,
                Roles = roles,
            });
        }

        return Result.Success<IEnumerable<UserResponse>>(result);
    }

    public async Task<Result<IEnumerable<BranchResponse>>> GetBranchesAsync(int userId,CancellationToken cancellationToken = default)
    {
        var branches = await _unitOfWork.Branches.FindAllAsync(d => d.Company.UserCompanies.Any(d => d.ApplicationUserId == userId), [X=>X.Include(e=>e.Company)],cancellationToken);
        return Result.Success(branches.Adapt<IEnumerable<BranchResponse>>());
    }
}
