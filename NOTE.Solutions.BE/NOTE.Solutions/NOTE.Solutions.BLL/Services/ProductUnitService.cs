using Microsoft.EntityFrameworkCore;
using NOTE.Solutions.Entities.Entities.Product;

namespace NOTE.Solutions.BLL.Services;

public class ProductUnitService(IUnitOfWork unitOfWork) : IProductUnitService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<Result> CreateAsync(int productId, ProductUnitRequest request, CancellationToken cancellationToken = default)
    {
        if (!_unitOfWork.Products.IsExist(x => x.Id == productId))
            return Result.Failure<ProductUnitResponse>(ProductErrors.NotFound);

        var productUnit = request.Adapt<ProductUnit>();
        productUnit.ProductId = productId;

        await _unitOfWork.ProductUnits.AddAsync(productUnit, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);

        return Result.Success();
    }

    public async Task<Result> ToggleStatusAsync(int id, CancellationToken cancellationToken = default)
    {
        var productUnit = await _unitOfWork.ProductUnits.GetByIdAsync(id, cancellationToken);

        if (productUnit is null)
            return Result.Failure(ProductUnitErrors.NotFound);

        productUnit.IsDeleted = !productUnit.IsDeleted;

        await _unitOfWork.SaveAsync(cancellationToken);

        return Result.Success();
    }

    public async Task<Result<IEnumerable<ProductUnitResponse>>> GetAllAsync(int companyId, CancellationToken cancellationToken = default)
    {
        var productUnits = await _unitOfWork.ProductUnits.FindAllAsync(x => x.Product!.CompanyId == companyId, null, cancellationToken);

        return Result.Success(productUnits.Adapt<IEnumerable<ProductUnitResponse>>());
    }

    public async Task<Result<ProductUnitResponse>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var productUnit = await _unitOfWork.ProductUnits.FindAsync(x => x.Id == id, 
            [
                x=>x.Include(w=>w.Unit),
            ] 
            ,cancellationToken);

        if (productUnit is null)
            return Result.Failure<ProductUnitResponse>(ProductUnitErrors.NotFound);

        return Result.Success(productUnit.Adapt<ProductUnitResponse>());
    }

    public async Task<Result> UpdateAsync(int id, ProductUnitRequest request, CancellationToken cancellationToken = default)
    {
        var productUnit = await _unitOfWork.ProductUnits.GetByIdAsync(id, cancellationToken);
        
        if (productUnit is null)
            return Result.Failure(ProductUnitErrors.NotFound);

        request.Adapt(productUnit);

        _unitOfWork.ProductUnits.Update(productUnit);
        await _unitOfWork.SaveAsync(cancellationToken);

        return Result.Success();
    }
}