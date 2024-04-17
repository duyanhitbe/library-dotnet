using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LibraryAPI.Models;

[Table("book_infos")]
public class BookInfoEntity : BaseEntity
{
    [Column("name")] public string Name { get; set; }

    [Column("author")] public string Author { get; set; }

    [Column("publication_date")] public DateTime PublicationDate { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public BookEntity? Book { get; set; }
}