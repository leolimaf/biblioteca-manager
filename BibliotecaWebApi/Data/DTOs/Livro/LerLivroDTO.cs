using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BibliotecaWebApi.Data.DTOs.Autor;
using BibliotecaWebApi.Data.DTOs.Editora;

namespace BibliotecaWebApi.Data.DTOs.Livro;

public class LerLivroDTO
{
    [Key]
    [Required]
    [JsonPropertyName("id")]
    public long Id { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public string Titulo { get; set; }
    
    [JsonPropertyName("isbn-13")]
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(13, MinimumLength = 13, ErrorMessage = "O campo {0} só pode ter {2} caracteres.")]
    public string Isbn { get; set; }
    
    public string Serie { get; set; }
    
    public int Volume { get; set; }
    
    public int AnoPublicacao { get; set; }
    
    public int NumeroDePaginas { get; set; }
    
    public int QuantidadeDisponivel { get; set; }
    
    public LerAutorDTO Autor { get; set; }
    
    public LerEditoraDTO Editora { get; set; }
}