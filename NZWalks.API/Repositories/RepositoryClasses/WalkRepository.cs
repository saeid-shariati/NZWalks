using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models;
using NZWalks.API.Repositories.Interfaces;

namespace NZWalks.API.Repositories.RepositoryClasses;

public class WalkRepository:SqlBaseRepository<Walk>,IWalkRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IRegionRepository _regionRepository;
    public WalkRepository(ApplicationDbContext context, IRegionRepository regionRepository):base(context)
    {
        _context = context;
        _regionRepository = regionRepository;
    }

    public override async Task<IEnumerable<Walk>?> GetAllAsync()
    {
        var walks = await _context.Walks
            .Include(x => x.Difficulty)
            .Include(c => c.Region)
            .ToListAsync();
        return walks;
    }

   
}