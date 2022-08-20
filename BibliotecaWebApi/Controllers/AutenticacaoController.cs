using BibliotecaWebApi.Data.DTOs.Usuario;
using BibliotecaWebApi.Data.Requests;
using BibliotecaWebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaWebApi.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("v{version:apiVersion}/autenticacao")]
[Produces("application/json")]
public class AutenticacaoController : ControllerBase
{
    private readonly AutenticacaoService _autenticacaoService;

    public AutenticacaoController(AutenticacaoService autenticacaoService)
    {
        _autenticacaoService = autenticacaoService;
    }
    
    [HttpPost, Route("registrar")]
    public IActionResult Registrar([FromBody] AdicionarUsuarioDTO usuarioDto)
    {
        LerUsuarioDTO lerUsuarioDto = _autenticacaoService.RegistrarUsuario(usuarioDto);
        return CreatedAtAction(nameof(ObterUsuarioPorId), new {Id = lerUsuarioDto.Id}, lerUsuarioDto);
    }

    [HttpPost]
    [Route("logar")]
    public IActionResult Logar([FromBody] LoginRequest credenciais)
    {
        if (credenciais is null)
            return BadRequest("Invalid client request");
        
        var token = _autenticacaoService.AutenticarUsuario(credenciais);
        
        if (token is null)
            return Unauthorized();
        
        return Ok(token);
    }

    [HttpPost]
    [Authorize(Policy = "Bearer")]
    [Route("atualizar-token")]
    public IActionResult AtualizarToken([FromBody] TokenValue tokenValue)
    {
        if (tokenValue is null)
            return BadRequest("Invalid client request");

        var token = _autenticacaoService.AutenticarUsuario(tokenValue);

        if (token is null)
            return Unauthorized("Invalid client request");
        
        return Ok(token);
    }

    [HttpGet]
    [Authorize("Bearer")]
    [Route("deslogar")]
    public IActionResult Deslogar()
    {
        var matricula = User.Identity.Name;
        var result = _autenticacaoService.RevokeToken(matricula);

        if (!result)
            return BadRequest("Invalid client request");
        
        return NoContent();
    }

    [HttpGet]
    [Authorize(Policy = "Bearer", Roles = "Admin")]
    [Route("obter-usuario-por-id")]
    public IActionResult ObterUsuarioPorId(long id)
    {
        LerUsuarioDTO lerUsuarioDto =  _autenticacaoService.ObterUsuarioPorId(id);
        if (lerUsuarioDto is null) 
            return NotFound(lerUsuarioDto);
        return Ok(lerUsuarioDto);
    }
    
    [HttpGet]
    [Authorize(Policy = "Bearer", Roles = "Admin")]
    [Route("listar-usuarios")]
    public IActionResult ListarUsuarios()
    {
        List<LerUsuarioDTO> readUsuariosDto = _autenticacaoService.ListarUsuarios();
        if (readUsuariosDto is null) 
            return NotFound();
        return Ok(readUsuariosDto);
    }
}