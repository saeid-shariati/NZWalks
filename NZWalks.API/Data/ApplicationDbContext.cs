using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NZWalks.API.Models;

namespace NZWalks.API.Data;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
        
    }

    public DbSet<Difficulty> Difficulties { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Walk> Walks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Region>().HasData(new List<Region>()
        {
            new Region
            {
                Id = Guid.NewGuid(),
                Code = "THR",
                Name = "Tehran",
                RegionImageUrl = @"https://jamhospital.ir/en/pages/display/28"
            },
            new Region
            {
                Id = Guid.NewGuid(),
                Code = "ISN",
                Name = "Isfahan",
                RegionImageUrl = @"https://www.irun2iran.com/khaju-bridge/",
            },
            new Region
            {
                Id = Guid.NewGuid(),
                Code = "SHZ",
                Name = "Shiraz",
                RegionImageUrl = @"http://luxuryproperties.ir/blog/item/428/visit-7-historical-monuments-in-shiraz-iran",

            }
        });
    }
}