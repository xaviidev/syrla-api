using Syrla.Application.Interfaces;
using Syrla.Api.Repositories.Interfaces;
using Syrla.Application.DTOs;
using Syrla.Domain.Entities;
using Syrla.Infrastructure.Cache;
using Serilog;

namespace Syrla.Application.Services;

public class UserService : IUserService
{
    private const string UsersCacheKey = "users:all";
    private static readonly TimeSpan UsersCacheExpiration = TimeSpan.FromMinutes(5);

    private readonly IUserRepository _repository;
    private readonly IAuditLogRepository _auditLogRepository;
    private readonly ICacheService _cacheService;

    public UserService(
        IUserRepository repository,
        IAuditLogRepository auditLogRepository,
        ICacheService cacheService)
    {
        _repository = repository;
        _auditLogRepository = auditLogRepository;
        _cacheService = cacheService;
    }

    public async Task<List<UserResponseDto>> GetUsersAsync()
    {
        var cachedUsers = await _cacheService
            .GetAsync<List<UserResponseDto>>(UsersCacheKey);

        if (cachedUsers is not null)
        {
            Log.Information(
                "Cache HIT para consulta de usuários. Quantidade: {Count}",
                cachedUsers.Count
            );

            return cachedUsers;
        }

        Log.Information(
            "Cache MISS para consulta de usuários. Consultando banco de dados."
        );

        var users = await _repository.GetAllAsync();

        var response = users.Select(user => new UserResponseDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Role = user.Role
        }).ToList();

        await _cacheService.SetAsync(
            UsersCacheKey,
            response,
            UsersCacheExpiration
        );

        Log.Information(
            "Cache de usuários atualizado. Quantidade: {Count}, Expiração: {ExpirationMinutes} minutos",
            response.Count,
            UsersCacheExpiration.TotalMinutes
        );

        Log.Information(
            "Consulta de usuários realizada. Quantidade: {Count}",
            response.Count
        );

        return response;
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

        await _cacheService.RemoveAsync(UsersCacheKey);

        Log.Information(
            "Cache de usuários invalidado após criação do usuário. UserId: {UserId}",
            user.Id
        );

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