
using System.ComponentModel.DataAnnotations.Schema;
using NZWalks.API.Models;

namespace NZWalks.API.DataTransferObject;

public class WalkDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double LengthInKM { get; set; }
    public string? WalkImageUrl { get; set; }
    public Guid RegionId { get; set; }
    public Guid DifficultyId { get; set; }
    [ForeignKey(nameof(DifficultyId))]
    public virtual DifficultyDto DifficultyDto { get; set; }
    [ForeignKey(nameof(RegionId))]
    public virtual RegionDto RegionDto { get; set; }
}