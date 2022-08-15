using FluentResults;
using LivrosAPI.Data.DTOs.Usuario;
using LivrosAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace UsuariosAPI.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class CadastroController : ControllerBase
{
    private readonly UsuarioService _usuarioService;
    
    [HttpPost, Route("[action]")]
    public IActionResult CadastrarUsuario([FromBody] AdicionarUsuarioDTO usuarioDto)
    {
        Result resultado = _usuarioService.CadastrarUsuario(usuarioDto);
        if (resultado.IsFailed)
            return StatusCode(500);
        return Ok();
    }
}