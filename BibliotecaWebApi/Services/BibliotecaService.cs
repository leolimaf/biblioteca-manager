using AutoMapper;
using BibliotecaWebApi.Data;
using BibliotecaWebApi.Data.DTOs.Livro;
using BibliotecaWebApi.Models;
using FluentResults;

namespace BibliotecaWebApi.Services;

public class BibliotecaService
{
    private AppDbContext _context;
    private IMapper _mapper;

    public BibliotecaService(AppDbContext context, IMapper mapper)
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

    public LerLivroDTO ObterLivroPorIsbn13(string isbn13)
    {
        throw new NotImplementedException();
    }

    public List<LerLivroDTO> ObterLivroPorTitulo(string titulo, string subtitulo)
    {
        List<Livro> livros;
        if (!string.IsNullOrWhiteSpace(titulo) && !string.IsNullOrWhiteSpace(subtitulo))
            livros = _context.Livros
                .Where(l => l.Titulo.Contains(titulo))
                .ToList();
        else if (!string.IsNullOrWhiteSpace(titulo) && string.IsNullOrWhiteSpace(subtitulo))
            livros = _context.Livros.Where(l => l.Titulo.Contains(titulo)).ToList();
        else
            livros = null;
        
        List<LerLivroDTO> readLivrosDto = _mapper.Map<List<LerLivroDTO>>(livros);
        return readLivrosDto;
    }

    public List<LerLivroDTO> ListarLivros()
    {
        List<Livro> livros = _context.Livros.ToList();
        return _mapper.Map<List<LerLivroDTO>>(livros);
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
    
    public Result RemoverLivroPorIsbn13(string isbn13)
    {
        Livro livro = _context.Livros.FirstOrDefault(l => l.Isbn == isbn13);
        
        if (livro is null)
            return Result.Fail($"O livro com o ISBN-13 {isbn13} não foi encontrado");
        
        _context.Remove(livro);
        _context.SaveChanges();
        return Result.Ok();
    }
}