using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Repositories.Interfaces;

namespace NZWalks.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DifficultyController : ControllerBase
{
    private readonly IDifficultyRepository _difficultyRepository;

    public DifficultyController(IDifficultyRepository difficultyRepository)
    {
        _difficultyRepository = difficultyRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetDifficulties()
    {
        var difficulties = await _difficultyRepository.GetAllAsync();
        return Ok(difficulties);
    }
}