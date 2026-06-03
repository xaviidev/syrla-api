using Syrla.Application.DTOs;

namespace Syrla.Application.Interfaces;

public interface IUserService
{
    Task<List<UserResponseDto>> GetUsersAsync();

    Task<UserResponseDto> CreateUserAsync(CreateUserDto dto);
}
