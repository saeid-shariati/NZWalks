
using NZWalks.API.Application.IServices;
using NZWalks.API.Repositories.Interfaces;

namespace NZWalks.API.Application.Services;

public class BaseService<T> : IBaseService<T> where T : class
{
    private readonly IBaseRepository<T> _baseRepository;

    public BaseService(IBaseRepository<T> baseRepository)
    {
        _baseRepository = baseRepository;
    }

    public async Task<bool> HasEntityAsync(Guid id)
    {
        var searchInDb = await _baseRepository.GetByIdAsync(id);
        return searchInDb is not null;
    }
}