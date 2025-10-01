using MyApp.Backend.Database;

namespace Cocktaily.Models;

public class IngredientBaseModel
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public uint CategoryId { get; set; }

    public IngredientBaseModel()
    {

    }

    public IngredientBaseModel(IngredientBaseEntity entity)
    {
        Id = entity.Id;
        Name = entity.Name;
        CategoryId = entity.CategoryId;
    }

    public IngredientBaseEntity ToEntity()
    {
        var entity = new IngredientBaseEntity();

        entity.Name = Name;
        entity.CategoryId = CategoryId;

        return entity;
    }
}
