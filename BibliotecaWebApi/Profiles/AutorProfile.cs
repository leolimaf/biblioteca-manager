using AutoMapper;
using BibliotecaWebApi.Data.DTOs.Autor;
using BibliotecaWebApi.Models;

namespace BibliotecaWebApi.Profiles;

public class AutorProfile : Profile
{
    public AutorProfile()
    {
        CreateMap<AdicionarAutorDTO, Autor>();
        CreateMap<Autor, LerAutorDTO>();
        CreateMap<AtualizarAutorDTO, Autor>();
    }
}