namespace Cocktaily.Models;

public class RecipeModel
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public byte[] Image { get; set; }
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
}
