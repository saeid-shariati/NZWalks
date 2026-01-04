using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Application.IServices;
using NZWalks.API.DataTransferObject;
using NZWalks.API.Models;
using NZWalks.API.Repositories.Interfaces;

namespace NZWalks.API.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class WalkController(IWalkRepository walkContext, IMapper mapper, IRegionRepository regionRepository, IBaseService<Walk> walkService, IRegionService regionService, IDifficultyService difficultyService)
    : ControllerBase
{
    private readonly IWalkRepository _walkContext = walkContext;
    private readonly IRegionRepository _regionRepository = regionRepository;
    private readonly IMapper _mapper = mapper;
    private readonly IRegionService _regionService = regionService;
    private readonly IDifficultyService _difficultyService = difficultyService;

    [HttpGet]
    public async Task<IActionResult> GetAllWalks()
    {
        var walks = await _walkContext.GetAllAsync();
        var walksDto = _mapper.Map<List<WalkDto>>(walks);
        return Ok(walksDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateWalk([FromBody] AddRequestWalkDto addRequestWalkDto)
    {
        if (!ModelState.IsValid)
            return Problem("Request has error, it can not execute.", null, statusCode: StatusCodes.Status400BadRequest);
        var walk = _mapper.Map<Walk>(addRequestWalkDto);
        walk.Id = Guid.NewGuid();
        var regionExistInDb = await _regionService.HasEntityAsync(walk.RegionId);
        var difficultyExistInDb = await _difficultyService.HasEntityAsync(walk.DifficultyId);
        if(!regionExistInDb)
            return BadRequest("Region does not exist.");
        if (!difficultyExistInDb)
            return BadRequest("Difficulty does not exist.");
        
        var insertResult = await _walkContext.CreateAsync(walk);
        return Ok(insertResult);
    }
}