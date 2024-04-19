using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LibraryAPI.DTO.Book;

public class UpdateUserDto
{
    [Required(ErrorMessage = "username is required")]
    [JsonPropertyName("username")]
    public String Username { get; set; }
}