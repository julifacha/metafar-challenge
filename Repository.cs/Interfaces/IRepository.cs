using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Repository.Interfaces
{
    /// <summary>
    /// Interface for wrapping EF more common use operations.  
    /// </summary>
    /// <typeparam name="T">Any Domain entity</typeparam>
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Find(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        Task<T?> FindOneAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        T Update(T entity);
        Task SaveChangesAsync();
    }
}
