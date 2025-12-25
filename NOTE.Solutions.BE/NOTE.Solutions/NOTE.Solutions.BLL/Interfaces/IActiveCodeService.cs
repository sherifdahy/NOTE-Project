
using NOTE.Solutions.BLL.Contracts.Common;

namespace NOTE.Solutions.BLL.Interfaces;

public interface IActiveCodesService
{
    Task<Result<PaginatedList<ActiveCodeResponse>>> GetAllAsync(RequestFilters filters, bool? includeDisabled, CancellationToken cancellationToken = default);
    Task<Result<ActiveCodeResponse>> GetById(int id, CancellationToken cancellationToken = default);
    Task<Result<ActiveCodeResponse>> CreateAsync(ActiveCodeRequest request, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(int id, ActiveCodeRequest request, CancellationToken cancellationToken = default);
    Task<Result> ToggleStatusAsync(int id, CancellationToken cancellationToken = default);
}
