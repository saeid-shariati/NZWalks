
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Repositories.Interfaces;

namespace NZWalks.API.Repositories.RepositoryClasses;

public class SqlBaseRepository<T>:IBaseRepository<T> where T:class
{
    private readonly DbContext _context;
    private readonly DbSet<T> _dbSet;

    public SqlBaseRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }
    public virtual async Task<IEnumerable<T>?> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<T?> GetByIdAsync(Guid id)
    {
        var entityResult = await _dbSet.FindAsync(id);
        return entityResult;
    }

    public virtual async Task<T?> FindElementAsync(T entity)
    {
        var entityresult =await _dbSet.FindAsync(entity);
        return entityresult;
    }


    public virtual async Task<T> CreateAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await CommitAsync();
        return entity;
    }

    public virtual async Task<T> UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await CommitAsync();
        return entity;
    }

    public virtual async Task<bool> DeleteAsync(Guid id)
    {
        var entityInDb = await GetByIdAsync(id);
        if (entityInDb == null)
            return false;
        _dbSet.Remove(entityInDb);
        await CommitAsync();
        return true;
    }

    private async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}