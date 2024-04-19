using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LibraryAPI.DTO.Book;

public class UpdateBookDto
{
    [Required(ErrorMessage = "category_id is required")]
    [JsonPropertyName("category_id")]
    public Guid CategoryId { get; set; }

    [Required(ErrorMessage = "name is required")]
    [JsonPropertyName("name")]
    public String Name { get; set; }

    [Required(ErrorMessage = "author is required")]
    [JsonPropertyName("author")]
    public String Author { get; set; }

    [Required(ErrorMessage = "publication_date is required")]
    [JsonPropertyName("publication_date")]
    public DateTime PublicationDate { get; set; }
}