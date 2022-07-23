using FluentResults;
using LivrosAPI.Data.DTOs.Livro;
using LivrosAPI.Models;

namespace LivrosAPI.Services;

public interface ILivroService
{
    ReadLivroDTO AdicionarLivro(CreateLivroDTO livro);
    ReadLivroDTO ObterLivroPorId(long id);
    ReadLivroDTO ObterLivroPorIsbn10(string isbn10);
    ReadLivroDTO ObterLivroPorIsbn13(string isbn13);
    List<ReadLivroDTO> ListarLivros(string? generos, string? autor, string? editora);
    Result AtualizarLivroPorId(long id, UpdateLivroDTO livro);
    Result AtualizarLivroPorIsbn10(string isbn10, UpdateLivroDTO livro);
    Result AtualizarLivroPorIsbn13(string isbn13, UpdateLivroDTO livro);
    Result RemoverLivroPorId(long id);
    Result RemoverLivroPorIsbn10(string isbn);
    Result RemoverLivroPorIsbn13(string isbn);
}