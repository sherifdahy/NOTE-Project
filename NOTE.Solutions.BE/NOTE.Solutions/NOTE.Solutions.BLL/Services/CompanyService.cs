using NOTE.Solutions.BLL.Contracts.Common;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
namespace NOTE.Solutions.BLL.Services;

public class CompanyService(IUnitOfWork unitOfWork) : ICompanyService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<Result<CompanyResponse>> CreateAsync(CompanyRequest request, CancellationToken cancellationToken = default)
    {
        if (_unitOfWork.Companies.IsExist(x => x.RIN == request.RIN))
            return Result.Failure<CompanyResponse>(CompanyErrors.Duplicated);

        var company = new Company()
        {
            Name = request.Name,
            RIN = request.RIN,
        };

        await _unitOfWork.Companies.AddAsync(company, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);
        
        return Result.Success(company.Adapt<CompanyResponse>());
    }
    public async Task<Result> ToggleStatusAsync(int id, CancellationToken cancellationToken = default)
    {
        var company = await _unitOfWork.Companies.GetByIdAsync(id, cancellationToken);

        if (company is null)
            return Result.Failure(CompanyErrors.NotFound);

        company.IsDeleted = !company.IsDeleted;

        _unitOfWork.Companies.Update(company);
        await _unitOfWork.SaveAsync(cancellationToken);

        return Result.Success();
    }
    public async Task<Result<PaginatedList<CompanyResponse>>> GetAllAsync(RequestFilters filters,bool? includeDisabled,CancellationToken cancellationToken = default)
    {
        Expression<Func<Company,bool>> query = x=> (string.IsNullOrEmpty(filters.SearchValue) || x.Name.Contains(filters.SearchValue)) && (includeDisabled.HasValue && x.IsDeleted == includeDisabled);

        var count = await _unitOfWork.Companies.CountAsync(query,cancellationToken);
        
        var filteredCompanies = await _unitOfWork.Companies.FindAllAsync(query, (filters.PageNumber - 1 ) * filters.PageSize,filters.PageSize,filters.SortColumn,filters.SortDirection, cancellationToken);
        
        return Result.Success(PaginatedList<CompanyResponse>.Create(filteredCompanies.Adapt<List<CompanyResponse>>(), count, filters.PageNumber,filters.PageSize));
    }
    public async Task<Result<CompanyDetailResponse>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var company = await _unitOfWork.Companies.FindAsync(
            x => x.Id == id, 
            [
                x=>x.Include(w=>w.ActiveCodeCompanies.Where(s=>!s.ActiveCode.IsDeleted)).ThenInclude(y=>y.ActiveCode),
                x=>x.Include(w=>w.Branches.Where(w=>!w.IsDeleted))
            ],cancellationToken
        );

        if (company is null)
            return Result.Failure<CompanyDetailResponse>(CompanyErrors.NotFound);

        return Result.Success(company.Adapt<CompanyDetailResponse>());
    }
    public async Task<Result> AddActiveCodeAsync(int companyId, int activeCodeId, CancellationToken cancellationToken = default)
    {
        var company = await _unitOfWork.Companies.FindAsync(
            x => x.Id == companyId,
            [ x => x.Include(W=>W.ActiveCodeCompanies) ],
            cancellationToken
        );

        if (company is null)
            return Result.Failure(CompanyErrors.NotFound);

        var activeCode = await _unitOfWork.ActiveCodes.FindAsync(x => x.Id == activeCodeId,null,cancellationToken);

        if (activeCode is null)
            return Result.Failure(ActiveCodeErrors.NotFound);

        if (company.ActiveCodeCompanies.Any(ac => ac.ActiveCodeId == activeCodeId))
            return Result.Failure(ActiveCodeErrors.Duplicated);

        company.ActiveCodeCompanies.Add(new ActiveCodeCompany
        {
            CompanyId = companyId,
            ActiveCodeId = activeCodeId
        });

        await _unitOfWork.SaveAsync(cancellationToken);

        return Result.Success();
    }
    public async Task<Result> RemoveActiveCodeAsync(int companyId, int activeCodeId, CancellationToken cancellationToken = default)
    {
        var company = await _unitOfWork.Companies.FindAsync(x=>x.Id == companyId, [x=>x.Include(W=>W.ActiveCodeCompanies)], cancellationToken);

        if (company == null)
            return Result.Failure(CompanyErrors.NotFound);

        var activeCodeCompany = company.ActiveCodeCompanies.FirstOrDefault(x => x.ActiveCodeId == activeCodeId);

        if (activeCodeCompany is null)
            return Result.Failure(ActiveCodeErrors.NotFound);

        _unitOfWork.ActiveCodeCompanies.Delete(activeCodeCompany);
        await _unitOfWork.SaveAsync(cancellationToken);
        
        return Result.Success();
    }
    public async Task<Result> UpdateAsync(int id, CompanyRequest request, CancellationToken cancellationToken = default)
    {
        var company = await _unitOfWork.Companies.FindAsync(x => x.Id == id, null, cancellationToken);

        if (company is null)
            return Result.Failure<CompanyResponse>(CompanyErrors.NotFound);

        if (_unitOfWork.Companies.IsExist(x => (x.RIN == request.RIN) && x.Id != id))
            return Result.Failure<CompanyResponse>(CompanyErrors.Duplicated);

        company.Name = request.Name;
        company.RIN = request.RIN;

        _unitOfWork.Companies.Update(company);
        await _unitOfWork.SaveAsync(cancellationToken);

        return Result.Success();    
    }
    
}
