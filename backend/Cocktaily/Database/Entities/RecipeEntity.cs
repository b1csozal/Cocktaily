using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Backend.Database;

[Table("Recipe")]
public class RecipeEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    public string Name { get; set; }

    public byte[] Image { get; set; }

    public string Author { get; set; }

    public string Steps { get; set; }

    public bool IsValidated { get; set; }

    public float Rating { get; set; }

    public int NumberOfRatings { get; set; }

    public uint GlassId { get; set; }
    public virtual GlassEntity Glass { get; set; }

    public virtual ICollection<IngredientEntity> Ingredients { get; set; }
}