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
    
    [Column("matricula")]
    public string Matricula { get; set; }
    
    [Column("senha")]
    public string Senha { get; set; }
    
    [Column("nome_completo")]
    public string NomeCompleto { get; set; }
    
    [Column("cpf")]
    public string Cpf { get; set; }

    [Column("email")]
    public string Email { get; set; }
    
    [Column("token")]
    public string? Token { get; set; }
    
    [Column("validade_token")]
    public DateTime? ValidadeToken { get; set; }
}