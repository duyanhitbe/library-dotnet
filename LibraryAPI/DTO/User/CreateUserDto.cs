using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using LibraryAPI.Enums;

namespace LibraryAPI.DTO.User;

public class CreateUserDto
{
    [Required(ErrorMessage = "username is required")]
    [JsonPropertyName("username")]
    public String Username { get; set; }

    [Required(ErrorMessage = "password is required")]
    [JsonPropertyName("password")]
    public String Password { get; set; }

    [Required(ErrorMessage = "role is required")]
    [JsonPropertyName("role")]
    public UserRole Role { get; set; }
}