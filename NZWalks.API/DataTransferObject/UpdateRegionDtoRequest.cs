namespace NZWalks.API.DataTransferObject;

public class UpdateRegionDtoRequest
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? RegionImageUrl { get; set; }
}