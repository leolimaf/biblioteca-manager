using AutoMapper;
using BibliotecaWebApi.Data.DTOs.Livro;
using BibliotecaWebApi.Models;

namespace BibliotecaWebApi.Profiles;

public class LivroProfile : Profile
{
    public LivroProfile()
    {
        CreateMap<AdicionarLivroDTO, Livro>();
        CreateMap<Livro, LerLivroDTO>();
        CreateMap<AtualizarLivroDTO, Livro>();
    }
}