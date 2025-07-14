using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SilosApi.DbContexts;
using SilosApi.Dto;
using SilosApi.Entities;
using SilosApi.Enums;

namespace SilosApi.Services;

public class AuthService(SilosDbContext context, IJwtService jwtService) : IAuthService
{
    public async Task<UserDto?> Login(LoginDto loginDto)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Username == loginDto.Username);
        if (user == null || !VerifyPassword(loginDto.Password, user.PasswordHash))
            return null;

        return new UserDto
        {
            Username = user.Username,
            Role = user.Role,
            Token = jwtService.GenerateToken(user)
        };
    }
    
    public async Task<User> Register(LoginDto loginDto, UserRoleEnum role)
    {
        var user = new User
        {
            Username = loginDto.Username,
            PasswordHash = HashPassword(loginDto.Password),
            Role = role
        };

        context.Users.Add(user);
        await context.SaveChangesAsync();
        return user;
    }

    private string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(bytes);
    }

    private bool VerifyPassword(string password, string storedHash)
    {
        var hash = HashPassword(password);
        return hash == storedHash;
    }
}