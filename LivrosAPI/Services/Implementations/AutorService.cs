using AutoMapper;
using FluentResults;
using LivrosAPI.Data;
using LivrosAPI.Data.DTOs.Autor;
using LivrosAPI.Models;

namespace LivrosAPI.Services.Implementations;

public class AutorService : IAutorService
{
    private AppDbContext _context;
    private IMapper _mapper;

    public AutorService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public LerAutorDTO AdicionarAutor(AdicionarAutorDTO autorDto)
    {
        Autor autor = _mapper.Map<Autor>(autorDto);
        _context.Autores.Add(autor);
        _context.SaveChanges();
        return _mapper.Map<LerAutorDTO>(autor);
    }

    public LerAutorDTO ObterAutorPorId(long id)
    {
        Autor autor = _context.Autores.FirstOrDefault(autor => autor.Id == id);
        if (autor is not null)
        {
            LerAutorDTO autorDto = _mapper.Map<LerAutorDTO>(autor);
            return autorDto;
        }
        return null;
    }

    public List<LerAutorDTO> ListarAutores()
    {
        var autores = _context.Autores.ToList();
        return _mapper.Map<List<LerAutorDTO>>(autores);
    }

    public Result AtualizarAutorPorId(long id, AtualizarAutorDTO autorDto)
    {
        Autor autor = _context.Autores.FirstOrDefault(a => a.Id == id);
        
        if (autor is null)
            return Result.Fail($"O autor com o id {id} não foi encontrado");
        
        _mapper.Map(autorDto, autor);
        _context.SaveChanges();
        return Result.Ok();
    }

    public Result RemoverAutorPorId(long id)
    {
        Autor autor = _context.Autores.FirstOrDefault(a => a.Id == id);
        
        if (autor is null)
            return Result.Fail($"O autor com o id {id} não foi encontrado");
        
        _context.Remove(autor);
        _context.SaveChanges();
        return Result.Ok();
    }
}