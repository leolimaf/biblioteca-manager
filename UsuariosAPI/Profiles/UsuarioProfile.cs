using AutoMapper;
using LivrosAPI.Data.DTOs.Usuario;
using LivrosAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace LivrosAPI.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<AdicionarUsuarioDTO, Usuario>();
        CreateMap<Usuario, IdentityUser<int>>();
    }
}