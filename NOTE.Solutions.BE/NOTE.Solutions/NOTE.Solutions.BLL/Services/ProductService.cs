using NOTE.Solutions.Entities.Entities.Product;

namespace NOTE.Solutions.BLL.Services;

public class ProductService(IUnitOfWork unitOfWork) : IProductService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<ProductResponse>> CreateAsync(int companyId, ProductRequest request, CancellationToken cancellationToken = default)
    {
        if(!_unitOfWork.Companies.IsExist(x => x.Id == companyId))
            return Result.Failure<ProductResponse>(CompanyErrors.NotFound);

        if (_unitOfWork.Products.IsExist(x => x.Name == request.Name && x.CompanyId == companyId))
            return Result.Failure<ProductResponse>(ProductErrors.Duplicated);

        var product = request.Adapt<Product>();
        product.CompanyId = companyId;

        await _unitOfWork.Products.AddAsync(product, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);

        return Result.Success(product.Adapt<ProductResponse>());
    }

    public async Task<Result> ToggleStatusAsync(int id, CancellationToken cancellationToken = default)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(id, cancellationToken);

        if (product is null)
            return Result.Failure(ProductErrors.NotFound);

        product.IsDeleted = !product.IsDeleted;

        _unitOfWork.Products.Update(product);
        await _unitOfWork.SaveAsync(cancellationToken);

        return Result.Success();
    }

    public async Task<Result<IEnumerable<ProductResponse>>> GetAllAsync(int companyId, CancellationToken cancellationToken = default)
    {
        if (!_unitOfWork.Companies.IsExist(x => x.Id == companyId))
            return Result.Failure<IEnumerable<ProductResponse>>(CompanyErrors.NotFound);

        var products = await _unitOfWork.Products.FindAllAsync(x => x.CompanyId == companyId,null,cancellationToken);
        return Result.Success(products.Adapt<IEnumerable<ProductResponse>>());
    }

    public async Task<Result<ProductResponse>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var product = await _unitOfWork.Products.FindAsync(x => x.Id == id, null);

        if (product is null)
            return Result.Failure<ProductResponse>(ProductErrors.NotFound);

        return Result.Success(product.Adapt<ProductResponse>());
    }

    public async Task<Result> UpdateAsync(int id,int companyId,ProductRequest request, CancellationToken cancellationToken = default)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(id, cancellationToken);

        if (product is null)
            return Result.Failure(ProductErrors.NotFound);

        if (_unitOfWork.Products.IsExist(x => x.Name == request.Name && x.CompanyId == companyId))
            return Result.Failure(ProductErrors.Duplicated);
        
        request.Adapt(product);

        _unitOfWork.Products.Update(product);
        await _unitOfWork.SaveAsync(cancellationToken);

        return Result.Success();
    }
}