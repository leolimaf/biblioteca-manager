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
    public long Id { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [Column("titulo")]
    public string Titulo { get; set; }
    
    [Column("subtitulo")]
    public string Subtitulo { get; set; }
    
    [JsonPropertyName("isbn-13")]
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(13, MinimumLength = 13, ErrorMessage = "O campo {0} só pode ter {2} caracteres.")]
    [Column("isbn")]
    public string Isbn { get; set; }

    [Column("serie")]
    public string Serie { get; set; }
    
    [Column("volume")]
    public int Volume { get; set; }
    
    [Column("ano_publicacao")]
    public int AnoPublicacao { get; set; }
    
    [Column("idioma")]
    public string Idioma { get; set; }

    [Column("numero_de_paginas")]
    public int NumeroDePaginas { get; set; }

    [Column("quantidade_dispovivel")]
    public int QuantidadeDisponivel { get; set; }

    [JsonIgnore]
    public virtual List<Trabalho> Autores { get; set; }

    [JsonIgnore]
    public virtual Editora Editora { get; set; }

    [Column("editora_id")]
    public long EditoraId { get; set; }
}