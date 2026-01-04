using NZWalks.API.Data;
using NZWalks.API.Models;
using NZWalks.API.Repositories.Interfaces;

namespace NZWalks.API.Repositories.RepositoryClasses;

public class DifficultyRepository:SqlBaseRepository<Difficulty>,IDifficultyRepository
{
    public DifficultyRepository(ApplicationDbContext context) : base(context)
    {
    }
}