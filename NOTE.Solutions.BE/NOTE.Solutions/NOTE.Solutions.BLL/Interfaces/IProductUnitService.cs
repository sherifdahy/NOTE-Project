namespace NOTE.Solutions.BLL.Interfaces;

public interface IProductUnitService
{
    Task<Result<IEnumerable<ProductUnitResponse>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<ProductUnitResponse>> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Result<ProductUnitResponse>> CreateAsync(ProductUnitRequest request, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(int id, ProductUnitRequest request, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
