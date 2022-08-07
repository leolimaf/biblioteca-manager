using System.ComponentModel.DataAnnotations;

namespace LivrosAPI.Data.DTOs.Editora;

public class AdicionarEditoraDTO
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public string Nome { get; set; }
}