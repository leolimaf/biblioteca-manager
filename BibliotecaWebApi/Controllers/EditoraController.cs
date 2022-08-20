using BibliotecaWebApi.Data.DTOs.Editora;
using BibliotecaWebApi.Services;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaWebApi.Controllers;

[ApiController]
[Authorize("Bearer")]
[ApiVersion("1.0")]
[Route("v{version:apiVersion}/editora")]
[Produces("application/json")]
public class EditoraController : ControllerBase
{
    private readonly EditoraService _editoraService;

    public EditoraController(EditoraService editoraService)
    {
        _editoraService = editoraService;
    }
    
    [HttpPost, Route("adicionar-editora")]
    [ProducesResponseType(201, Type = typeof(LerEditoraDTO))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult AdicionarEditora([FromBody] AdicionarEditoraDTO editoraDto)
    {
        LerEditoraDTO lerEditoraDto = _editoraService.AdicionarEditora(editoraDto);
        return CreatedAtAction(nameof(ObterEditoraPorId), new {Id = lerEditoraDto.Id}, lerEditoraDto);
    }
    
    [HttpGet, Route("listar-editoras")]
    [ProducesResponseType(200, Type = typeof(List<LerEditoraDTO>))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public IActionResult ListarEditoras()
    {
        List<LerEditoraDTO> readEditorasDto = _editoraService.ListarEditoras();
        if (readEditorasDto is null) 
            return NotFound();
        return Ok(readEditorasDto);
    }
    
    [HttpGet, Route("obter-editora-por-id")]
    [ProducesResponseType(200, Type = typeof(LerEditoraDTO))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public IActionResult ObterEditoraPorId(long id)
    {
        LerEditoraDTO lerEditoraDto =  _editoraService.ObterEditoraPorId(id);
        if (lerEditoraDto is null) 
            return NotFound(lerEditoraDto);
        return Ok(lerEditoraDto);
    }
    
    [HttpPut, Route("atualizar-editora-por-id")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult AtualizarEditoraPorId(long id, [FromBody] AtualizarEditoraDTO editoraDto)
    {
        Result result = _editoraService.AtualizarEditoraPorId(id, editoraDto);
        if (result.IsFailed)
            return NotFound();
        return NoContent();
    }
    
    [HttpDelete, Route("remover-editora-por-id")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult RemoverEditoraPorId(long id)
    {
        Result result = _editoraService.RemoverEditoraPorId(id);
        if (result.IsFailed)
            return NotFound();
        return NoContent();
    }
}