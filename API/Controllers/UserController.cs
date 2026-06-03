using Syrla.Application.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Syrla.Application.DTOs;
using Syrla.Application.Interfaces;

namespace Syrla.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _service;

    public UserController(IUserService service)
{
    _service = service;
}

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _service.GetUsersAsync();

        return Ok(
    ApiResponse<object>.Ok(
        users,
        "Usuários listados com sucesso."
    )
);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(
    ApiResponse<string>.Fail(
        "Dados inválidos."
    )
);

        var user = await _service.CreateUserAsync(dto);

        return Ok(
    ApiResponse<object>.Ok(
        user,
        "Usuário criado com sucesso."
    )
);
    }
}
