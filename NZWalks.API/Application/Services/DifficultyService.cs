using NZWalks.API.Application.IServices;
using NZWalks.API.Models;
using NZWalks.API.Repositories.Interfaces;

namespace NZWalks.API.Application.Services;

public class DifficultyService:BaseService<Difficulty>,IDifficultyService
{
    public DifficultyService(IBaseRepository<Difficulty> baseRepository) : base(baseRepository)
    {
    }
}