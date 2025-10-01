using MyApp.Backend.Database;

namespace Cocktaily.Models;

public class GlassModel
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public string Capacity { get; set; }

    public GlassModel()
    {

    }

    public GlassModel(GlassEntity entity)
    {
        Id = entity.Id;
        Name = entity.Name;
        Capacity = entity.Capacity;
    }

    public GlassEntity ToEntity()
    {
        var entity = new GlassEntity();

        entity.Name = Name;
        entity.Capacity = Capacity;

        return entity;
    }
}
