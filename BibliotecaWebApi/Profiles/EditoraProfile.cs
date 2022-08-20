using AutoMapper;
using BibliotecaWebApi.Data.DTOs.Editora;
using BibliotecaWebApi.Models;

namespace BibliotecaWebApi.Profiles;

public class EditoraProfile : Profile
{
    public EditoraProfile()
    {
        CreateMap<AdicionarEditoraDTO, Editora>();
        CreateMap<Editora, LerEditoraDTO>();
        CreateMap<AtualizarEditoraDTO, Editora>();
    }
}