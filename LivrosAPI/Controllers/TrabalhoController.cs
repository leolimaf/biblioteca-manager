using LivrosAPI.Data.DTOs.Trabalho;
using LivrosAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LivrosAPI.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("v{version:apiVersion}/[controller]")]
[Produces("application/json")]
public class TrabalhoController : ControllerBase
{
    private readonly ITrabalhoService _trabalhoService;

    public TrabalhoController(ITrabalhoService trabalhoService)
    {
        _trabalhoService = trabalhoService;
    }
    
    [HttpPost, Route("adicionar-trabalho")]
    [ProducesResponseType(201, Type = typeof(LerTrabalhoDTO))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult AdicionarTrabalho([FromBody] AdicionarTrabalhoDTO trabalhoDto)
    {
        LerTrabalhoDTO lerTrabalhoDto = _trabalhoService.AdicionarTrabalho(trabalhoDto);
        return CreatedAtAction(nameof(ObterTrabalhoPorId), new {Id = lerTrabalhoDto.Id}, lerTrabalhoDto);
    }
    
    [HttpGet, Route("obter-trabalho-por-id")]
    [ProducesResponseType(200, Type = typeof(LerTrabalhoDTO))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public IActionResult ObterTrabalhoPorId(long id)
    {
        LerTrabalhoDTO lerTrabalhoDto =  _trabalhoService.ObterTrabalhoPorId(id);
        if (lerTrabalhoDto is null) 
            return NotFound(lerTrabalhoDto);
        return Ok(lerTrabalhoDto);
    }
}