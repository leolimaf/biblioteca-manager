using AutoMapper;
using BibliotecaWebApi.Data.DTOs.Emprestimo;
using BibliotecaWebApi.Models;

namespace BibliotecaWebApi.Profiles;

public class EmprestimoProfile : Profile
{
    public EmprestimoProfile()
    {
        CreateMap<AdicionarEmprestimoDTO, Emprestimo>();
        CreateMap<Emprestimo, LerEmprestimoDTO>();
    }
}