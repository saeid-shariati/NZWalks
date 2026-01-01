using System.ComponentModel.DataAnnotations.Schema;

namespace NZWalks.API.Models;

public class Walk
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double LengthInKM { get; set; }
    public string? WalkImageUrl { get; set; }
    public Guid RegionId { get; set; }
    public Guid DifficultyId { get; set; }
    [ForeignKey(nameof(DifficultyId))]
    public virtual Difficulty Difficulty { get; set; }
    [ForeignKey(nameof(RegionId))]
    public virtual Region Region { get; set; }
}