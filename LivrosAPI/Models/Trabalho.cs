﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LivrosAPI.Models;

[Table("trabalho")]
public class Trabalho
{
    [Key]
    [Required]
    [JsonPropertyName("id")]
    [Column("id")]
    public long Id { get; set; }

    [JsonIgnore]
    public virtual Livro Livro { get; set; }
    
    [JsonIgnore]
    public virtual Autor Autor { get; set; }
    
    [Column("livro_id")]
    public long LivroId { get; set; }
    
    [Column("autor_id")]
    public long AutorId { get; set; }
}