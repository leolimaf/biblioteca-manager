using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BibliotecaWebApi.Models;

[Table("autor")]
public class Autor
{
    [Key]
    [Required]
    [JsonPropertyName("id")]
    [Column("id")]
    public long Id { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [Column("nome_completo")]
    public string NomeCompleto { get; set; }
    
    [JsonIgnore]
    public virtual List<Livro> Livros { get; set; }
}