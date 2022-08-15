using AutoMapper;
using FluentResults;
using LivrosAPI.Data;
using LivrosAPI.Data.DTOs.Editora;
using LivrosAPI.Models;

namespace LivrosAPI.Services;

public class EditoraService
{
    private AppDbContext _context;
    private IMapper _mapper;

    public EditoraService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public LerEditoraDTO AdicionarEditora(AdicionarEditoraDTO editoraDto)
    {
        Editora editora = _mapper.Map<Editora>(editoraDto);
        _context.Editoras.Add(editora);
        _context.SaveChanges();
        return _mapper.Map<LerEditoraDTO>(editora);
    }

    public LerEditoraDTO ObterEditoraPorId(long id)
    {
        Editora editora = _context.Editoras.FirstOrDefault(editora => editora.Id == id);
        if (editora is not null)
        {
            LerEditoraDTO editoraDto = _mapper.Map<LerEditoraDTO>(editora);
            return editoraDto;
        }
        return null;
    }

    public List<LerEditoraDTO> ListarEditoras()
    {
        var editoras = _context.Editoras.ToList();
        return _mapper.Map<List<LerEditoraDTO>>(editoras);
    }

    public Result AtualizarEditoraPorId(long id, AtualizarEditoraDTO editoraDto)
    {
        Editora editora = _context.Editoras.FirstOrDefault(e => e.Id == id);
        
        if (editora is null)
            return Result.Fail($"A editora com o id {id} não foi encontrado");
        
        _mapper.Map(editoraDto, editora);
        _context.SaveChanges();
        return Result.Ok();
    }

    public Result RemoverEditoraPorId(long id)
    {
        Editora editora = _context.Editoras.FirstOrDefault(l => l.Id == id);
        
        if (editora is null)
            return Result.Fail($"A editora com o id {id} não foi encontrado");
        
        _context.Remove(editora);
        _context.SaveChanges();
        return Result.Ok();
    }
}