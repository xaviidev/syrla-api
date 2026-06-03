using System.ComponentModel.DataAnnotations;

namespace Syrla.Application.DTOs;

public class CreateUserDto
{
    [Required(ErrorMessage = "Nome é obrigatório.")]
    [MinLength(3, ErrorMessage = "Nome deve possuir pelo menos 3 caracteres.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email é obrigatório.")]
    [EmailAddress(ErrorMessage = "Email inválido.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Senha é obrigatória.")]
    [MinLength(6, ErrorMessage = "Senha deve possuir pelo menos 6 caracteres.")]
    public string Password { get; set; } = string.Empty;
}
