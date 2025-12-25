using Microsoft.EntityFrameworkCore;
using NOTE.Solutions.BLL.Contracts.POS.Requests;
using NOTE.Solutions.BLL.Contracts.POS.Responses;

namespace NOTE.Solutions.BLL.Services;

public class PointOfSaleService : IPointOfSaleService
{
    private readonly IUnitOfWork _unitOfWork;

    public PointOfSaleService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<PointOfSaleResponse>> CreateAsync(int branchId, PointOfSaleRequest request, CancellationToken cancellationToken = default)
    {
        var branch = await _unitOfWork.Branches.FindAsync(x=>x.Id == branchId, [x=>x.Include(w=>w.PointOfSales.Where(d=>!d.IsDeleted))],cancellationToken);

        if (branch is null)
            return Result.Failure<PointOfSaleResponse>(BranchErrors.NotFound);

        if (branch.PointOfSales.Any(x => x.POSSerial == request.POSSerial))
            return Result.Failure<PointOfSaleResponse>(POSErrors.Duplicated);

        var pos = request.Adapt<POS>();
        pos.BranchId = branchId;
        
        await _unitOfWork.POSs.AddAsync(pos);
        await _unitOfWork.SaveAsync(cancellationToken);

        return Result.Success(pos.Adapt<PointOfSaleResponse>());
    }

    public async Task<Result> ToggleStatusAsync(int id, CancellationToken cancellationToken = default)
    {
        var pos = await _unitOfWork.POSs.GetByIdAsync(id,cancellationToken);
        
        if(pos is null)
            return Result.Failure(POSErrors.NotFound);

        pos.IsDeleted = !pos.IsDeleted;

        _unitOfWork.POSs.Update(pos);
        await _unitOfWork.SaveAsync(cancellationToken);

        return Result.Success();
    }

    public async Task<Result<IEnumerable<PointOfSaleResponse>>> GetAllAsync(int branchId, CancellationToken cancellationToken = default)
    {
        var pointsOfSale = await _unitOfWork.POSs.FindAllAsync(x => x.BranchId == branchId,null,cancellationToken);

        return Result.Success(pointsOfSale.Adapt<IEnumerable<PointOfSaleResponse>>());
    }

    public async Task<Result<PointOfSaleResponse>> GetById(int id, CancellationToken cancellationToken = default)
    {
        var pos = await _unitOfWork.POSs.GetByIdAsync(id, cancellationToken);

        if(pos is null)
            return Result.Failure<PointOfSaleResponse>(POSErrors.NotFound);

        return Result.Success(pos.Adapt<PointOfSaleResponse>());
    }

    public async Task<Result> UpdateAsync(int id,PointOfSaleRequest request, CancellationToken cancellationToken = default)
    {
        var pos = await _unitOfWork.POSs.GetByIdAsync(id,cancellationToken);

        if(pos is null)
            return Result.Failure(POSErrors.NotFound);

        request.Adapt(pos);

        _unitOfWork.POSs.Update(pos);
        await _unitOfWork.SaveAsync(cancellationToken);

        return Result.Success();
    }
}
