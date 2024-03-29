﻿using System.ComponentModel.DataAnnotations;

namespace BibliotecaWebApi.Data.DTOs.Autor;

public class AtualizarAutorDTO
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public string NomeCompleto { get; set; }
}