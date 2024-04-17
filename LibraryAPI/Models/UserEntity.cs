using System.ComponentModel.DataAnnotations.Schema;
using LibraryAPI.Enums;

namespace LibraryAPI.Models;

public class UserEntity : BaseEntity
{
    [Column("username")]
    public String Username { get; set; }
    [Column("password")]
    public String Password { get; set; }
    [Column("role")]
    public UserRole Role { get; set; }
}