using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LibraryAPI.Models;

public abstract class BaseEntity
{
    [Key]
    [Column("id")]
    [JsonPropertyName("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Column("created_at")]
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Column("updated_at")]
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    [Column("deleted_at")]
    [JsonPropertyName("deleted_at")]
    public DateTime? DeletedAt { get; set; } = null;

    [Column("is_active")]
    [DefaultValue("TRUE")]
    [JsonPropertyName("is_active")]
    public bool IsActive { get; set; } = true;
}