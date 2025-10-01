using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Backend.Database;

[Table("Ingredient")]
public class IngredientEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    public string Extra { get; set; }

    public string Amount { get; set; }

    public uint IngredientBaseId { get; set; }
    public virtual IngredientBaseEntity IngredientBase { get; set; }

    public uint RecipeId { get; set; }
    public virtual RecipeEntity Recipe { get; set; }
}
