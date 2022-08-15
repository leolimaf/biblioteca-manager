using System.Web;
using AutoMapper;
using FluentResults;
using LivrosAPI.Data.DTOs.Usuario;
using LivrosAPI.Models;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.Requests;

namespace LivrosAPI.Services;

public class CadastroService
{
    private IMapper _mapper;
    private UserManager<IdentityUser<int>> _userManager;

    public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    public Result CadastrarUsuario(AdicionarUsuarioDTO usuarioDto)
    {
        Usuario usuario = _mapper.Map<Usuario>(usuarioDto);
        IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);
        Task<IdentityResult> resultadoIdentity = _userManager.CreateAsync(usuarioIdentity, usuarioDto.Password);
        
        if (resultadoIdentity.Result.Succeeded)
            return Result.Ok();
        return Result.Fail("Falha ao cadastrar usuário");
    }
}