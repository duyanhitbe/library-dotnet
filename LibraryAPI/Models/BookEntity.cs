using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LibraryAPI.Models;

[Table("books")]
public class BookEntity : BaseEntity
{
    [Column("category_id")]
    [JsonPropertyName("category_id")]
    public Guid CategoryId { get; set; }

    [Column("book_info_id")]
    [JsonPropertyName("book_info_id")]
    public Guid BookInfoId { get; set; }

    [JsonPropertyName("category")] public CategoryEntity Category { get; set; }

    [JsonPropertyName("book_info")] public BookInfoEntity BookInfo { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public List<BorrowerEntity> Borrowers { get; set; }
}