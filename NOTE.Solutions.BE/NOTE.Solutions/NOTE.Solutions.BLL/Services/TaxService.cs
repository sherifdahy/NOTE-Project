using NOTE.Solutions.BLL.Contracts.Tax.Requests;
using NOTE.Solutions.BLL.Contracts.Tax.Responses;
using NOTE.Solutions.BLL.Errors;
using NOTE.Solutions.Entities.Entities.Document;
using Mapster;

namespace NOTE.Solutions.BLL.Services;

public class TaxService(IUnitOfWork unitOfWork) : ITaxService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<TaxResponse>> CreateAsync(TaxRequest request, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(request.Code) || request.Code.Length > 50)
            return Result.Failure<TaxResponse>(TaxErrors.InvalidCode);
        if (_unitOfWork.Taxes.IsExist(x => x.Code == request.Code))
            return Result.Failure<TaxResponse>(TaxErrors.Duplicated);

        var tax = request.Adapt<Tax>();
        await _unitOfWork.Taxes.AddAsync(tax, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);
        return Result.Success(tax.Adapt<TaxResponse>());
    }

    public async Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        if (id <= 0)
            return Result.Failure(TaxErrors.InvalidId);
        var tax = await _unitOfWork.Taxes.GetByIdAsync(id, cancellationToken);
        if (tax is null)
            return Result.Failure(TaxErrors.NotFound);
        _unitOfWork.Taxes.Delete(tax);
        await _unitOfWork.SaveAsync(cancellationToken);
        return Result.Success();
    }

    public async Task<Result<IEnumerable<TaxResponse>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var taxes = await _unitOfWork.Taxes.FindAllAsync(x => true, null);
        return Result.Success(taxes.Adapt<IEnumerable<TaxResponse>>());
    }

    public async Task<Result<TaxResponse>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        if (id <= 0)
            return Result.Failure<TaxResponse>(TaxErrors.InvalidId);
        var tax = await _unitOfWork.Taxes.FindAsync(x => x.Id == id, null);
        if (tax is null)
            return Result.Failure<TaxResponse>(TaxErrors.NotFound);
        return Result.Success(tax.Adapt<TaxResponse>());
    }

    public async Task<Result> UpdateAsync(int id, TaxRequest request, CancellationToken cancellationToken = default)
    {
        if (id <= 0)
            return Result.Failure(TaxErrors.InvalidId);

        if(_unitOfWork.Taxes.IsExist(x => x.Code == request.Code && x.Id != id))
            return Result.Failure(TaxErrors.Duplicated);

        var tax = await _unitOfWork.Taxes.GetByIdAsync(id, cancellationToken);
        
        if (tax is null)
            return Result.Failure(TaxErrors.NotFound);
        
        request.Adapt(tax);
        
        _unitOfWork.Taxes.Update(tax);
        
        await _unitOfWork.SaveAsync(cancellationToken);
        
        return Result.Success();
    }
}
