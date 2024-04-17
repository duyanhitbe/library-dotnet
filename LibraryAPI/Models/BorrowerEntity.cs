using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LibraryAPI.Models;

[Table("borrowers")]
public class BorrowerEntity : BaseEntity
{
    [Column("name")] public string Name { get; set; }

    [Column("phone")] public string Phone { get; set; }

    [Column("address")] public string Address { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public List<BookEntity> Books { get; set; }
}