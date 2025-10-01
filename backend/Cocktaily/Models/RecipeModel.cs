using MyApp.Backend.Database;

namespace Cocktaily.Models;

public class RecipeModel
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public byte[] Image { get; set; }
    public string Author { get; set; }
    public string Steps { get; set; }
    public bool IsValidated { get; set; }
    public float Rating { get; set; }
    public int NumberOfRating { get; set; }
    public uint GlassId { get; set; }

    public RecipeModel()
    {

    }

    public RecipeModel(RecipeEntity entity)
    {
        Id = entity.Id;
        Name = entity.Name;
        Image = entity.Image;
        Author = entity.Author;
        Steps = entity.Steps;
        IsValidated = entity.IsValidated;
        GlassId = entity.GlassId;
        Rating = entity.Rating;
        NumberOfRating = entity.NumberOfRatings;
    }

    public RecipeEntity ToEntity()
    {
        var entity = new RecipeEntity();

        entity.Id = Id;
        entity.Name = Name;
        entity.Image = Image;
        entity.Author = Author;
        entity.Steps = Steps;
        entity.IsValidated = IsValidated;
        entity.GlassId = GlassId;
        entity.Rating = Rating;
        entity.NumberOfRatings = NumberOfRating;

        return entity;
    }
}
