using AutoMapper;
using LivrosAPI.Data.DTOs.Editora;
using LivrosAPI.Models;

namespace LivrosAPI.Profiles;

public class EditoraProfile : Profile
{
    public EditoraProfile()
    {
        CreateMap<AdicionarEditoraDTO, Editora>();
        CreateMap<Editora, LerEditoraDTO>();
        CreateMap<AtualizarEditoraDTO, Editora>();
    }
}