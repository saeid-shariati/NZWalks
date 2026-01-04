using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models;

namespace NZWalks.API.Data.SeedData;

public static class SeedRegion
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        List<Region> regions = new()
        {
            new Region
            {
                Id = Guid.Parse("542F9468-AEE1-42DB-9140-1EFD13973A52"),
                Code = "TUN",
                Name = "Tehran University",
                RegionImageUrl =
                    @"https://www.chidaneh.com/cdn/api/images/2025/05/photo_2025-05-25_20-57-04-768x1024.jpg"
            },
            new Region
            {
                Id = Guid.Parse("5D8B194D-768F-4928-9E13-5EE5BBC972CA"),
                Code = "SSQ",
                Name = "Sadeghiye Square",
                RegionImageUrl = @"https://cdn-news.inn.ir/photo/1404/07/23/64d8821895ed8b690a0af016a1f1fe12-a-i-m.jpg"
            },
            new Region
            {
                Id = Guid.Parse("E26CD769-B7CF-4FEF-97BD-3AA76DC6E123"),
                Code = "TJS",
                Name = "Tajrish Square",
                RegionImageUrl = @"https://kojachetor.com/wp-content/uploads/2024/02/tajrish-sq3.jpg"
            }
        };
        modelBuilder.Entity<Region>().HasData(regions);
    }
}