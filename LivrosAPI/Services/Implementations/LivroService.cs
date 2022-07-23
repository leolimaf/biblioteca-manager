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
    
    public LerLivroDTO AdicionarLivro(AdicionarLivroDTO livroDto)
    {
        Livro livro = _mapper.Map<Livro>(livroDto);
        _context.Livros.Add(livro);
        _context.SaveChanges();
        return _mapper.Map<LerLivroDTO>(livro);
    }
    
    public LerLivroDTO ObterLivroPorId(long id)
    {
        Livro livro = _context.Livros.FirstOrDefault(livro => livro.Id == id);
        if (livro is not null)
        {
            LerLivroDTO livroDto = _mapper.Map<LerLivroDTO>(livro);
            return livroDto;
        }
        return null;
    }

    public LerLivroDTO ObterLivroPorIsbn10(string isbn10)
    {
        throw new NotImplementedException();
    }

    public LerLivroDTO ObterLivroPorIsbn13(string isbn13)
    {
        throw new NotImplementedException();
    }

    public List<LerLivroDTO> ListarLivros(string? generos, string? autor, string? editora)
    {
        List<Livro> livros = new List<Livro>();
        if ( !string.IsNullOrWhiteSpace(generos) || !string.IsNullOrWhiteSpace(autor) || !string.IsNullOrWhiteSpace(autor))
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
            List<LerLivroDTO> readLivrosDto = _mapper.Map<List<LerLivroDTO>>(livros);
            return readLivrosDto;
        }
        return null;
    }
    
    public Result AtualizarLivroPorId(long id, AtualizarLivroDTO livroDTO)
    {
        Livro livro = _context.Livros.FirstOrDefault(l => l.Id == id);
        
        if (livro is null)
            return Result.Fail($"O livro com o id {id} não foi encontrado");
        
        _mapper.Map(livroDTO, livro);
        _context.SaveChanges();
        return Result.Ok();
    }

    public Result AtualizarLivroPorIsbn10(string isbn10, AtualizarLivroDTO livro)
    {
        throw new NotImplementedException();
    }

    public Result AtualizarLivroPorIsbn13(string isbn13, AtualizarLivroDTO livro)
    {
        throw new NotImplementedException();
    }

    public Result RemoverLivroPorId(long id)
    {
        Livro livro = _context.Livros.FirstOrDefault(l => l.Id == id);
        
        if (livro is null)
            return Result.Fail($"O livro com o id {id} não foi encontrado");
        
        _context.Remove(livro);
        _context.SaveChanges();
        return Result.Ok();
    }
    
    public Result RemoverLivroPorIsbn10(string isbn10)
    {
        Livro livro = _context.Livros.FirstOrDefault(l => l.Isbn10 == isbn10);
        
        if (livro is null)
            return Result.Fail($"O livro com o ISBN-10 {isbn10} não foi encontrado");
        
        _context.Remove(livro);
        _context.SaveChanges();
        return Result.Ok();
    }
    
    public Result RemoverLivroPorIsbn13(string isbn13)
    {
        Livro livro = _context.Livros.FirstOrDefault(l => l.Isbn13 == isbn13);
        
        if (livro is null)
            return Result.Fail($"O livro com o ISBN-10 {isbn13} não foi encontrado");
        
        _context.Remove(livro);
        _context.SaveChanges();
        return Result.Ok();
    }
}