﻿namespace NOTE.Solutions.BLL.Interfaces;
public interface IBranchService
{
    Task<Result<IEnumerable<BranchResponse>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<BranchResponse>> GetById(int id, CancellationToken cancellationToken = default);
    Task<Result<BranchResponse>> CreateAsync(int companyId, BranchRequest request, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(int id, int companyId, BranchRequest request, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
