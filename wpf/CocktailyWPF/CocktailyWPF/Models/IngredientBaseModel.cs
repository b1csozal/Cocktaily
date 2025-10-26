namespace Cocktaily.Models;

public class IngredientBaseModel
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public uint CategoryId { get; set; }

    public IngredientBaseModel()
    {

    }
}
