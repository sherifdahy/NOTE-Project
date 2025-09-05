
using NOTE.Solutions.DAL.Data;
using NOTE.Solutions.Entities.Entities.Company;
using NOTE.Solutions.Entities.Entities.Identity;
using NOTE.Solutions.Entities.Interfaces;

namespace NOTE.Solutions.DAL.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;

        Companies = new Repository<Company>(_context);
        Users = new Repository<ApplicationUser>(_context);
        Roles = new Repository<ApplicationRole>(_context);  
    }


    public IRepository<Company> Companies { get; }
    public IRepository<ApplicationUser> Users { get; }
    public IRepository<ApplicationRole> Roles { get; }


    public async Task<TResult> ExecuteInTransactionAsync<TResult>(Func<Task<TResult>> action)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var result = await action();
            await transaction.CommitAsync();
            return result;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
    public void Dispose()
    {
        _context.Dispose();
    }
    public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}
