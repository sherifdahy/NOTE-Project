using Microsoft.AspNetCore.Mvc;
using NOTE.Solutions.BLL.Contracts.Common;

namespace NOTE.Solutions.BLL.Interfaces;

public interface IBranchService
{
    Task<Result<IEnumerable<BranchResponse>>> GetAllAsync(int companyId, CancellationToken cancellationToken = default);
    Task<Result<BranchDetailResponse>> GetById(int id, CancellationToken cancellationToken = default);
    Task<Result<BranchResponse>> CreateAsync(int companyId, BranchRequest request, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(int id, BranchRequest request, CancellationToken cancellationToken = default);
    Task<Result> ToggleStatusAsync(int id, CancellationToken cancellationToken = default);
}