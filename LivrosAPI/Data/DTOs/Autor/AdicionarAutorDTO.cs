using System.ComponentModel.DataAnnotations;

namespace LivrosAPI.Data.DTOs.Autor;

public class AdicionarAutorDTO
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public string NomeCompleto { get; set; }
}