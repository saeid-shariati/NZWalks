using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
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
    public async Task<IEnumerable<T>?> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        var entityResult = await _dbSet.FindAsync(id);
        return entityResult;
    }

    public async Task<T?> FindElementAsync(T entity)
    {
        var entityresult =await _dbSet.FindAsync(entity);
        return entityresult;
    }


    public async Task<T> CreateAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await CommitAsync();
        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await CommitAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(T entity)
    {
        var entityInDb = await FindElementAsync(entity);
        if (entityInDb == null)
            return false;
        _dbSet.Remove(entity);
        await CommitAsync();
        return true;
    }

    private async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}