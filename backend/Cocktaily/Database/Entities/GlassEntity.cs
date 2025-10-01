using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Backend.Database;

[Table("Glass")]
public class GlassEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    public string Name { get; set; }

    public string Capacity { get; set; }
}
