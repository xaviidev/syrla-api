using Syrla.Application.Interfaces;
using Syrla.Api.Repositories.Interfaces;
using Syrla.Application.DTOs;
using Syrla.Domain.Entities;
using Serilog;

namespace Syrla.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IAuditLogRepository _auditLogRepository;

    public UserService(
        IUserRepository repository,
        IAuditLogRepository auditLogRepository)
    {
        _repository = repository;
        _auditLogRepository = auditLogRepository;
    }

    public async Task<List<UserResponseDto>> GetUsersAsync()
    {
        var users = await _repository.GetAllAsync();

        Log.Information(
            "Consulta de usuários realizada. Quantidade: {Count}",
            users.Count
        );

        return users.Select(user => new UserResponseDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Role = user.Role
        }).ToList();
    }

    public async Task<UserResponseDto> CreateUserAsync(CreateUserDto dto)
    {
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            PasswordHash = passwordHash,
            Role = "User"
        };

        await _repository.AddAsync(user);
        await _repository.SaveChangesAsync();

        var auditLog = new AuditLog
        {
            UserId = user.Id,
            Action = "Usuário criado",
            CreatedAt = DateTime.UtcNow
        };

        await _auditLogRepository.AddAsync(auditLog);
        await _auditLogRepository.SaveChangesAsync();

        Log.Information(
            "Usuário criado com sucesso. UserId: {UserId}, Email: {Email}, Role: {Role}",
            user.Id,
            user.Email,
            user.Role
        );

        return new UserResponseDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Role = user.Role
        };
    }
}