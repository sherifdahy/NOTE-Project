using NOTE.Solutions.Entities.Entities.Company;

namespace NOTE.Solutions.BLL.Services;
public class CompanyService(IUnitOfWork unitOfWork) : ICompanyService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly string[] _includes =
    {
        nameof(Company.CompanyActiveCodes),
        $"{nameof(Company.CompanyActiveCodes)}.{nameof(CompanyActiveCode.ActiveCode)}"
    };

    public async Task<Result<CompanyResponse>> CreateAsync(CompanyRequest request, CancellationToken cancellationToken = default)
    {
        if (_unitOfWork.Companies.IsExist(x => x.RIN.ToLower() == request.RIN.ToLower()))
            return Result.Failure<CompanyResponse>(CompanyErrors.Duplicated);

        var company = request.Adapt<Company>();

        await _unitOfWork.Companies.AddAsync(company,cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);

        return Result.Success(company.Adapt<CompanyResponse>());
    }

    public async Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        if (id <= 0)
            return Result.Failure(CompanyErrors.InvalidId);

        var company = await _unitOfWork.Companies.GetByIdAsync(id,cancellationToken);

        if (company is null)
            return Result.Failure(CompanyErrors.NotFound);

        _unitOfWork.Companies.Delete(company);
        await _unitOfWork.SaveAsync(cancellationToken);

        return Result.Success();
    }

    public async Task<Result<IEnumerable<CompanyResponse>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var companies = await _unitOfWork.Companies.FindAllAsync(x=> true,_includes,cancellationToken);

        return Result.Success(companies.Adapt<IEnumerable<CompanyResponse>>());
    }

    public async Task<Result<CompanyResponse>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        if (id <= 0)
            return Result.Failure<CompanyResponse>(CompanyErrors.InvalidId);

        var company = await _unitOfWork.Companies.FindAsync(x=>x.Id == id,_includes,cancellationToken);

        if (company is null)
            return Result.Failure<CompanyResponse>(CompanyErrors.NotFound);

        return Result.Success(company.Adapt<CompanyResponse>());
    }

    public async Task<Result> UpdateAsync(int id, CompanyRequest request, CancellationToken cancellationToken = default)
    {
        if (id <= 0)
            return Result.Failure<CompanyResponse>(CompanyErrors.InvalidId);

        var company = await _unitOfWork.Companies.GetByIdAsync(id,cancellationToken);

        if (company is null)
            return Result.Failure<CompanyResponse>(CompanyErrors.NotFound);

        request.Adapt(company);

        _unitOfWork.Companies.Update(company);
        await _unitOfWork.SaveAsync(cancellationToken);

        return Result.Success();
    }
}
