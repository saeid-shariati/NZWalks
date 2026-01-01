using System.Linq.Expressions;
using NZWalks.API.Data;
using NZWalks.API.Models;
using NZWalks.API.Repositories.Interfaces;

namespace NZWalks.API.Repositories.RepositoryClasses;

public class RegionRepository:SqlBaseRepository<Region>,IRegionRepository
{
    public RegionRepository(ApplicationDbContext context) : base(context)
    {
    }

    
}