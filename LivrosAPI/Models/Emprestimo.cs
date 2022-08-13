using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LivrosAPI.Models;

[Table("emprestimo")]
public class Emprestimo
{
    [Key]
    [Required]
    [JsonPropertyName("id")]
    [Column("id")]
    public long Id { get; set; }

    public virtual Livro Livro { get; set; }
    
    public virtual Usuario Usuario { get; set; }
    
    [Column("livro_id")]
    public long LivroId { get; set; }
    
    [Column("usuario_id")]
    public long UsuarioId { get; set; }
}