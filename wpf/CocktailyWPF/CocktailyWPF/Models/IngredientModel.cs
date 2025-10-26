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
}
