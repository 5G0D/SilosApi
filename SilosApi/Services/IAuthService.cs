using SilosApi.Dto;
using SilosApi.Entities;
using SilosApi.Enums;

namespace SilosApi.Services;

public interface IAuthService
{
    Task<UserDto?> Login(LoginDto loginDto);
    Task<User> Register(LoginDto loginDto, UserRoleEnum role);
}