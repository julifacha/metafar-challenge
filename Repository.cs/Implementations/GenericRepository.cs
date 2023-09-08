using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System.Linq.Expressions;
using Context.Context;

namespace Repository.Implementations
{
    /// <summary>
    /// This class provides generic methods acting as a repository layer through the database EF context.
    /// </summary>
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected MetafarDbContext _context;
        protected const string PredicateEmpty = "False";

        public GenericRepository(MetafarDbContext context)
        {
            this._context = context;
        }

        public virtual IQueryable<T> Find(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (include != null)
                query = include(query);

            if (!PredicateEmpty.Equals(predicate.Body.ToString(), StringComparison.InvariantCultureIgnoreCase))
                return query.Where(predicate);

            return query;
        }

        public virtual async Task<T?> FindOneAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (include != null)
                query = include(query);

            return await query.FirstOrDefaultAsync(predicate);
        }

        public virtual T Update(T entity)
        {
            return _context.Update(entity).Entity;
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
