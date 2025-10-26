using MyApp.Backend.Database;

namespace Cocktaily.Models;

public class RecipeModel
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public string ImagePath { get; set; }
    public string Author { get; set; }
    public string Steps { get; set; }
    public bool IsValidated { get; set; }
    public int Views { get; set; }
    public float Rating { get; set; }
    public int NumberOfRating { get; set; }
    public uint GlassId { get; set; }
    public DateTime UploadedAt { get; set; }
    public ICollection<IngredientModel> Ingredients { get; set; }

    public RecipeModel()
    {

    }

    public RecipeModel(RecipeEntity entity)
    {
        Id = entity.Id;
        Name = entity.Name;
        ImagePath = entity.ImagePath;
        Author = entity.Author;
        Steps = entity.Steps;
        IsValidated = entity.IsValidated;
        GlassId = entity.GlassId;
        Views = entity.Views;
        UploadedAt = entity.UploadedAt;
        Rating = entity.Rating;
        NumberOfRating = entity.NumberOfRatings;
        Ingredients = entity.Ingredients.Select(y => new IngredientModel(y)).ToList();
    }

    public RecipeEntity ToEntity()
    {
        var entity = new RecipeEntity();

        entity.Id = Id;
        entity.Name = Name;
        entity.ImagePath = ImagePath;
        entity.Author = Author;
        entity.Steps = Steps;
        entity.IsValidated = IsValidated;
        entity.GlassId = GlassId;
        entity.Views = Views;
        entity.UploadedAt = UploadedAt;
        entity.Rating = Rating;
        entity.NumberOfRatings = NumberOfRating;
        entity.Ingredients = Ingredients.Select(y => y.ToEntity()).ToList();

        return entity;
    }
}
