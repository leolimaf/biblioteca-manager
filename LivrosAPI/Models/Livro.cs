using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LivrosAPI.Models;

[Table("livro")]
public class Livro
{
    [Key]
    [Required]
    [JsonPropertyName("id")]
    [Column("id")]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [Column("titulo")]
    public string Titulo { get; set; }
    
    [Column("subtitulo")]
    public string Subtitulo { get; set; }
    
    [JsonPropertyName("isbn-10")]
    [StringLength(10, MinimumLength = 10, ErrorMessage = "O campo {0} só pode ter {2} caracteres.")]
    [Column("isbn10")]
    public string Isbn10 { get; set; }
    
    [JsonPropertyName("isbn-13")]
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(13, MinimumLength = 13, ErrorMessage = "O campo {0} só pode ter {2} caracteres.")]
    [Column("isbn13")]
    public string Isbn13 { get; set; }

    [Column("serie")]
    public string Serie { get; set; }
    
    [Column("volume")]
    public int Volume { get; set; }
    
    [Column("generos")]
    public string Generos { get; set; }
    
    [Column("quantidade_de_paginas")]
    public int QuantidadeDePaginas { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [Column("autor")]
    public string Autor { get; set; }
    
    [Column("editora")]
    public string Editora { get; set; }
}