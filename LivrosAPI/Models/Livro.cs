using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivrosAPI.Models;

[Table("livro")]
public class Livro
{
    [Column("id")]
    public int Id { get; set; }
    [Column("titulo")]
    public string Titulo { get; set; }
    [Column("subtitulo")]
    public string Subtitulo { get; set; }
    [Column("isbn10")]
    public string ISBN10 { get; set; }
    [Column("isbn13")]
    public string ISBN13 { get; set; }
    [Column("serie")]
    public string Serie { get; set; }
    [Column("volume")]
    public int Volume { get; set; }
    [Column("generos")]
    public string Generos { get; set; }
    [Column("quantidade_de_paginas")]
    public int QuantidadeDePaginas { get; set; }
    [Column("autor")]
    public string Autor { get; set; }
    [Column("editora")]
    public string Editora { get; set; }
}