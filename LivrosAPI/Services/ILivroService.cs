using FluentResults;
using LivrosAPI.Data.DTOs.Livro;
using LivrosAPI.Models;

namespace LivrosAPI.Services;

public interface ILivroService
{
    ReadLivroDTO AdicionarLivro(CreateLivroDTO livro);
    ReadLivroDTO ObterLivroPorId(long id);
    List<ReadLivroDTO> ListarLivros(List<string>? generos, string? autor, string? editora);
    Result AtualizarLivro(long id, UpdateLivroDTO livro);
    Result RemoverLivroPorId(long id);
    Result RemoverLivroPorISBN10(string isbn);
    Result RemoverLivroPorISBN13(string isbn);
}