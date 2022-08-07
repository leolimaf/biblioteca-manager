using FluentResults;
using LivrosAPI.Data.DTOs.Autor;

namespace LivrosAPI.Services;

public interface IAutorService
{
    LerAutorDTO AdicionarAutor(AdicionarAutorDTO autorDto);
    LerAutorDTO ObterAutorPorId(long id);
    List<LerAutorDTO> ListarAutores();
    Result AtualizarAutorPorId(long id, AtualizarAutorDTO livro);
    Result RemoverAutorPorId(long id);
}