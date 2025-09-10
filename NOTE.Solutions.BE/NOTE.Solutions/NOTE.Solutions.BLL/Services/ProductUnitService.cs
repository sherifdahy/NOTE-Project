using NOTE.Solutions.Entities.Entities.Product;

namespace NOTE.Solutions.BLL.Services;

public class ProductUnitService(IUnitOfWork unitOfWork) : IProductUnitService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private string[] _includes = new string[]
    {
        nameof(ProductUnit.Unit)
    };


    public async Task<Result<ProductUnitResponse>> CreateAsync(int productId, ProductUnitRequest request, CancellationToken cancellationToken = default)
    {
        if (productId <= 0)
            return Result.Failure<ProductUnitResponse>(ProductUnitErrors.InvalidId);

        if (!_unitOfWork.Products.IsExist(x => x.Id == productId))
            return Result.Failure<ProductUnitResponse>(ProductErrors.NotFound);

        // Unique constraints checks
        if (_unitOfWork.ProductUnits.IsExist(x => x.ProductId == productId && x.UnitId == request.UnitId))
            return Result.Failure<ProductUnitResponse>(ProductUnitErrors.Duplicated);
        if (_unitOfWork.ProductUnits.IsExist(x => x.ProductId == productId && x.InternalCode == request.InternalCode))
            return Result.Failure<ProductUnitResponse>(ProductUnitErrors.DuplicatedInternalCode);
        if (_unitOfWork.ProductUnits.IsExist(x => x.GlobalCode == request.GlobalCode && x.GlobalCodeType == request.GlobalCodeType))
            return Result.Failure<ProductUnitResponse>(ProductUnitErrors.DuplicatedGlobalCode);

        var productUnit = request.Adapt<ProductUnit>();
        productUnit.ProductId = productId;

        await _unitOfWork.ProductUnits.AddAsync(productUnit, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);

        productUnit = await _unitOfWork.ProductUnits.FindAsync(x => x.Id == productUnit.Id, _includes, cancellationToken);

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

    public async Task<Result<IEnumerable<ProductUnitResponse>>> GetAllAsync(int productId, CancellationToken cancellationToken = default)
    {
        var productUnits = await _unitOfWork.ProductUnits.FindAllAsync(x => x.ProductId == productId, null);

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

        // Unique constraints checks (exclude current record)
        if (_unitOfWork.ProductUnits.IsExist(x => x.Id != id && x.ProductId == productUnit.ProductId && x.UnitId == request.UnitId))
            return Result.Failure(ProductUnitErrors.Duplicated);
        if (_unitOfWork.ProductUnits.IsExist(x => x.Id != id && x.ProductId == productUnit.ProductId && x.InternalCode == request.InternalCode))
            return Result.Failure(ProductUnitErrors.DuplicatedInternalCode);
        if (_unitOfWork.ProductUnits.IsExist(x => x.Id != id && x.GlobalCode == request.GlobalCode && x.GlobalCodeType == request.GlobalCodeType))
            return Result.Failure(ProductUnitErrors.DuplicatedGlobalCode);

        request.Adapt(productUnit);

        _unitOfWork.ProductUnits.Update(productUnit);
        await _unitOfWork.SaveAsync(cancellationToken);

        return Result.Success();
    }
}