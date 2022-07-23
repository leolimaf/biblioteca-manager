﻿using System.ComponentModel.DataAnnotations;

namespace LivrosAPI.Data.DTOs.Livro;

public class AdicionarLivroDTO
{
    [Required(ErrorMessage = "O atributo {0} é obrigatório.")]
    public string Titulo { get; set; }
    
    public string Subtitulo { get; set; }
    
    [StringLength(10, MinimumLength = 10, ErrorMessage = "O atributo {0} só pode ter {2} caracteres.")]
    public string Isbn10 { get; set; }
    
    [Required(ErrorMessage = "O atributo {0} é obrigatório.")]
    [StringLength(13, MinimumLength = 13, ErrorMessage = "O atributo {0} só pode ter {2} caracteres.")]
    public string Isbn13 { get; set; }
    
    public string Serie { get; set; }
    
    public int Volume { get; set; }
    
    public string Generos { get; set; }
    
    public int QuantidadeDePaginas { get; set; }
    
    [Required(ErrorMessage = "O atributo {0} é obrigatório.")]
    public string Autor { get; set; }
    
    public string Editora { get; set; }
}