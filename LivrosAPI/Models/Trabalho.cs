using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LivrosAPI.Models;

public class Trabalho
{
    [Key]
    [Required]
    [JsonPropertyName("id")]
    public long Id { get; set; }

    public virtual Livro Livro { get; set; }
    public virtual Autor Autor { get; set; }
    public long LivroId { get; set; }
    public long AutorId { get; set; }
}