using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace NOTE.Solutions.Entities.Interfaces
{
    public interface IRepository<T> where T : class
    {
        // Get By Id
        T? GetById(int id);
        Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        // Get All
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);

        // Distinct Column
        List<string> GetDistinct(Expression<Func<T, string>> column);

        // Find
        T? Find(Expression<Func<T, bool>> criteria, Func<IQueryable<T>, IQueryable<T>>[]? includes = null);
        Task<T?> FindAsync(Expression<Func<T, bool>> criteria, Func<IQueryable<T>, IQueryable<T>>[]? includes = null, CancellationToken cancellationToken = default);
        // FindAll
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, Func<IQueryable<T>, IQueryable<T>>[]? includes = null);
        IEnumerable<T> FindAll(
            Expression<Func<T, bool>> criteria,
            int? skip = null,
            int? take = null,
            string? orderBy = null,
            string? direction = null
        );
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, Func<IQueryable<T>, IQueryable<T>>[]? includes = null, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> FindAllAsync(
            Expression<Func<T, bool>> criteria,
            int? skip = null,
            int? take = null,
            string? orderBy = null,
            string? direction = null,
            CancellationToken cancellationToken = default
        );

        // Add
        T Add(T entity);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        IEnumerable<T> AddRange(IEnumerable<T> entities);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

        // Update
        T Update(T entity);
        bool UpdateRange(IEnumerable<T> entities);

        // Delete
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);

        // Count
        int Count();
        int Count(Expression<Func<T, bool>> criteria);
        Task<int> CountAsync(CancellationToken cancellationToken = default);
        Task<int> CountAsync(Expression<Func<T, bool>> criteria, CancellationToken cancellationToken = default);

        // Max
        long Max(Expression<Func<T, object>> column);
        long Max(Expression<Func<T, bool>> criteria, Expression<Func<T, object>> column);
        Task<long> MaxAsync(Expression<Func<T, object>> column, CancellationToken cancellationToken = default);
        Task<long> MaxAsync(Expression<Func<T, bool>> criteria, Expression<Func<T, object>> column, CancellationToken cancellationToken = default);

        // Exist
        bool IsExist(Expression<Func<T, bool>> criteria);

        // Last
        T? Last(Expression<Func<T, bool>> criteria, Expression<Func<T, object>> orderBy);
    }
}
