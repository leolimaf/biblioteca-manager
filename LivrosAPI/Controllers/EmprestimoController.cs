using LivrosAPI.Data.DTOs.Emprestimo;
using LivrosAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LivrosAPI.Controllers;

[ApiController]
[Authorize("Bearer")]
[ApiVersion("1.0")]
[Route("v{version:apiVersion}/[controller]")]
[Produces("application/json")]
public class EmprestimoController : ControllerBase
{
    private readonly IEmprestimoService _emprestimoService;

    public EmprestimoController(IEmprestimoService emprestimoService)
    {
        _emprestimoService = emprestimoService;
    }
    
    [HttpPost, Route("adicionar-emprestimo")]
    [ProducesResponseType(201, Type = typeof(LerEmprestimoDTO))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult AdicionarEmprestimo([FromBody] AdicionarEmprestimoDTO emprestimoDto)
    {
        LerEmprestimoDTO lerEmprestimoDto = _emprestimoService.AdicionarEmprestimo(emprestimoDto);
        return CreatedAtAction(nameof(ObterEmprestimoPorId), new {Id = lerEmprestimoDto.Id}, lerEmprestimoDto);
    }
    
    [HttpGet, Route("obter-emprestimo-por-id")]
    [ProducesResponseType(200, Type = typeof(LerEmprestimoDTO))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public IActionResult ObterEmprestimoPorId(long id)
    {
        LerEmprestimoDTO lerEmprestimoDto =  _emprestimoService.ObterEmprestimoPorId(id);
        if (lerEmprestimoDto is null) 
            return NotFound(lerEmprestimoDto);
        return Ok(lerEmprestimoDto);
    }
}