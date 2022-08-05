using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LivrosAPI.Models;

[Table("usuario")]
public class Usuario
{
    [Key]
    [Required]
    [JsonPropertyName("id")]
    [Column("id")]
    public long Id { get; set; }
    
    [Required]
    [StringLength(6, MinimumLength = 12, ErrorMessage = "O campo {0} só pode ter no mínimo {2} e no máximo {1} caracteres.")]
    [Column("matricula")]
    public string Matricula { get; set; }
    
    [Required]
    [StringLength(8, MinimumLength = 25, ErrorMessage = "O campo {0} só pode ter no mínimo {2} e no máximo {1} caracteres.")]
    [Column("senha")]
    public string Senha { get; set; }
    
    [Required]
    [Column("nome_completo")]
    public string NomeCompleto { get; set; }
    
    [Required]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "O campo {0} só pode ter {2} caracteres.")]
    [Column("cpf")]
    public string Cpf { get; set; }

    [Required]
    [Column("email")]
    public string Email { get; set; }
    
    [Column("token")]
    public string? Token { get; set; }
    
    [Column("validade_token")]
    public DateTime? ValidadeToken { get; set; }
}