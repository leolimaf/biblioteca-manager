using System.ComponentModel.DataAnnotations;

namespace LivrosAPI.Data.DTOs.Livro;

public class LerLivroDTO
{
    public long Id { get; set; }
    
    public string Titulo { get; set; }
    
    public string Subtitulo { get; set; }
    
    public string Isbn10 { get; set; }
    
    public string Isbn13 { get; set; }
    
    public string Serie { get; set; }
    
    public int Volume { get; set; }
    
    public string Generos { get; set; }
    
    public int QuantidadeDePaginas { get; set; }
    
    public string Autor { get; set; }
    
    public string Editora { get; set; }
}