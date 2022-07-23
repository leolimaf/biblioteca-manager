using AutoMapper;
using LivrosAPI.Data.DTOs.Livro;
using LivrosAPI.Models;

namespace LivrosAPI.Profiles;

public class LivroProfile : Profile
{
    public LivroProfile()
    {
        CreateMap<AdicionarLivroDTO, Livro>();
        CreateMap<Livro, LerLivroDTO>();
        CreateMap<AtualizarLivroDTO, Livro>();
    }
}