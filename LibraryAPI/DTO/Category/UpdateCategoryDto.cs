using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LibraryAPI.DTO.Category;

public class UpdateCategoryDto
{
    [Required(ErrorMessage = "name is required")]
    [JsonPropertyName("name")]
    public String Name { get; set; }
}