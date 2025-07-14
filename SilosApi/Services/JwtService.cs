using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SilosApi.Entities;
using SilosApi.Options;

namespace SilosApi.Services;

public class JwtService(IOptions<JwtOption> jwtOption) : IJwtService
{
    private readonly JwtOption _jwtOption = jwtOption.Value;
    
    public string GenerateToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOption.Key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Username),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };

        var token = new JwtSecurityToken(
            _jwtOption.Issuer,
            _jwtOption.Audience,
            claims,
            expires: DateTime.Now.AddMinutes(_jwtOption.ExpiryInMinutes),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}