using FluentResults;
using LivrosAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace UsuariosAPI.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class LogoutController : ControllerBase
{
    private readonly LogoutService _logoutService;

    public LogoutController(LogoutService logoutService)
    {
        _logoutService = logoutService;
    }

    [HttpPost,  Route("[action]")]
    public IActionResult DeslogarUsuario()
    {
        Result resultado = _logoutService.DeslogarUsuario();
        if (resultado.IsFailed)
            return Unauthorized(resultado.Errors);
        return Ok(resultado.Successes);
    }
}