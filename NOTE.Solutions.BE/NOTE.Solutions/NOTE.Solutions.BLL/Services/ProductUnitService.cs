using NOTE.Solutions.BLL.Contracts.ProductUnit.Requests;
using NOTE.Solutions.BLL.Contracts.ProductUnit.Responses;
using NOTE.Solutions.Entities.Entities.Product;
using Mapster;
using NOTE.Solutions.BLL.Errors;

namespace NOTE.Solutions.BLL.Services;

public class ProductUnitService(IUnitOfWork unitOfWork) : IProductUnitService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<ProductUnitResponse>> CreateAsync(ProductUnitRequest request, CancellationToken cancellationToken = default)
    {
        if (_unitOfWork.ProductUnits.IsExist(x => x.InternalCode == request.InternalCode && x.ProductId == request.ProductId))
            return Result.Failure<ProductUnitResponse>(ProductUnitErrors.Duplicated);

        var productUnit = request.Adapt<ProductUnit>();

        await _unitOfWork.ProductUnits.AddAsync(productUnit, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);

        return Result.Success(productUnit.Adapt<ProductUnitResponse>());
    }

    public async Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        if (id <= 0)
            return Result.Failure(ProductUnitErrors.InvalidId);

        var productUnit = await _unitOfWork.ProductUnits.GetByIdAsync(id, cancellationToken);

        if (productUnit is null)
            return Result.Failure(ProductUnitErrors.NotFound);

        _unitOfWork.ProductUnits.Delete(productUnit);
        await _unitOfWork.SaveAsync(cancellationToken);

        return Result.Success();
    }

    public async Task<Result<IEnumerable<ProductUnitResponse>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var productUnits = await _unitOfWork.ProductUnits.FindAllAsync(x => true, null);

        return Result.Success(productUnits.Adapt<IEnumerable<ProductUnitResponse>>());
    }

    public async Task<Result<ProductUnitResponse>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        if (id <= 0)
            return Result.Failure<ProductUnitResponse>(ProductUnitErrors.InvalidId);

        var productUnit = await _unitOfWork.ProductUnits.FindAsync(x => x.Id == id, null);

        if (productUnit is null)
            return Result.Failure<ProductUnitResponse>(ProductUnitErrors.NotFound);

        return Result.Success(productUnit.Adapt<ProductUnitResponse>());
    }

    public async Task<Result> UpdateAsync(int id, ProductUnitRequest request, CancellationToken cancellationToken = default)
    {
        if (id <= 0)
            return Result.Failure(ProductUnitErrors.InvalidId);

        var productUnit = await _unitOfWork.ProductUnits.GetByIdAsync(id, cancellationToken);

        if (productUnit is null)
            return Result.Failure(ProductUnitErrors.NotFound);

        request.Adapt(productUnit);

        _unitOfWork.ProductUnits.Update(productUnit);
        await _unitOfWork.SaveAsync(cancellationToken);

        return Result.Success();
    }
}