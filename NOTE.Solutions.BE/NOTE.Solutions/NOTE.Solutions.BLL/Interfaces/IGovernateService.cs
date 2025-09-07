namespace NOTE.Solutions.BLL.Interfaces;

public interface IGovernateService
{
    Task<Result<IEnumerable<GovernateResponse>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<GovernateResponse>> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Result<GovernateResponse>> CreateAsync(GovernateRequest request, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(int id, GovernateRequest request, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
