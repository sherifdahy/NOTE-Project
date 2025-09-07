using NOTE.Solutions.BLL.Contracts.Role.Requests;
using NOTE.Solutions.BLL.Contracts.Role.Responses;
using NOTE.Solutions.DAL.Abstractions;
using NOTE.Solutions.Entities.Entities.Identity;

namespace NOTE.Solutions.BLL.Interfaces;
public interface IRoleService
{
    Task<Result<IEnumerable<RoleResponse>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<RoleResponse>> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Result<RoleResponse>> CreateAsync(RoleRequest request, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(int id, RoleRequest request, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
