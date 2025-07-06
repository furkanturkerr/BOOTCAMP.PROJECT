using Microsoft.EntityFrameworkCore;
using Repositories.Abstracts;
using Repositories.Contexts;

namespace Repositories.Concrete;

public class GenericRepository <T> : IGenericRepository<T> where T : class
{
    protected readonly BaseDbContext _context;
    private readonly DbSet<T> _dbSet;
    
    public GenericRepository(BaseDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }


    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();

    }

    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
}