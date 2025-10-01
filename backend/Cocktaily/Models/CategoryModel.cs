using MyApp.Backend.Database;

namespace Cocktaily.Models;

public class CategoryModel
{
    public uint Id { get; set; }
    public string Name { get; set; }

    public CategoryModel()
    {

    }

    public CategoryModel(CategoryEntity entity)
    {
        Id = entity.Id;
        Name = entity.Name;
    }

    public CategoryEntity ToEntity()
    {
        var entity = new CategoryEntity();

        entity.Name = Name;

        return entity;
    }
}
