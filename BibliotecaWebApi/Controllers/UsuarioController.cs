using BibliotecaWebApi.Data.DTOs.Usuario;
using BibliotecaWebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaWebApi.Controllers;

[ApiController]
[Authorize("Bearer")]
[ApiVersion("1.0")]
[Route("v{version:apiVersion}/usuario")]
[Produces("application/json")]
public class UsuarioController : ControllerBase
{
    private readonly UsuarioService _usuarioService;

    public UsuarioController(UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }
    
    [HttpPost, Route("adicionar-usuario")]
    [ProducesResponseType(201, Type = typeof(LerUsuarioDTO))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult CadastrarUsuario([FromBody] AdicionarUsuarioDTO usuarioDto)
    {
        LerUsuarioDTO lerUsuarioDto = _usuarioService.CadastrarUsuario(usuarioDto);
        return CreatedAtAction(nameof(ObterUsuarioPorId), new {Id = lerUsuarioDto.Id}, lerUsuarioDto);
    }
    
    [HttpGet, Route("listar-usuarios")]
    [ProducesResponseType(200, Type = typeof(List<LerUsuarioDTO>))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public IActionResult ListarUsuarios()
    {
        List<LerUsuarioDTO> readUsuariosDto = _usuarioService.ListarUsuarios();
        if (readUsuariosDto is null) 
            return NotFound();
        return Ok(readUsuariosDto);
    }
    
    [HttpGet, Route("obter-usuario-por-id")]
    [ProducesResponseType(200, Type = typeof(LerUsuarioDTO))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public IActionResult ObterUsuarioPorId(long id)
    {
        LerUsuarioDTO lerUsuarioDto =  _usuarioService.ObterUsuarioPorId(id);
        if (lerUsuarioDto is null) 
            return NotFound(lerUsuarioDto);
        return Ok(lerUsuarioDto);
    }
}