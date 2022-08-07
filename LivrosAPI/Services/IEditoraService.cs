using FluentResults;
using LivrosAPI.Data.DTOs.Editora;

namespace LivrosAPI.Services;

public interface IEditoraService
{
    LerEditoraDTO AdicionarEditora(AdicionarEditoraDTO autorDto);
    LerEditoraDTO ObterEditoraPorId(long id);
    List<LerEditoraDTO> ListarEditoras();
    Result AtualizarEditoraPorId(long id, AtualizarEditoraDTO editoraDto);
    Result RemoverEditoraPorId(long id);
}