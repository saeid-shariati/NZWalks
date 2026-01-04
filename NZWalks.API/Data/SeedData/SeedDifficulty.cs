using System.Collections;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Constants;
using NZWalks.API.Models;

namespace NZWalks.API.Data.SeedData;

public static class SeedDifficulty
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        List<Difficulty> difficulties =
        [
            new Difficulty
            {
                Id = Guid.NewGuid(),
                Name = nameof(DifficultyRangeEnum.VeryEasy)
            },

            new Difficulty
            {
                Id = Guid.NewGuid(),
                Name = nameof(DifficultyRangeEnum.Easy)
            },

            new Difficulty
            {
                Id = Guid.NewGuid(),
                Name = nameof(DifficultyRangeEnum.Medium)
            },

            new Difficulty
            {
                Id = Guid.NewGuid(),
                Name = nameof(DifficultyRangeEnum.Hard)
            },

            new Difficulty
            {
                Id = Guid.NewGuid(),
                Name = nameof(DifficultyRangeEnum.VeryHard)
            }
        ];
        modelBuilder.Entity<Difficulty>().HasData(difficulties);
    }

}