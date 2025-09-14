
using NOTE.Solutions.Entities.Enums;

namespace NOTE.Solutions.BLL.Interfaces;
public interface IRoleService
{
    Task<Result> AssignToRoleAsync(List<ApplicationUser> users, RoleType role);
    Task<Result> AssignToRoleAsync(ApplicationUser user, RoleType role);
    Task<Result<IEnumerable<RoleResponse>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<RoleResponse>> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Result<RoleResponse>> CreateAsync(RoleRequest request, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(int id, RoleRequest request, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
