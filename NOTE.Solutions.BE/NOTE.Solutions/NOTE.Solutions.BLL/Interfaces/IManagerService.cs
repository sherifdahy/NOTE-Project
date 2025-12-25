using Microsoft.AspNetCore.Mvc;
using NOTE.Solutions.BLL.Contracts.Common;
using NOTE.Solutions.BLL.Contracts.Manager.Requests;
using NOTE.Solutions.BLL.Contracts.Manager.Responses;

namespace NOTE.Solutions.BLL.Interfaces;

public interface IManagerService
{
    Task<Result<ManagerResponse>> CreateAsync(int companyId, ManagerRequest request, CancellationToken cancellationToken = default);
    Task<Result<IEnumerable<ManagerResponse>>> GetAllAsync(int companyId, CancellationToken cancellationToken = default);
    Task<Result<ManagerResponse>> GetByIdAsync(int managerId, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(int managerId, ManagerRequest request, CancellationToken cancellationToken = default);
    Task<Result> ToggleStatusAsync(int managerId, CancellationToken cancellationToken = default);
}
