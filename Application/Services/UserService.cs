using Syrla.Application.Interfaces;
using Syrla.Api.Repositories.Interfaces;
using Syrla.Application.DTOs;
using Syrla.Domain.Entities;

namespace Syrla.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<UserResponseDto>> GetUsersAsync()
    {
        var users = await _repository.GetAllAsync();

        return users.Select(user => new UserResponseDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email
        }).ToList();
    }

    public async Task<UserResponseDto> CreateUserAsync(CreateUserDto dto)
    {
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            PasswordHash = passwordHash
        };

        await _repository.AddAsync(user);
        await _repository.SaveChangesAsync();

        return new UserResponseDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email
        };
    }
}
