using System.ComponentModel.DataAnnotations;

namespace LivrosAPI.Data.DTOs.Usuario;

public class AdicionarUsuarioDTO
{
    [Required]
    [StringLength(6, MinimumLength = 12, ErrorMessage = "O campo {0} só pode ter no mínimo {2} e no máximo {1} caracteres.")]
    public string Matricula { get; set; }
    
    [Required]
    public string Senha { get; set; }

    [Required]
    public string NomeCompleto { get; set; }
    
    [Required]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "O campo {0} só pode ter {2} caracteres.")]
    public string Cpf { get; set; }
    
    [Required]
    public string Email { get; set; }
}