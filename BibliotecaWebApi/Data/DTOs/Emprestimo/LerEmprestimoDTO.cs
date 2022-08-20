using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BibliotecaWebApi.Data.DTOs.Livro;
using BibliotecaWebApi.Data.DTOs.Usuario;

namespace BibliotecaWebApi.Data.DTOs.Emprestimo;

public class LerEmprestimoDTO
{
    public long Id { get; set; }
    
    public LerLivroDTO Livro { get; set; }
    
    [JsonIgnore]
    public LerUsuarioDTO Usuario { get; set; }
}