using SilosApi.Enums;

namespace SilosApi.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public UserRoleEnum Role { get; set; }
}