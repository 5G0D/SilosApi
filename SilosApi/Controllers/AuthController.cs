using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SilosApi.Dto;
using SilosApi.Services;

namespace SilosApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[AllowAnonymous]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        var user = await authService.Login(loginDto);
        
        if (user == null)
            return Unauthorized("Invalid username or password");

        return Ok(user);
    }
}