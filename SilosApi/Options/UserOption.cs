using SilosApi.Enums;

namespace SilosApi.Options;

public class UserOption
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public UserRoleEnum UserRole { get; set; }
}