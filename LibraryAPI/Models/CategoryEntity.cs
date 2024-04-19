using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LibraryAPI.Models;

[Table("categories")]
public class CategoryEntity : BaseEntity
{
    [Column("name"), JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public List<BookEntity> Books { get; set; }
}