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
    public IActionResult AdicionarLivro([FromBody] AdicionarLivroDTO livroDto)
    {
        LerLivroDTO lerLivroDto = _livroService.AdicionarLivro(livroDto);
        return CreatedAtAction(nameof(ObterLivroPorId), new {Id = lerLivroDto.Id}, lerLivroDto);
    }
    
    [HttpGet, Route("[action]")]
    public IActionResult ListarLivros([FromQuery] string? generos, string? autor, string? editora)
    {
        List<LerLivroDTO> readLivrosDto = _livroService.ListarLivros(generos, autor, editora);
        if (readLivrosDto is null) 
            return NotFound();
        return Ok(readLivrosDto);
    }
    
    // TODO: TA DANDO ERRO
    [HttpGet, Route("[action]")]
    public IActionResult ObterLivroPorId(long id)
    {
        LerLivroDTO lerLivroDto =  _livroService.ObterLivroPorId(id);
        if (lerLivroDto is null) 
            return NotFound(lerLivroDto);
        return Ok(lerLivroDto);
    }
    
    [HttpGet, Route("[action]")]
    public IActionResult ObterLivroPorIsbn10(string isbn10)
    {
        LerLivroDTO lerLivroDto =  _livroService.ObterLivroPorIsbn10(isbn10);
        if (lerLivroDto is null) 
            return NotFound(lerLivroDto);
        return Ok(lerLivroDto);
    }
    
    [HttpGet, Route("[action]")]
    public IActionResult ObterLivroPorIsbn13(string isbn13)
    {
        LerLivroDTO lerLivroDto =  _livroService.ObterLivroPorIsbn13(isbn13);
        if (lerLivroDto is null) 
            return NotFound(lerLivroDto);
        return Ok(lerLivroDto);
    }
    
    [HttpPut, Route("[action]")]
    public IActionResult AtualizarLivroPorId(long id, AtualizarLivroDTO livroDto)
    {
        Result result = _livroService.AtualizarLivroPorId(id, livroDto);
        if (result.IsFailed)
            return NotFound();
        return NoContent();
    }
    
    [HttpPut, Route("[action]")]
    public IActionResult AtualizarLivroPorIsbn10(string isbn10, AtualizarLivroDTO livroDto)
    {
        Result result = _livroService.AtualizarLivroPorIsbn10(isbn10, livroDto);
        if (result.IsFailed)
            return NotFound();
        return NoContent();
    }
    
    [HttpPut, Route("[action]")]
    public IActionResult AtualizarLivroPorIsbn13(string isbn13, AtualizarLivroDTO livroDto)
    {
        Result result = _livroService.AtualizarLivroPorIsbn13(isbn13, livroDto);
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
    public IActionResult RemoverLivroPorIsbn10(string isbn)
    {
        Result result = _livroService.RemoverLivroPorIsbn10(isbn);
        if (result.IsFailed)
            return NotFound();
        return NoContent();
    }    
    
    [HttpDelete, Route("[action]")]
    public IActionResult RemoverLivroPorIsbn13(string isbn)
    {
        Result result = _livroService.RemoverLivroPorIsbn13(isbn);
        if (result.IsFailed)
            return NotFound();
        return NoContent();
    }
}