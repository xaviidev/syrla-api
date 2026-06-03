using Syrla.Application.DTOs;

namespace Syrla.Application.Interfaces;

public interface IAuthService
{
    Task<string?> LoginAsync(LoginDto dto);
}
