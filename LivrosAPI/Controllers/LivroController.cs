﻿using FluentResults;
using LivrosAPI.Data.DTOs.Livro;
using LivrosAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LivrosAPI.Controllers;

[ApiController]
[Authorize("Bearer")]
[ApiVersion("1.0")]
[Route("v{version:apiVersion}/[controller]")]
[Produces("application/json")]
public class LivroController : ControllerBase
{

    private readonly ILivroService _livroService;

    public LivroController(ILivroService livroService)
    {
        _livroService = livroService;
    }

    /// <remarks>
    ///	O endpoint adiciona um novo livro (schema AdicionarLivroDTO) na base de dados.
    ///	
    ///      Parâmetros obrigatórios:                      
    ///      titulo, isbn-13 e autor.
    /// 
    ///      O parâmetro isbn-10 deve ter exatamente 10 caracteres.
    ///      O parâmetro isbn-13 deve ter exatamente 13 caracteres.
    ///     
    /// </remarks>
    /// <response code="201">Retorna o livro que foi adicionado (schema LerLivroDTO).</response>
    /// <response code="400">Se o payload informado não estiver conforme a especificação.</response>
    /// <response code="401">Caso o cliente não possua um token válido para realizar a requisição.</response>
    [HttpPost, Route("[action]")]
    [ProducesResponseType(201, Type = typeof(LerLivroDTO))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult AdicionarLivro([FromBody] AdicionarLivroDTO livroDto)
    {
        LerLivroDTO lerLivroDto = _livroService.AdicionarLivro(livroDto);
        return CreatedAtAction(nameof(ObterLivroPorId), new {Id = lerLivroDto.Id}, lerLivroDto);
    }
    
    [HttpGet, Route("[action]")]
    [ProducesResponseType(200, Type = typeof(List<LerLivroDTO>))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public IActionResult ListarLivros([FromQuery] string? generos, string? autor, string? editora)
    {
        List<LerLivroDTO> readLivrosDto = _livroService.ListarLivros(generos, autor, editora);
        if (readLivrosDto is null) 
            return NotFound();
        return Ok(readLivrosDto);
    }
    
    [HttpGet, Route("[action]")]
    [ProducesResponseType(200, Type = typeof(LerLivroDTO))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public IActionResult ObterLivroPorId(long id)
    {
        LerLivroDTO lerLivroDto =  _livroService.ObterLivroPorId(id);
        if (lerLivroDto is null) 
            return NotFound(lerLivroDto);
        return Ok(lerLivroDto);
    }
    
    [HttpGet, Route("[action]")]
    [ProducesResponseType(200, Type = typeof(LerLivroDTO))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public IActionResult ObterLivroPorIsbn10(string isbn10)
    {
        LerLivroDTO lerLivroDto =  _livroService.ObterLivroPorIsbn10(isbn10);
        if (lerLivroDto is null) 
            return NotFound(lerLivroDto);
        return Ok(lerLivroDto);
    }
    
    [HttpGet, Route("[action]")]
    [ProducesResponseType(200, Type = typeof(LerLivroDTO))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public IActionResult ObterLivroPorIsbn13(string isbn13)
    {
        LerLivroDTO lerLivroDto =  _livroService.ObterLivroPorIsbn13(isbn13);
        if (lerLivroDto is null) 
            return NotFound(lerLivroDto);
        return Ok(lerLivroDto);
    }
    
    [HttpPut, Route("[action]")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult AtualizarLivroPorId(long id, AtualizarLivroDTO livroDto)
    {
        Result result = _livroService.AtualizarLivroPorId(id, livroDto);
        if (result.IsFailed)
            return NotFound();
        return NoContent();
    }
    
    [HttpPut, Route("[action]")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult AtualizarLivroPorIsbn10(string isbn10, AtualizarLivroDTO livroDto)
    {
        Result result = _livroService.AtualizarLivroPorIsbn10(isbn10, livroDto);
        if (result.IsFailed)
            return NotFound();
        return NoContent();
    }
    
    [HttpPut, Route("[action]")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult AtualizarLivroPorIsbn13(string isbn13, AtualizarLivroDTO livroDto)
    {
        Result result = _livroService.AtualizarLivroPorIsbn13(isbn13, livroDto);
        if (result.IsFailed)
            return NotFound();
        return NoContent();
    }
    
    [HttpDelete, Route("[action]")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult RemoverLivroPorId(long id)
    {
        Result result = _livroService.RemoverLivroPorId(id);
        if (result.IsFailed)
            return NotFound();
        return NoContent();
    }
    
    [HttpDelete, Route("[action]")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult RemoverLivroPorIsbn10(string isbn)
    {
        Result result = _livroService.RemoverLivroPorIsbn10(isbn);
        if (result.IsFailed)
            return NotFound();
        return NoContent();
    }    
    
    [HttpDelete, Route("[action]")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult RemoverLivroPorIsbn13(string isbn)
    {
        Result result = _livroService.RemoverLivroPorIsbn13(isbn);
        if (result.IsFailed)
            return NotFound();
        return NoContent();
    }
}