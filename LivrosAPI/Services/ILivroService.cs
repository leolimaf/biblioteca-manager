using FluentResults;
using LivrosAPI.Data.DTOs.Livro;
using LivrosAPI.Models;

namespace LivrosAPI.Services;

public interface ILivroService
{
    LerLivroDTO AdicionarLivro(AdicionarLivroDTO livro);
    LerLivroDTO ObterLivroPorId(long id);
    LerLivroDTO ObterLivroPorIsbn13(string isbn13);
    List<LerLivroDTO> ObterLivroPorTitulo(string titulo, string subtitulo);
    List<LerLivroDTO> ListarLivros();
    Result AtualizarLivroPorId(long id, AtualizarLivroDTO livro);
    Result AtualizarLivroPorIsbn13(string isbn13, AtualizarLivroDTO livro);
    Result RemoverLivroPorId(long id);
    Result RemoverLivroPorIsbn13(string isbn13);
}