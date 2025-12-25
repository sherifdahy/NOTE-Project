using Microsoft.EntityFrameworkCore;
using NOTE.Solutions.DAL.Data;
using NOTE.Solutions.Entities.Interfaces;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;

namespace NOTE.Solutions.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        // GetById
        public T? GetById(int id) => _context.Set<T>().Find(id);

        public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
            => await _context.Set<T>().FindAsync(id, cancellationToken);

        // GetAll
        public IEnumerable<T> GetAll() => _context.Set<T>().ToList();

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _context.Set<T>().ToListAsync(cancellationToken);

        // Distinct Column
        public List<string> GetDistinct(Expression<Func<T, string>> column)
            => _context.Set<T>().Select(column).Distinct().ToList();

        // Find
        public T? Find(Expression<Func<T, bool>> criteria, Func<IQueryable<T>, IQueryable<T>>[]? includes = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = include(query);
                }
            }

            return query.SingleOrDefault(criteria);
        }

        public async Task<T?> FindAsync(Expression<Func<T, bool>> criteria, Func<IQueryable<T>, IQueryable<T>>[]? includes = null, CancellationToken cancellationToken = default) 
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = include(query);
                }
            }

            return await query.SingleOrDefaultAsync(criteria, cancellationToken); 
        }

        
        // FindAll
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, Func<IQueryable<T>, IQueryable<T>>[]? includes = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = include(query);
                }
            }

            return query.Where(criteria).ToList();
        }

        public IEnumerable<T> FindAll(
            Expression<Func<T, bool>> criteria,
            int? skip = null,
            int? take = null,
            string? orderBy = null,
            string? direction = null
        )
        {
            IQueryable<T> query = _context.Set<T>().Where(criteria);

            if (orderBy != null && direction != null)
                query = query.OrderBy($"{orderBy} {direction}");

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (take.HasValue)
                query = query.Take(take.Value);

            return query.ToList();
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, Func<IQueryable<T>, IQueryable<T>>[]? includes = null, CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = include(query);
                }
            }

            return await query.Where(criteria).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<T>> FindAllAsync(
            Expression<Func<T, bool>> criteria,
            int? skip = null,
            int? take = null,
            string? orderBy = null,
            string? direction = null,
            CancellationToken cancellationToken = default
        )
        {
            IQueryable<T> query = _context.Set<T>().Where(criteria);

            if (orderBy != null && direction != null)
                query = query.OrderBy($"{orderBy} {direction}");

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (take.HasValue)
                query = query.Take(take.Value);

            return await query.ToListAsync(cancellationToken);
        }

        // Add
        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _context.Set<T>().AddAsync(entity, cancellationToken);
            return entity;
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            return entities;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            await _context.Set<T>().AddRangeAsync(entities, cancellationToken);
            return entities;
        }

        // Update
        public T Update(T entity)
        {
            _context.Update(entity);
            return entity;
        }

        public bool UpdateRange(IEnumerable<T> entities)
        {
            _context.UpdateRange(entities);
            return true;
        }

        // Delete
        public void Delete(T entity) => _context.Set<T>().Remove(entity);

        public void DeleteRange(IEnumerable<T> entities) => _context.Set<T>().RemoveRange(entities);

        // Count
        public int Count() => _context.Set<T>().Count();

        public int Count(Expression<Func<T, bool>> criteria) => _context.Set<T>().Count(criteria);

        public async Task<int> CountAsync(CancellationToken cancellationToken = default)
            => await _context.Set<T>().CountAsync(cancellationToken);

        public async Task<int> CountAsync(Expression<Func<T, bool>> criteria, CancellationToken cancellationToken = default)
            => await _context.Set<T>().CountAsync(criteria, cancellationToken);

        // Max
        public long Max(Expression<Func<T, object>> column)
            => Convert.ToInt64(_context.Set<T>().Max(column));

        public long Max(Expression<Func<T, bool>> criteria, Expression<Func<T, object>> column)
            => Convert.ToInt64(_context.Set<T>().Where(criteria).Max(column));

        public async Task<long> MaxAsync(Expression<Func<T, object>> column, CancellationToken cancellationToken = default)
            => Convert.ToInt64(await _context.Set<T>().MaxAsync(column, cancellationToken));

        public async Task<long> MaxAsync(Expression<Func<T, bool>> criteria, Expression<Func<T, object>> column, CancellationToken cancellationToken = default)
            => Convert.ToInt64(await _context.Set<T>().Where(criteria).MaxAsync(column, cancellationToken));

        // Exist
        public bool IsExist(Expression<Func<T, bool>> criteria)
            => _context.Set<T>().Any(criteria);

        // Last
        public T? Last(Expression<Func<T, bool>> criteria, Expression<Func<T, object>> orderBy)
        {
            return _context.Set<T>()
                .Where(criteria)
                .OrderByDescending(orderBy)
                .FirstOrDefault();
        }
    }
}
