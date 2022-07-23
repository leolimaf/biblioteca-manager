using AutoMapper;
using FluentResults;
using LivrosAPI.Data;
using LivrosAPI.Data.DTOs.Livro;
using LivrosAPI.Models;

namespace LivrosAPI.Services.Implementations;

public class LivroService : ILivroService
{
    private AppDbContext _context;
    private IMapper _mapper;

    public LivroService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public ReadLivroDTO AdicionarLivro(CreateLivroDTO livroDto)
    {
        Livro livro = _mapper.Map<Livro>(livroDto);
        _context.Livros.Add(livro);
        _context.SaveChanges();
        return _mapper.Map<ReadLivroDTO>(livro);
    }
    
    public ReadLivroDTO ObterLivroPorId(long id)
    {
        Livro livro = _context.Livros.FirstOrDefault(livro => livro.Id == id);
        if (livro is not null)
        {
            ReadLivroDTO livroDto = _mapper.Map<ReadLivroDTO>(livro);
    
            return livroDto;
        }
        return null;
    }
    
    public List<ReadLivroDTO> ListarLivros(List<string>? generos, string? autor, string? editora)
    {
        List<Livro> livros = new List<Livro>();
        if ((generos is not null && generos.Count > 0) || !string.IsNullOrWhiteSpace(autor) || !string.IsNullOrWhiteSpace(autor))
        {
            // TODO MELHORAR ESSA LÓGICA
            // if (generos is not null && generos.Count > 0)
            //     livros = livros.Concat(_context.Livros.Where()).ToList();
            // if (!string.IsNullOrWhiteSpace(autor))
            //     livros = livros.Concat(_context.Livros.Where(l => l.Autor.Equals(autor))).ToList();
            // if (!string.IsNullOrWhiteSpace(editora))
            //     livros = livros.Concat(_context.Livros.Where(l => l.Autor.Equals(autor))).ToList();
        }
        else
        {
            livros = _context.Livros.ToList();
        }
    
        if (livros.Count > 0)
        {
            List<ReadLivroDTO> readLivrosDto = _mapper.Map<List<ReadLivroDTO>>(livros);
            return readLivrosDto;
        }
        return null;
    }
    
    public Result AtualizarLivro(long id, UpdateLivroDTO livroDTO)
    {
        Livro livro = _context.Livros.FirstOrDefault(l => l.Id == id);
        if (livro is null)
        {
            return Result.Fail("Livro não encontrado");
        }
        _mapper.Map(livroDTO, livro);
        _context.SaveChanges();
        return Result.Ok();
    }
    
    public Result RemoverLivroPorId(long id)
    {
        Livro livro = _context.Livros.FirstOrDefault(l => l.Id == id);
        if (livro is null)
        {
            return Result.Fail("Livro não encontrado");
        }
        _context.Remove(livro);
        _context.SaveChanges();
        return Result.Ok();
    }
    
    public Result RemoverLivroPorISBN10(string isbn)
    {
        Livro livro = _context.Livros.FirstOrDefault(l => l.ISBN10 == isbn);
        if (livro is null)
        {
            return Result.Fail("Livro não encontrado");
        }
        _context.Remove(livro);
        _context.SaveChanges();
        return Result.Ok();
    }
    
    public Result RemoverLivroPorISBN13(string isbn)
    {
        Livro livro = _context.Livros.FirstOrDefault(l => l.ISBN13 == isbn);
        if (livro is null)
        {
            return Result.Fail("Livro não encontrado");
        }
        _context.Remove(livro);
        _context.SaveChanges();
        return Result.Ok();
    }
}