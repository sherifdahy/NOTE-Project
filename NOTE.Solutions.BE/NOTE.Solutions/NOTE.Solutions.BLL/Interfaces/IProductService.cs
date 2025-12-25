
namespace NOTE.Solutions.BLL.Interfaces;

public interface IProductService
{
    Task<Result<IEnumerable<ProductResponse>>> GetAllAsync(int companyId, CancellationToken cancellationToken = default);
    Task<Result<ProductResponse>> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Result<ProductResponse>> CreateAsync(int companyId, ProductRequest request, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(int id, int companyId, ProductRequest request, CancellationToken cancellationToken = default);
    Task<Result> ToggleStatusAsync(int id, CancellationToken cancellationToken = default);
}
