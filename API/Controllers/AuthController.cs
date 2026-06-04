using Syrla.Application.Common;
using Microsoft.AspNetCore.Mvc;
using Syrla.Application.DTOs;
using Syrla.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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

    [Authorize]
    [HttpGet("me")]
    public IActionResult Me()
    {
        var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var name = User.FindFirst(ClaimTypes.Name)?.Value;

        var email = User.FindFirst(ClaimTypes.Email)?.Value;

        var role = User.FindFirst(ClaimTypes.Role)?.Value;

        return Ok(
            ApiResponse<object>.Ok(
                new
                {
                    Id = id,
                    Name = name,
                    Email = email,
                    Role = role
                },
                "Usuário autenticado."
            )
        );
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("admin")]
    public IActionResult AdminOnly()
    {
        return Ok(
            ApiResponse<string>.Ok(
                "Acesso permitido para administradores.",
                "Permissão validada com sucesso."
            )
        );
    }
}