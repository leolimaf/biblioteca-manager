using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using LivrosAPI.Data.DTOs.Livro;

namespace LivrosAPI.Data.DTOs.Emprestimo;

public class LerEmprestimoDTO
{
    public long Id { get; set; }
    
    public LerLivroDTO Livro { get; set; }
    
}