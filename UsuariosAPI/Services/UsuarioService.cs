using AutoMapper;
using FluentResults;
using LivrosAPI.Data;
using LivrosAPI.Data.DTOs.Usuario;
using LivrosAPI.Models;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data;

namespace LivrosAPI.Services;

public class UsuarioService
{
    private IMapper _mapper;
    private UserManager<IdentityUser<int>> _userManager;

    public UsuarioService(IMapper mapper, UserManager<IdentityUser<int>> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    public Result CadastrarUsuario(AdicionarUsuarioDTO usuarioDto)
    {
        Usuario usuario = _mapper.Map<Usuario>(usuarioDto);
        IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);
        Task<IdentityResult> resultadoIdentity = _userManager.CreateAsync(usuarioIdentity, usuarioDto.Senha);
        
        if (resultadoIdentity.Result.Succeeded)
            return Result.Ok();
        return Result.Fail("Erro ao cadastrar usuário");
    }
}