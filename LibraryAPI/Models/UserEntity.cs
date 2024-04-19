using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using LibraryAPI.Enums;

namespace LibraryAPI.Models;

[Table("users")]
public class UserEntity : BaseEntity
{
    [Column("username")]
    [JsonPropertyName("username")]
    public string Username { get; set; }

    [Column("password")]
    [JsonIgnore]
    public string Password { get; set; }

    [Column("role")]
    [JsonPropertyName("role")]
    public UserRole Role { get; set; }
}