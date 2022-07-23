using FluentResults;
using LivrosAPI.Data.DTOs.Livro;
using LivrosAPI.Models;
using LivrosAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LivrosAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class LivroController : ControllerBase
{

    private readonly ILivroService _livroService;

    public LivroController(ILivroService livroService)
    {
        _livroService = livroService;
    }

    [HttpPost, Route("[action]")]
    public IActionResult AdicionarLivro([FromBody] CreateLivroDTO livroDto)
    {
        ReadLivroDTO readLivroDto = _livroService.AdicionarLivro(livroDto);
        return CreatedAtAction(nameof(ObterLivroPorId), new {Id = readLivroDto.Id}, readLivroDto);
    }
    
    [HttpGet, Route("[action]")]
    public IActionResult ListarLivros([FromQuery] List<string>? generos = null, string? autor = null, string? editora = null)
    {
        List<ReadLivroDTO> readLivrosDto = _livroService.ListarLivros(generos, autor, editora);
        if (readLivrosDto is null) 
            return NotFound();
        return Ok(readLivrosDto);
    }
    
    // TODO: CONFERIR SE FICOU CERTO
    [HttpGet, Route("[action]")]
    public IActionResult ObterLivroPorId(long id)
    {
        ReadLivroDTO readLivroDto =  _livroService.ObterLivroPorId(id);
        if (readLivroDto is null) 
            return NotFound(readLivroDto);
        return Ok(readLivroDto);
        return NotFound();

    }
    
    [HttpPut, Route("[action]")]
    public IActionResult AtualizarLivro(long id, UpdateLivroDTO livroDto)
    {
        Result result = _livroService.AtualizarLivro(id, livroDto);
        if (result.IsFailed)
            return NotFound();
        return NoContent();
    }
    
    [HttpDelete, Route("[action]")]
    public IActionResult RemoverLivroPorId(long id)
    {
        Result result = _livroService.RemoverLivroPorId(id);
        if (result.IsFailed)
            return NotFound();
        return NoContent();
    }
    
    [HttpDelete, Route("[action]")]
    public IActionResult RemoverLivroPorISBN10(string isbn)
    {
        Result result = _livroService.RemoverLivroPorISBN10(isbn);
        if (result.IsFailed)
            return NotFound();
        return NoContent();
    }    
    
    [HttpDelete, Route("[action]")]
    public IActionResult RemoverLivroPorISBN13(string isbn)
    {
        Result result = _livroService.RemoverLivroPorISBN13(isbn);
        if (result.IsFailed)
            return NotFound();
        return NoContent();
    }
}