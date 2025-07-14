using SilosApi.Enums;

namespace SilosApi.Dto;

public class UserDto
{
    public string Username { get; set; } = null!;
    public UserRoleEnum Role { get; set; }
    public string Token { get; set; } = null!;
}