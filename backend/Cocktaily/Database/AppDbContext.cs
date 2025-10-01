using System.Collections.Generic;
using System.Reflection.Emit;
using Cocktaily.Database.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyApp.Backend.Database;

namespace Cocktaily.Database;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<GlassEntity> Glasses { get; set; }
    public DbSet<IngredientBaseEntity> IngredientBases { get; set; }
    public DbSet<IngredientEntity> Ingredients { get; set; }
    public DbSet<RecipeEntity> Recipes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CategoryEntity>().HasData(
            new CategoryEntity { Id = 1, Name = "Alkohol" }
        );

        modelBuilder.Entity<IngredientBaseEntity>().HasData(
            new IngredientBaseEntity { Id = 1, Name = "Vodka", CategoryId = 1 },
            new IngredientBaseEntity { Id = 2, Name = "Fehér Rum", CategoryId = 1 },
            new IngredientBaseEntity { Id = 3, Name = "Barna Rum", CategoryId = 1 },
            new IngredientBaseEntity { Id = 4, Name = "Gin", CategoryId = 1 },
            new IngredientBaseEntity { Id = 5, Name = "Pink Gin", CategoryId = 1 },
            new IngredientBaseEntity { Id = 6, Name = "Whiskey", CategoryId = 1 },
            new IngredientBaseEntity { Id = 7, Name = "Triple Sec", CategoryId = 1 },
            new IngredientBaseEntity { Id = 8, Name = "Blue curacao", CategoryId = 1 }
        );
    }
}