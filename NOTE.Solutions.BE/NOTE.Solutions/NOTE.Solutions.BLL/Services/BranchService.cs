using Microsoft.EntityFrameworkCore;

namespace NOTE.Solutions.BLL.Services;

public class BranchService(IUnitOfWork unitOfWork) : IBranchService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<Result<BranchResponse>> CreateAsync(int companyId, BranchRequest request, CancellationToken cancellationToken = default)
    {
        if (!_unitOfWork.Companies.IsExist(x => x.Id == companyId))
            return Result.Failure<BranchResponse>(CompanyErrors.NotFound);

        if (!_unitOfWork.Cities.IsExist(x => x.Id == request.CityId))
            return Result.Failure<BranchResponse>(CityErrors.NotFound);

        if (_unitOfWork.Branches.IsExist(x => x.Code == request.Code && x.CompanyId == companyId && x.CityId == request.CityId))
            return Result.Failure<BranchResponse>(BranchErrors.Duplicated);

        var branch = request.Adapt<Branch>();
        branch.CompanyId = companyId;

        await _unitOfWork.Branches.AddAsync(branch, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);

        return Result.Success(branch.Adapt<BranchResponse>());
    }
    public async Task<Result> ToggleStatusAsync(int id, CancellationToken cancellationToken = default)
    {
        var branch = await _unitOfWork.Branches.GetByIdAsync(id, cancellationToken);

        if (branch is null)
            return Result.Failure(BranchErrors.NotFound);

        branch.IsDeleted = !branch.IsDeleted;

        _unitOfWork.Branches.Update(branch);

        await _unitOfWork.SaveAsync(cancellationToken);

        return Result.Success();
    }
    public async Task<Result<IEnumerable<BranchResponse>>> GetAllAsync(int companyId,CancellationToken cancellationToken = default)
    {
        var branches = await _unitOfWork.Branches.FindAllAsync(x => x.CompanyId == companyId, null, cancellationToken);

        return Result.Success(branches.Adapt<IEnumerable<BranchResponse>>());
    }
    public async Task<Result<BranchDetailResponse>> GetById(int id, CancellationToken cancellationToken = default)
    {
        var branch = await _unitOfWork.Branches.FindAsync(x => x.Id == id, 
        [
            x=>x.Include(w=>w.PointOfSales.Where(r=>!r.IsDeleted)),
            x=>x.Include(w=>w.City).ThenInclude(d=>d.Governorate).ThenInclude(s=>s.Country)
        ]
        , cancellationToken);

        if (branch is null)
            return Result.Failure<BranchDetailResponse>(BranchErrors.NotFound);

        return Result.Success(branch.Adapt<BranchDetailResponse>());
    }
    public async Task<Result> UpdateAsync(int id, BranchRequest request, CancellationToken cancellationToken = default)
    {
        var branch = await _unitOfWork.Branches.FindAsync(x=>x.Id ==  id, null, cancellationToken);
        
        if (branch is null)
            return Result.Failure(BranchErrors.NotFound);

        if (branch.Code == request.Code && branch.CityId == request.CityId && branch.Id == id)
            return Result.Failure(BranchErrors.Duplicated);

        if (!_unitOfWork.Cities.IsExist(x => x.Id == request.CityId))
            return Result.Failure(CityErrors.NotFound);

        request.Adapt(branch);

        _unitOfWork.Branches.Update(branch);
        await _unitOfWork.SaveAsync(cancellationToken);

        return Result.Success();
    }
}