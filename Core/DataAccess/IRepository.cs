using System.Linq.Expressions;

namespace Core.DataAccess;

public interface IRepository<T> where T : class
{
    Task<T> GetAsync(Expression<Func<T, bool>> predicate, object include);
    Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
