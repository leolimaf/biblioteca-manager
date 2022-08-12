using AutoMapper;
using LivrosAPI.Data.DTOs.Trabalho;
using LivrosAPI.Models;

namespace LivrosAPI.Profiles;

public class TrabalhoProfile : Profile
{
    public TrabalhoProfile()
    {
        CreateMap<AdicionarTrabalhoDTO, Trabalho>();
        CreateMap<Trabalho, LerTrabalhoDTO>();
    }
}