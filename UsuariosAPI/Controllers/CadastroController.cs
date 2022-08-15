using FluentResults;
using LivrosAPI.Data.DTOs.Usuario;
using LivrosAPI.Services;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.Requests;

namespace UsuariosAPI.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class CadastroController : ControllerBase
{
    private readonly CadastroService _cadastroService;

    public CadastroController(CadastroService cadastroService)
    {
        _cadastroService = cadastroService;
    }

    [HttpPost, Route("[action]")]
    public IActionResult CadastrarUsuario([FromBody] AdicionarUsuarioDTO usuarioDto)
    {
        Result resultado = _cadastroService.CadastrarUsuario(usuarioDto);
        if (resultado.IsFailed)
            return StatusCode(500);
        return Ok(resultado.Successes);
    }
}