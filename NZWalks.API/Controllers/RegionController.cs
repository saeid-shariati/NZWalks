using System.Runtime.InteropServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.DataTransferObject;
using NZWalks.API.Models;
using NZWalks.API.Repositories.Interfaces;

namespace NZWalks.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegionController : ControllerBase
{
    private readonly IRegionRepository _regionRepo;
    private readonly ILogger<RegionController> _logger;
    private readonly IMapper _mapper;
    public RegionController(IRegionRepository regionRepo, ILogger<RegionController> logger, IMapper mapper)
    {
        _regionRepo = regionRepo;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<Region>>> GetAll()
    {
        var regionsModel = await _regionRepo.GetAllAsync();
        if (regionsModel is null)
            return NotFound("Regions not found in database.");
        var regionsDto = _mapper.Map<List<RegionDto>>(regionsModel);
        return Ok(regionsDto);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<ActionResult<RegionDto>> GetById([FromRoute] Guid id)
    {
        var regionModel = await _regionRepo.GetByIdAsync(id);
        if (regionModel is null)
            return NotFound($"Region not found in database with this {id}");
        var regionDto = _mapper.Map<RegionDto>(regionModel);
        return Ok(regionDto);
    }

    [HttpPost]
    public async Task<ActionResult<RegionDto>> PostCreate([FromBody] AddRegionDtoRequest addRegionDto)
    {
        if (!ModelState.IsValid)
            return Problem("Model has error, try again...", "Error", StatusCodes.Status403Forbidden);
        var regionModel =_mapper.Map<Region>(addRegionDto);
        await _regionRepo.CreateAsync(regionModel);
        var regionDto = _mapper.Map<RegionDto>(regionModel);
        return Ok(regionDto);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<ActionResult<RegionDto>> PutRegion([FromRoute] Guid id,
        [FromBody] UpdateRegionDtoRequest updateRegionDtoRequest)
    {
        var regionInDb = await _regionRepo.GetByIdAsync(id);
        if (regionInDb is null)
            return NotFound("Region not found in database.");
        regionInDb.Code = updateRegionDtoRequest.Code;
        regionInDb.Name = updateRegionDtoRequest.Name;
        regionInDb.RegionImageUrl = updateRegionDtoRequest.RegionImageUrl;
        await _regionRepo.UpdateAsync(regionInDb);
        var regionDto =_mapper.Map<RegionDto>(regionInDb);
        return Ok(regionDto);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<ActionResult> DeleteRegion([FromRoute] Guid id)
    {
        var delFlag = await _regionRepo.DeleteAsync(id);
        if (delFlag)
            return Ok("Region deleted.");
        return NotFound("Region element not found for deleted in database.");
    }
}