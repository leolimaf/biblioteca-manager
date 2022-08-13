using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using LivrosAPI.Data.DTOs.Livro;
using LivrosAPI.Data.DTOs.Usuario;

namespace LivrosAPI.Data.DTOs.Emprestimo;

public class LerEmprestimoDTO
{
    public long Id { get; set; }
    
    public LerLivroDTO Livro { get; set; }
    
    [JsonIgnore]
    public LerUsuarioDTO Usuario { get; set; }
}