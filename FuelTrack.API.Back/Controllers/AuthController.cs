

using FuelTrack.API.Back.Contracts.Auth;
using FuelTrack.API.Back.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace FuelTrack.API.Back.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public ActionResult<LoginResponse> Login([FromBody] LoginRequest request)
    {
        var result = _authService.Login(request.Email, request.Password);

        if (result is null)
            return Unauthorized(new { message = "Invalid credentials" });

        return Ok(result);
    }
}