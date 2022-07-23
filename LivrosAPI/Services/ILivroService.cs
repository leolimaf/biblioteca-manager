using FluentResults;
using LivrosAPI.Data.DTOs.Livro;
using LivrosAPI.Models;

namespace LivrosAPI.Services;

public interface ILivroService
{
    LerLivroDTO AdicionarLivro(AdicionarLivroDTO livro);
    LerLivroDTO ObterLivroPorId(long id);
    LerLivroDTO ObterLivroPorIsbn10(string isbn10);
    LerLivroDTO ObterLivroPorIsbn13(string isbn13);
    List<LerLivroDTO> ListarLivros(string? generos, string? autor, string? editora);
    Result AtualizarLivroPorId(long id, AtualizarLivroDTO livro);
    Result AtualizarLivroPorIsbn10(string isbn10, AtualizarLivroDTO livro);
    Result AtualizarLivroPorIsbn13(string isbn13, AtualizarLivroDTO livro);
    Result RemoverLivroPorId(long id);
    Result RemoverLivroPorIsbn10(string isbn10);
    Result RemoverLivroPorIsbn13(string isbn13);
}