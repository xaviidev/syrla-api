using Syrla.Application.Common;
using Microsoft.AspNetCore.Mvc;
using Syrla.Application.DTOs;
using Syrla.Application.Interfaces;

namespace Syrla.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;

    public AuthController(IAuthService service)
{
    _service = service;
}

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var token = await _service.LoginAsync(dto);

        if (token is null)
{
    return Unauthorized(
        ApiResponse<string>.Fail("Credenciais inválidas.")
    );
}

       return Ok(
    ApiResponse<object>.Ok(
        new { token },
        "Login realizado com sucesso."
    )
);
    }
}
