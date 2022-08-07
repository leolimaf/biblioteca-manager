using AutoMapper;
using LivrosAPI.Data.DTOs.Autor;
using LivrosAPI.Models;

namespace LivrosAPI.Profiles;

public class AutorProfile : Profile
{
    public AutorProfile()
    {
        CreateMap<AdicionarAutorDTO, Autor>();
        CreateMap<Autor, LerAutorDTO>();
        CreateMap<AtualizarAutorDTO, Autor>();
    }
}