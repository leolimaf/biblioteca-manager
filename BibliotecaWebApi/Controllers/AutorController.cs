using BibliotecaWebApi.Data.DTOs.Autor;
using BibliotecaWebApi.Services;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaWebApi.Controllers;

[ApiController]
[Authorize(Policy = "Bearer")]
[ApiVersion("1.0")]
[Route("v{version:apiVersion}/autor")]
[Produces("application/json")]
public class AutorController : ControllerBase
{
    private readonly AutorService _autorService;

    public AutorController(AutorService autorService)
    {
        _autorService = autorService;
    }
    
    [HttpPost, Route("adicionar-autor")]
    [ProducesResponseType(201, Type = typeof(LerAutorDTO))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(401)]
    public IActionResult AdicionarAutor([FromBody] AdicionarAutorDTO autorDto)
    {
        LerAutorDTO lerAutorDto = _autorService.AdicionarAutor(autorDto);
        return CreatedAtAction(nameof(ObterAutorPorId), new {Id = lerAutorDto.Id}, lerAutorDto);
    }
    
    [HttpGet, Route("listar-autores")]
    [ProducesResponseType(200, Type = typeof(List<LerAutorDTO>))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public IActionResult ListarAutores()
    {
        List<LerAutorDTO> readAutorsDto = _autorService.ListarAutores();
        if (readAutorsDto is null) 
            return NotFound();
        return Ok(readAutorsDto);
    }
    
    [HttpGet, Route("obter-autor-por-id")]
    [ProducesResponseType(200, Type = typeof(LerAutorDTO))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public IActionResult ObterAutorPorId(long id)
    {
        LerAutorDTO lerAutorDto =  _autorService.ObterAutorPorId(id);
        if (lerAutorDto is null) 
            return NotFound(lerAutorDto);
        return Ok(lerAutorDto);
    }
    
    [HttpPut, Route("atualizar-autor-por-id")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult AtualizarAutorPorId(long id, [FromBody] AtualizarAutorDTO autorDto)
    {
        Result result = _autorService.AtualizarAutorPorId(id, autorDto);
        if (result.IsFailed)
            return NotFound();
        return NoContent();
    }
    
    [HttpDelete, Route("remover-autor-por-id")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult RemoverAutorPorId(long id)
    {
        Result result = _autorService.RemoverAutorPorId(id);
        if (result.IsFailed)
            return NotFound();
        return NoContent();
    }
}