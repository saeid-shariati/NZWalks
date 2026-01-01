using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.DataTransferObject;
using NZWalks.API.Models;

namespace NZWalks.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RegionController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<RegionController> _logger;
    public RegionController(ApplicationDbContext context, ILogger<RegionController> logger)
    {
        _context = context;
        _logger = logger;
    }
    [HttpGet]
    public async Task<ActionResult<List<Region>>> GetAll()
    {
        var regionsModel = await _context.Regions.ToListAsync();
        var regionsDto = new List<RegionDto>();
        regionsDto = regionsModel.Select(t => new RegionDto()
        {
            Id = t.Id,
            Code = t.Code,
            Name = t.Name,
            RegionImageUrl = t.RegionImageUrl
        }).ToList();
        return Ok(regionsDto);
    }
    [HttpGet]
    [Route("{id:guid}")]
    public async Task<ActionResult<Region>> GetById([FromRoute] Guid id)
    {
        var regionModel = await _context.Regions.FindAsync(id);
        if (regionModel is null)
            return NotFound($"Region not found in database with this {id}");
        return Ok(regionModel);
    }

    [HttpPost]
    public async Task<ActionResult<RegionDto>> PostCreate([FromBody] AddRegionDtoRequest addRegionDto)
    {
        if (!ModelState.IsValid)
            return Problem("Model has error, try again...", "Error", StatusCodes.Status403Forbidden);
        var regionModel
            = new Region()
        {
            Code = addRegionDto.Code,
            Name = addRegionDto.Name,
            RegionImageUrl = addRegionDto.RegionImageUrl,
            Id = Guid.NewGuid()
        };
        await _context.Regions.AddAsync(regionModel);
        await _context.SaveChangesAsync();
        var regionDto = new RegionDto()
        {
            Id = regionModel.Id,
            Code = regionModel.Code,
            Name = regionModel.Name,
            RegionImageUrl = regionModel.RegionImageUrl
        };
        return Ok(regionDto);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<ActionResult<RegionDto>> PutRegion([FromRoute] Guid id,
        [FromBody] UpdateRegionDtoRequest updateRegionDtoRequest)
    {
        var regionInDb = await _context.Regions.FindAsync(id);
        if (regionInDb is null)
            return NotFound("Region not found in database.");
        regionInDb.Code = updateRegionDtoRequest.Code;
        regionInDb.Name = updateRegionDtoRequest.Name;
        regionInDb.RegionImageUrl = updateRegionDtoRequest.RegionImageUrl;
        _context.Regions.Update(regionInDb);
        await _context.SaveChangesAsync();
        var regionDto = new RegionDto
        {
            Id = regionInDb.Id,
            Code = regionInDb.Code,
            Name = regionInDb.Name,
            RegionImageUrl = regionInDb.RegionImageUrl
        };
        return Ok(regionDto);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<ActionResult> DeleteRegion([FromRoute] Guid id)
    {
        var regionInDb = await _context.Regions.FindAsync(id);
        if (regionInDb is null)
            return NotFound("Region element not found f or deleted in database.");
        _context.Regions.Remove(regionInDb);
        await _context.SaveChangesAsync();
        return Ok($"region {regionInDb.Name} deleted.");
    }
}