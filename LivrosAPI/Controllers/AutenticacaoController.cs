using LivrosAPI.Data.Requests;
using LivrosAPI.Models;
using LivrosAPI.Services.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LivrosAPI.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("v{version:apiVersion}/[controller]")]
[Produces("application/json")]
public class AutenticacaoController : ControllerBase
{
    private readonly IAutenticacaoService _autenticacaoService;

    public AutenticacaoController(IAutenticacaoService autenticacaoService)
    {
        _autenticacaoService = autenticacaoService;
    }

    [HttpPost]
    [Route("[action]")]
    public IActionResult Login([FromBody] LoginRequest credenciais)
    {
        if (credenciais is null)
            return BadRequest("Invalid client request");
        
        var token = _autenticacaoService.AutenticarUsuario(credenciais);
        
        if (token is null)
            return Unauthorized();
        
        return Ok(token);
    }

    [HttpPost]
    [Route("[action]")]
    public IActionResult Refresh([FromBody] TokenValue tokenValue)
    {
        if (tokenValue is null)
            return BadRequest("Invalid client request");

        var token = _autenticacaoService.AutenticarUsuario(tokenValue);

        if (token is null)
            return BadRequest("Invalid client request");
        
        return Ok(token);
    }

    [HttpGet]
    [Authorize("Bearer")]
    [Route("[action]")]
    public IActionResult Revoke()
    {
        var matricula = User.Identity.Name;
        var result = _autenticacaoService.RevokeToken(matricula);

        if (!result)
            return BadRequest("Ivalid client request");
        
        return NoContent();
    }
}