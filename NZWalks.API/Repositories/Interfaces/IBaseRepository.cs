using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;

namespace NZWalks.API.Repositories.Interfaces;

public interface IBaseRepository<T> where T:class
{
    Task<IEnumerable<T>?> GetAllAsync();
    Task<T?> GetByIdAsync(Guid id);
    Task<T?> FindElementAsync(T entity);
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<bool> DeleteAsync(T entity);
}