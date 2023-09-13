using Microsoft.EntityFrameworkCore;
using School.Domain.Interfaces.Repositories;
using School.Infra.Data.Context;
using System.Linq.Expressions;

namespace School.Infra.Data.Repositories;
public class Repository<T> : IRepository<T> where T : class
{
    protected SchoolDbContext _context;

    public Repository(SchoolDbContext context)
    {
        _context = context;
    }

    public IQueryable<T> GetAll()
    {
        return _context.Set<T>().AsNoTracking();
    }

    public async Task<T?> GetByExpresssionAsync(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().SingleOrDefaultAsync(predicate);
    }

    public async Task AddAsync(T entity)
    {
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified; //Não precisa, mas é para deixar claro
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }
}
