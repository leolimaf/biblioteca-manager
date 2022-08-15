using FluentResults;
using LivrosAPI.Models;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.Requests;

namespace LivrosAPI.Services;

public class LoginService
{
    private SignInManager<IdentityUser<int>> _signInManager;
    private TokenService _tokenService;

    public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService)
    {
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public Result LogarUsuario(LoginRequest request)
    {
        var resultadoIdentity = _signInManager
            .PasswordSignInAsync(request.Username, request.Password, false, false);
        if (resultadoIdentity.Result.Succeeded)
        {
            var identityUser = _signInManager
                .UserManager
                .Users
                .FirstOrDefault(u => u.NormalizedUserName == request.Username.ToUpper());
            Token token = _tokenService.AdicionarToken(identityUser);
            return Result.Ok().WithSuccess(token.Value);
        }
        return Result.Fail("Credenciais inválidas");
    }
}