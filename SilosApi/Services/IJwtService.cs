using SilosApi.Entities;

namespace SilosApi.Services;

public interface IJwtService
{
    string GenerateToken(User user);
}
