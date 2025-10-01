using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Backend.Database;

[Table("Category")]
public class CategoryEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<IngredientBaseEntity> Ingredients { get; set; }
}
