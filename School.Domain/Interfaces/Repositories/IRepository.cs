using System.Linq.Expressions;

namespace School.Domain.Interfaces.Repositories;

public interface IRepository<T>
{
    IQueryable<T> GetAll();
    Task<T?> GetByExpresssionAsync(Expression<Func<T, bool>> predicate);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
