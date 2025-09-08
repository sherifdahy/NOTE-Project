using NOTE.Solutions.BLL.Contracts.Tax.Requests;
using NOTE.Solutions.BLL.Contracts.Tax.Responses;

namespace NOTE.Solutions.BLL.Interfaces;

public interface ITaxService
{
    Task<Result<IEnumerable<TaxResponse>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<TaxResponse>> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Result<TaxResponse>> CreateAsync(TaxRequest request, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(int id, TaxRequest request, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
