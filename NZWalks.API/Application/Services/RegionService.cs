using NZWalks.API.Application.IServices;
using NZWalks.API.Models;
using NZWalks.API.Repositories.Interfaces;

namespace NZWalks.API.Application.Services;

public class RegionService:BaseService<Region>,IRegionService
{
    public RegionService(IBaseRepository<Region> baseRepository) : base(baseRepository)
    {
    }
}