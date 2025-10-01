using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Backend.Database;

[Table("IngredientBase")]
public class IngredientBaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    public string Name { get; set; }

    public uint CategoryId { get; set; }
    public virtual CategoryEntity Category { get; set; }

    public virtual ICollection<IngredientEntity> Ingredients { get; set; }
}
