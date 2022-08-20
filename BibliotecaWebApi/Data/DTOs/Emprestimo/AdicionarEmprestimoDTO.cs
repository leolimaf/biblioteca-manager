using System.ComponentModel.DataAnnotations;

namespace BibliotecaWebApi.Data.DTOs.Emprestimo;

public class AdicionarEmprestimoDTO
{
    [Required]
    public long LivroId { get; set; }
    
    [Required]
    public long UsuarioId { get; set; }
}