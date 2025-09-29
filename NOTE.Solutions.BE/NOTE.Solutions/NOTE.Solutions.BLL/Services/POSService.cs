using Microsoft.AspNetCore.Http;
using NOTE.Solutions.API.Extensions;
using NOTE.Solutions.BLL.Contracts.POS.Requests;
using NOTE.Solutions.BLL.Contracts.POS.Responses;
using NOTE.Solutions.Entities.Entities.Company;

namespace NOTE.Solutions.BLL.Services;

public class POSService : IPOSService
{
    private int _userId; 

    private readonly ICacheService _cacheService;
    private readonly IUnitOfWork _unitOfWork;

    public POSService(IUnitOfWork unitOfWork,ICacheService cacheService)
    {
        _unitOfWork = unitOfWork;
        _cacheService = cacheService;

    }
    public async Task<Result<POSResponse>> CreateAsync(int branchId, POSRequest request, CancellationToken cancellationToken = default)
    {
        var branch = await _unitOfWork.Branches.FindAsync(x=>x.Id == branchId,cancellationToken:cancellationToken);

        if (branch is null)
            return Result.Failure<POSResponse>(BranchErrors.NotFound);

        var existPOS = branch.POSs.FirstOrDefault(x=>x.POSSerial == request.POSSerial);

        if (existPOS is not null)
            return Result.Failure<POSResponse>(POSErrors.Duplicated);

        var pos = request.Adapt<POS>();
        
        branch.POSs.Add(pos);

        _unitOfWork.Branches.Update(branch);
        await _unitOfWork.SaveAsync();

        var _cachedKey = $"branch_{branchId}_poss";

        await _cacheService.RemoveAsync(_cachedKey);

        return Result.Success<POSResponse>(pos.Adapt<POSResponse>());
    }

    public Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {

        throw new NotImplementedException();
    }

    public async Task<Result<IEnumerable<POSResponse>>> GetAllAsync(int branchId, CancellationToken cancellationToken = default)
    {
        var _cachedKey = $"branch_{branchId}_poss";

        var cachedPoss = await _cacheService.GetAsync<IEnumerable<POSResponse>>(_cachedKey);

        if(cachedPoss is not null)
            return Result.Success(cachedPoss);

        var pointsOfSale = await _unitOfWork.POSs.FindAllAsync(x => x.BranchId == branchId, cancellationToken: cancellationToken);

        if (pointsOfSale is null)
            return Result.Failure<IEnumerable<POSResponse>>(BranchErrors.NotFound);

        await _cacheService.SetAsync(_cachedKey, pointsOfSale.Adapt<IEnumerable<POSResponse>>());

        return Result.Success(pointsOfSale.Adapt<IEnumerable<POSResponse>>());
    }

    public Task<Result<POSResponse>> GetById(int id, CancellationToken cancellationToken = default)
    {

        throw new NotImplementedException();
    }

    public Task<Result> UpdateAsync(int id, int branchId, POSRequest request, CancellationToken cancellationToken = default)
    {

        throw new NotImplementedException();
    }
}
