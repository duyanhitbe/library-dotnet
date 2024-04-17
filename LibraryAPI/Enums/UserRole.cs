using System.ComponentModel;

namespace LibraryAPI.Enums;

public enum UserRole
{
    [Description("ADMIN")]
    ADMIN = 0,
    [Description("MANAGER")]
    MANAGER = 1
}