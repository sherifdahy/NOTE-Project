namespace NOTE.Solutions.BLL.Interfaces;
public interface ICompanyService
{
    Task<Result<IEnumerable<CompanyResponse>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<CompanyResponse>> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Result<CompanyResponse>> CreateAsync(CompanyRequest request,CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(int id, CompanyRequest request, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
