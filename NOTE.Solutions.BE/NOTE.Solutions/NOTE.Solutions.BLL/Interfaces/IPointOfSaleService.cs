using NOTE.Solutions.BLL.Contracts.POS.Requests;
using NOTE.Solutions.BLL.Contracts.POS.Responses;

namespace NOTE.Solutions.BLL.Interfaces;

public interface IPointOfSaleService
{
    Task<Result<IEnumerable<PointOfSaleResponse>>> GetAllAsync(int branchId,CancellationToken cancellationToken = default);
    Task<Result<PointOfSaleResponse>> GetById(int id, CancellationToken cancellationToken = default);
    Task<Result<PointOfSaleResponse>> CreateAsync(int branchId,PointOfSaleRequest request, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(int id,PointOfSaleRequest request, CancellationToken cancellationToken = default);
    Task<Result> ToggleStatusAsync(int id, CancellationToken cancellationToken = default);
}
