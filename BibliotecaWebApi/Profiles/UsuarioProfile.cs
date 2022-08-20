using AutoMapper;
using BibliotecaWebApi.Data.DTOs.Usuario;
using BibliotecaWebApi.Models;

namespace BibliotecaWebApi.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<AdicionarUsuarioDTO, Usuario>();
        CreateMap<Usuario, LerUsuarioDTO>();
        CreateMap<AtualizarUsuarioDTO, Livro>();
    }
}