namespace NZWalks.API.DataTransferObject;

public class RegionDto
{
    public Guid Id { get; set; }
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? RegionImageUrl { get; set; }
}