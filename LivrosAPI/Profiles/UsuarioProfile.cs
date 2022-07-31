using AutoMapper;
using LivrosAPI.Data.DTOs.Usuario;
using LivrosAPI.Models;

namespace LivrosAPI.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<AdicionarUsuarioDTO, Usuario>();
    }
}