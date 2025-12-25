using NOTE.Solutions.BLL.Contracts.Common;
using System.Linq.Expressions;

namespace NOTE.Solutions.BLL.Services;

public class ActiveCodeService : IActiveCodesService
{
    private readonly IUnitOfWork _unitOfWork;
    public ActiveCodeService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<ActiveCodeResponse>> CreateAsync(ActiveCodeRequest request, CancellationToken cancellationToken = default)
    {
        if(_unitOfWork.ActiveCodes.IsExist(x => x.Code == request.Code))
            return Result.Failure<ActiveCodeResponse>(ActiveCodeErrors.Duplicated);

        var activeCode = request.Adapt<ActiveCode>();

        await _unitOfWork.ActiveCodes.AddAsync(activeCode,cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);

        return Result.Success(activeCode.Adapt<ActiveCodeResponse>());
    }
   
    public async Task<Result> ToggleStatusAsync(int id, CancellationToken cancellationToken = default)
    {
        var activeCode = await _unitOfWork.ActiveCodes.GetByIdAsync(id, cancellationToken);

        if (activeCode is null)
            return Result.Failure(ActiveCodeErrors.NotFound);

        activeCode.IsDeleted = !activeCode.IsDeleted;

        _unitOfWork.ActiveCodes.Update(activeCode);
        await _unitOfWork.SaveAsync(cancellationToken);

        return Result.Success();
    }

    public async Task<Result<PaginatedList<ActiveCodeResponse>>> GetAllAsync(RequestFilters filters, bool? includeDisabled, CancellationToken cancellationToken = default)
    {
        Expression<Func<ActiveCode, bool>> query = x => (string.IsNullOrEmpty(filters.SearchValue) || x.Code.Contains(filters.SearchValue)) && (includeDisabled.HasValue && x.IsDeleted == includeDisabled);

        var count = await _unitOfWork.ActiveCodes.CountAsync(query);

        var activeCodes = await _unitOfWork.ActiveCodes.FindAllAsync(query, (filters.PageNumber - 1) * filters.PageSize,filters.PageSize,filters.SortColumn,filters.SortDirection,cancellationToken: cancellationToken);

        return Result.Success(PaginatedList<ActiveCodeResponse>.Create(activeCodes.Adapt<List<ActiveCodeResponse>>(),count,filters.PageNumber,filters.PageNumber));
    }
    public async Task<Result<ActiveCodeResponse>> GetById(int id, CancellationToken cancellationToken = default)
    {
        var activeCode = await _unitOfWork.ActiveCodes.FindAsync(x => x.Id == id, cancellationToken: cancellationToken);

        if (activeCode is null)
            return Result.Failure<ActiveCodeResponse>(ActiveCodeErrors.NotFound);

        return Result.Success(activeCode.Adapt<ActiveCodeResponse>());
    }

    public async Task<Result> UpdateAsync(int id, ActiveCodeRequest request, CancellationToken cancellationToken = default)
    {
        var activeCode = await _unitOfWork.ActiveCodes.GetByIdAsync(id,cancellationToken);
        
        if (activeCode is null)
            return Result.Failure(ActiveCodeErrors.NotFound);

        request.Adapt(activeCode);

        _unitOfWork.ActiveCodes.Update(activeCode);
        await _unitOfWork.SaveAsync(cancellationToken);

        return Result.Success();
    }

    
}
