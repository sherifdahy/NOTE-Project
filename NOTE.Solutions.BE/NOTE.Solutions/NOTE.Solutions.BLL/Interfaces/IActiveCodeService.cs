using NOTE.Solutions.BLL.Contracts.ActiveCode.Requests;
using NOTE.Solutions.BLL.Contracts.ActiveCode.Responses;

namespace NOTE.Solutions.BLL.Interfaces;

public interface IActiveCodeService
{
    Task<Result<IEnumerable<ActiveCodeResponse>>> GetAllAsync(int companyId,CancellationToken cancellationToken = default);
    Task<Result<ActiveCodeResponse>> GetById(int id, CancellationToken cancellationToken = default);
    Task<Result<ActiveCodeResponse>> CreateAsync(int companyId,ActiveCodeRequest request, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(int id, ActiveCodeRequest request, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
