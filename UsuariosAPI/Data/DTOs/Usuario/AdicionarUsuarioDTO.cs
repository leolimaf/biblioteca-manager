using System.ComponentModel.DataAnnotations;

namespace LivrosAPI.Data.DTOs.Usuario;

public class AdicionarUsuarioDTO
{
    [Required]
    public string Username { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    [DataType(DataType.Password)]
    [Required]
    [Compare("Password")]
    public string RePassword { get; set; }
    
    [Required]
    public string Email { get; set; }
}