using FluentResults;
using LivrosAPI.Services;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.Requests;

namespace UsuariosAPI.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class LoginController : ControllerBase
{
    private readonly LoginService _loginService;

    public LoginController(LoginService loginService)
    {
        _loginService = loginService;
    }
    
    [HttpPost, Route("[action]")]
    public IActionResult LogarUsuario( LoginRequest request)
    {
        Result resultado = _loginService.LogarUsuario(request);
        if (resultado.IsFailed)
            return Unauthorized(resultado.Errors);
        return Ok(resultado.Successes);
    }
}