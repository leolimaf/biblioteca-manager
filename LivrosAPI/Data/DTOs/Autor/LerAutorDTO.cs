using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LivrosAPI.Data.DTOs.Autor;

public class LerAutorDTO
{
    [Key]
    [Required]
    [JsonPropertyName("id")]
    public long Id { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public string NomeCompleto { get; set; }
}