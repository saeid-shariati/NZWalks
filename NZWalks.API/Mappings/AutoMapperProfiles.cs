using AutoMapper;
using NZWalks.API.DataTransferObject;
using NZWalks.API.Models;

namespace NZWalks.API.Mappings;

public class AutoMapperProfiles:Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Region, RegionDto>().ReverseMap();
        CreateMap<AddRegionDtoRequest,Region>().ReverseMap();
    }
}