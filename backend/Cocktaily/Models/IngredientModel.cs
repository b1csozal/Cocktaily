using MyApp.Backend.Database;

namespace Cocktaily.Models;

public class IngredientModel
{
    public uint Id { get; set; }
    public string Extra { get; set; }
    public string Amount { get; set; }
    public uint IngredientBaseId { get; set; }
    public uint RecipeId { get; set; }

    public IngredientModel()
    {

    }

    public IngredientModel(IngredientEntity entity)
    {
        Id = entity.Id;
        Extra = entity.Extra;
        Amount = entity.Amount;
        IngredientBaseId = entity.IngredientBaseId;
        RecipeId = entity.RecipeId;
    }

    public IngredientEntity ToEntity()
    {
        var entity = new IngredientEntity();

        entity.Extra = Extra;
        entity.Amount = Amount;
        entity.IngredientBaseId = IngredientBaseId;
        entity.RecipeId = RecipeId;

        return entity;
    }
}
