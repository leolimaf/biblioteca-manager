using AutoMapper;
using LivrosAPI.Data.DTOs.Emprestimo;
using LivrosAPI.Models;

namespace LivrosAPI.Profiles;

public class EmprestimoProfile : Profile
{
    public EmprestimoProfile()
    {
        CreateMap<AdicionarEmprestimoDTO, Emprestimo>();
        CreateMap<Emprestimo, LerEmprestimoDTO>();
    }
}