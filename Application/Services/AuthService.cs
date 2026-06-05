using Syrla.Application.Interfaces;
using Syrla.Api.Repositories.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Syrla.Infrastructure.Authentication;
using Syrla.Application.DTOs;
using Syrla.Domain.Entities;
using Serilog;

namespace Syrla.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _repository;
    private readonly IAuditLogRepository _auditLogRepository;
    private readonly IConfiguration _configuration;

    public AuthService(
        IUserRepository repository,
        IAuditLogRepository auditLogRepository,
        IConfiguration configuration
    )
    {
        _repository = repository;
        _auditLogRepository = auditLogRepository;
        _configuration = configuration;
    }

    public async Task<string?> LoginAsync(LoginDto dto)
    {
        var user = await _repository.GetByEmailAsync(dto.Email);

        if (user is null)
        {
            Log.Warning(
                "Tentativa de login com email inexistente: {Email}",
                dto.Email
            );

            return null;
        }

        var passwordValid = BCrypt.Net.BCrypt.Verify(
            dto.Password,
            user.PasswordHash
        );

        if (!passwordValid)
        {
            Log.Warning(
                "Falha de login. Senha inválida para usuário {UserId} ({Email})",
                user.Id,
                user.Email
            );

            return null;
        }

        var auditLog = new AuditLog
        {
            UserId = user.Id,
            Action = "Login realizado",
            CreatedAt = DateTime.UtcNow
        };

        await _auditLogRepository.AddAsync(auditLog);
        await _auditLogRepository.SaveChangesAsync();

        Log.Information(
            "Login realizado com sucesso. UserId: {UserId}, Email: {Email}",
            user.Id,
            user.Email
        );

        var jwtSettings = _configuration
            .GetSection("JwtSettings")
            .Get<JwtSettings>();

        var key = Encoding.UTF8.GetBytes(jwtSettings!.SecretKey);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),

            Expires = DateTime.UtcNow.AddHours(2),

            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            )
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}