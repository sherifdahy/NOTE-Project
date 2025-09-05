
using NOTE.Solutions.Entities.Entities.Company;
using NOTE.Solutions.Entities.Entities.Identity;

namespace NOTE.Solutions.Entities.Interfaces;

public interface IUnitOfWork : IDisposable
{
    public IRepository<Company> Companies { get; }
    public IRepository<ApplicationUser> Users { get; }
    public IRepository<ApplicationRole> Roles { get; }
    Task<int> SaveAsync(CancellationToken cancellationToken = default);
    Task<TResult> ExecuteInTransactionAsync<TResult>(Func<Task<TResult>> action);
}
