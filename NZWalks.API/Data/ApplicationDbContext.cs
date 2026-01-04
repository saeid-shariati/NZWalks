using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NZWalks.API.Data.SeedData;
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
        
        SeedRegion.Seed(modelBuilder);
        SeedDifficulty.Seed(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }
}