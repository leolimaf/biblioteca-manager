using LivrosAPI.Data.Requests;
using LivrosAPI.Services.Implementations;
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
    public IActionResult Signin([FromBody] LoginRequest credenciais)
    {
        if (credenciais is null)
            return BadRequest();

        var token = _autenticacaoService.AutenticarUsuario(credenciais);

        if (token is null)
            return Unauthorized();
        
        return Ok();
    }
}