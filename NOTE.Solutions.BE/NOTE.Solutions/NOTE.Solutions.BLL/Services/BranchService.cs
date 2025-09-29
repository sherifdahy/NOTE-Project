using Microsoft.AspNetCore.Http;
using NOTE.Solutions.API.Extensions;
using NOTE.Solutions.Entities.Entities.Address;
using NOTE.Solutions.Entities.Entities.Company;

namespace NOTE.Solutions.BLL.Services;
public class BranchService : IBranchService
{
    private string _cachedKey;
    private int _userId;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICacheService _cacheService;
    private readonly string[] includes = new string[]
    {
        nameof(Branch.Company),
        nameof(Branch.City),
        $"{nameof(Branch.City)}.{nameof(City.Governorate)}",
        $"{nameof(Branch.City)}.{nameof(City.Governorate)}.{nameof(Governorate.Country)}"
    };

    public BranchService(IUnitOfWork unitOfWork, ICacheService cacheService,IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
        _unitOfWork = unitOfWork;
        _cacheService = cacheService;

        _userId = _httpContextAccessor.HttpContext!.User.GetUserId();
        _cachedKey = $"branches_user_{_userId}";
    }

    public async Task<Result> CreateAsync(int companyId,BranchRequest request, CancellationToken cancellationToken = default)
    {
        if (!_unitOfWork.Companies.IsExist(x=>x.Id == companyId))
            return Result.Failure<BranchResponse>(CompanyErrors.NotFound);

        if (!_unitOfWork.Cities.IsExist(x=>x.Id == request.CityId))
            return Result.Failure<BranchResponse>(CityErrors.NotFound);

        if (_unitOfWork.Branches.IsExist(x =>x.Code == request.Code && x.CompanyId == companyId && x.CityId == request.CityId))
            return Result.Failure<BranchResponse>(BranchErrors.Duplicated);

        var branch = request.Adapt<Branch>();

        await _unitOfWork.Branches.AddAsync(branch,cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);

        await _cacheService.RemoveAsync(_cachedKey, cancellationToken);

        return Result.Success();
    }

    public async Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        if (id <= 0)
            return Result.Failure(BranchErrors.InvalidId);

        var branch = await _unitOfWork.Branches.GetByIdAsync(id,cancellationToken);

        if (branch is null)
            return Result.Failure(BranchErrors.NotFound);

        _unitOfWork.Branches.Delete(branch);
        await _unitOfWork.SaveAsync(cancellationToken);

        await _cacheService.RemoveAsync(_cachedKey, cancellationToken);

        return Result.Success();
    }
    
    public async Task<Result<IEnumerable<BranchResponse>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var cachedBranches = await _cacheService.GetAsync<IEnumerable<BranchResponse>>(_cachedKey);

        if (cachedBranches is not null)
            return Result.Success(cachedBranches);

        var branches = await _unitOfWork.Branches.FindAllAsync(x=> x.ApplicationUsers.Any(x=>x.Id == _userId), includes, cancellationToken);

        await _cacheService.SetAsync(_cachedKey, branches.Adapt<IEnumerable<BranchResponse>>(),TimeSpan.FromDays(10));

        return Result.Success(branches.Adapt<IEnumerable<BranchResponse>>());
    }
    public async Task<Result<BranchResponse>> GetById(int id, CancellationToken cancellationToken = default)
    {
        if (id <= 0)
            return Result.Failure<BranchResponse>(BranchErrors.InvalidId);

        var branch = await _unitOfWork.Branches.FindAsync(x=>x.Id == id, includes, cancellationToken);

        if (branch is null)
            return Result.Failure<BranchResponse>(BranchErrors.NotFound);

        return Result.Success(branch.Adapt<BranchResponse>());
    }

    public async Task<Result> UpdateAsync(int id,int companyId, BranchRequest request, CancellationToken cancellationToken = default)
    {
        if (id <= 0)
            return Result.Failure(BranchErrors.InvalidId);

        if (_unitOfWork.Branches.IsExist(x => x.Code == request.Code && x.CompanyId == companyId && x.CityId == request.CityId && x.Id == id))
            return Result.Failure(BranchErrors.Duplicated);

        if (!_unitOfWork.Companies.IsExist(x => x.Id ==  companyId))
            return Result.Failure(CompanyErrors.NotFound);

        if (!_unitOfWork.Cities.IsExist(x => x.Id == request.CityId))
            return Result.Failure(CityErrors.NotFound);

        var branch = await _unitOfWork.Branches.GetByIdAsync(id,cancellationToken);
        if (branch is null)
            return Result.Failure(BranchErrors.NotFound);

        request.Adapt(branch);

        _unitOfWork.Branches.Update(branch);
        await _unitOfWork.SaveAsync(cancellationToken);

        await _cacheService.RemoveAsync(_cachedKey,cancellationToken);
        
        return Result.Success();
    }

}
