using NOTE.Solutions.BLL.Contracts.Product.Requests;
using NOTE.Solutions.BLL.Contracts.Product.Responses;
using NOTE.Solutions.Entities.Entities.Product;
using Mapster;
using NOTE.Solutions.BLL.Errors;

namespace NOTE.Solutions.BLL.Services;

public class ProductService(IUnitOfWork unitOfWork) : IProductService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<ProductResponse>> CreateAsync(int branchId, ProductRequest request, CancellationToken cancellationToken = default)
    {
        if(!_unitOfWork.Branches.IsExist(x => x.Id == branchId))
            return Result.Failure<ProductResponse>(BranchErrors.NotFound);

        if (_unitOfWork.Products.IsExist(x => x.Name == request.Name && x.BranchId == branchId))
            return Result.Failure<ProductResponse>(ProductErrors.Duplicated);

        foreach(var productUnit in request.ProductUnits)
        {
            if (!_unitOfWork.Units.IsExist(x => x.Id == productUnit.UnitId))
            {
                return Result.Failure<ProductResponse>(UnitErrors.NotFound);
            }
        }

        var product = request.Adapt<Product>();
        product.BranchId = branchId;

        await _unitOfWork.Products.AddAsync(product, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);

        return Result.Success(product.Adapt<ProductResponse>());
    }

    public async Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        if (id <= 0)
            return Result.Failure(ProductErrors.InvalidId);

        var product = await _unitOfWork.Products.GetByIdAsync(id, cancellationToken);

        if (product is null)
            return Result.Failure(ProductErrors.NotFound);

        _unitOfWork.Products.Delete(product);
        await _unitOfWork.SaveAsync(cancellationToken);

        return Result.Success();
    }

    public async Task<Result<IEnumerable<ProductResponse>>> GetAllAsync(int branchId, CancellationToken cancellationToken = default)
    {
        if (!_unitOfWork.Branches.IsExist(x => x.Id == branchId))
            return Result.Failure<IEnumerable<ProductResponse>>(BranchErrors.NotFound);

        var products = await _unitOfWork.Products.FindAllAsync(x => x.BranchId == branchId, null);
        return Result.Success(products.Adapt<IEnumerable<ProductResponse>>());
    }

    public async Task<Result<ProductResponse>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        if (id <= 0)
            return Result.Failure<ProductResponse>(ProductErrors.InvalidId);

        var product = await _unitOfWork.Products.FindAsync(x => x.Id == id, null);

        if (product is null)
            return Result.Failure<ProductResponse>(ProductErrors.NotFound);

        return Result.Success(product.Adapt<ProductResponse>());
    }

    public async Task<Result> UpdateAsync(int id, ProductRequest request, CancellationToken cancellationToken = default)
    {
        if (id <= 0)
            return Result.Failure(ProductErrors.InvalidId);

        if (_unitOfWork.Products.IsExist(x => x.Name == request.Name))
            return Result.Failure(ProductErrors.Duplicated);

        var product = await _unitOfWork.Products.GetByIdAsync(id, cancellationToken);

        if (product is null)
            return Result.Failure(ProductErrors.NotFound);

        request.Adapt(product);

        _unitOfWork.Products.Update(product);
        await _unitOfWork.SaveAsync(cancellationToken);

        return Result.Success();
    }
}