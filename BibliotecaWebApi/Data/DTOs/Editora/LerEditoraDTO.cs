using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BibliotecaWebApi.Data.DTOs.Editora;

public class LerEditoraDTO
{
    [Key]
    [Required]
    [JsonPropertyName("id")]
    public long Id { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public string Nome { get; set; }
}