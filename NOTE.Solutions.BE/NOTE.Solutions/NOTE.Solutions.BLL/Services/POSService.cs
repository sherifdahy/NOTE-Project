using NOTE.Solutions.BLL.Contracts.POS.Requests;
using NOTE.Solutions.BLL.Contracts.POS.Responses;
using NOTE.Solutions.Entities.Entities.Company;

namespace NOTE.Solutions.BLL.Services;

public class POSService(IUnitOfWork unitOfWork) : IPOSService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly string[] _includes = [nameof(Branch.POSs)];
    public async Task<Result<POSResponse>> CreateAsync(int branchId, POSRequest request, CancellationToken cancellationToken = default)
    {
        var branch = await _unitOfWork.Branches.FindAsync(x=>x.Id == branchId,_includes,cancellationToken);

        if (branch is null)
            return Result.Failure<POSResponse>(BranchErrors.NotFound);

        var existPOS = branch.POSs.FirstOrDefault(x=>x.POSSerial == request.POSSerial);

        if (existPOS is not null)
            return Result.Failure<POSResponse>(POSErrors.Duplicated);

        var pos = request.Adapt<POS>();
        
        branch.POSs.Add(pos);

        _unitOfWork.Branches.Update(branch);
        await _unitOfWork.SaveAsync();

        return Result.Success<POSResponse>(pos.Adapt<POSResponse>());
    }

    public Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {

        throw new NotImplementedException();
    }

    public async Task<Result<IEnumerable<POSResponse>>> GetAllAsync(int branchId, CancellationToken cancellationToken = default)
    {
        var branch = await _unitOfWork.Branches.FindAsync(x => x.Id == branchId, _includes, cancellationToken);

        if (branch is null)
            return Result.Failure<IEnumerable<POSResponse>>(BranchErrors.NotFound);

        return Result.Success(branch.POSs.Adapt<IEnumerable<POSResponse>>());
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
