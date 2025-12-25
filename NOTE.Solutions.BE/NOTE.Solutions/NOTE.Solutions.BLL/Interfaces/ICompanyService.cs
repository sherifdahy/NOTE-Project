using NOTE.Solutions.BLL.Contracts.Common;

namespace NOTE.Solutions.BLL.Interfaces;
public interface ICompanyService
{
    Task<Result<PaginatedList<CompanyResponse>>> GetAllAsync(RequestFilters filters, bool? includeDisabled, CancellationToken cancellationToken = default);
    Task<Result<CompanyDetailResponse>> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Result<CompanyResponse>> CreateAsync(CompanyRequest request, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(int id, CompanyRequest request, CancellationToken cancellationToken = default);
    Task<Result> ToggleStatusAsync(int id, CancellationToken cancellationToken = default);
    Task<Result> AddActiveCodeAsync(int companyId, int activeCodeId, CancellationToken cancellationToken = default);
    Task<Result> RemoveActiveCodeAsync(int companyId, int activeCodeId, CancellationToken cancellationToken = default);
}
