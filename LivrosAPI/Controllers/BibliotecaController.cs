using FluentResults;
using LivrosAPI.Data.DTOs.Livro;
using LivrosAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LivrosAPI.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("v{version:apiVersion}/livro")]
[Produces("application/json")]
public class BibliotecaController : ControllerBase
{

    private readonly BibliotecaService _bibliotecaService;

    public BibliotecaController(BibliotecaService bibliotecaService)
    {
        _bibliotecaService = bibliotecaService;
    }

    /// <remarks>
    ///	O endpoint adiciona um novo livro (schema AdicionarLivroDTO) na base de dados.
    ///	
    ///      Parâmetros obrigatórios:                      
    ///      titulo, isbn-13 e autor.
    /// 
    ///      O parâmetro isbn-13 deve ter exatamente 13 caracteres.
    ///     
    /// </remarks>
    /// <response code="201">Retorna o livro que foi adicionado (schema LerLivroDTO).</response>
    /// <response code="400">Se o payload informado não estiver conforme a especificação.</response>
    /// <response code="401">Caso o cliente não possua um token válido para realizar a requisição.</response>
    [HttpPost, Route("adicionar-livro")]
    [ProducesResponseType(201, Type = typeof(LerLivroDTO))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult AdicionarLivro([FromBody] AdicionarLivroDTO livroDto)
    {
        LerLivroDTO lerLivroDto = _bibliotecaService.AdicionarLivro(livroDto);
        return CreatedAtAction(nameof(ObterLivroPorId), new {Id = lerLivroDto.Id}, lerLivroDto);
    }
    
    [HttpGet, Route("listar-livros")]
    [ProducesResponseType(200, Type = typeof(List<LerLivroDTO>))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public IActionResult ListarLivros()
    {
        List<LerLivroDTO> readLivrosDto = _bibliotecaService.ListarLivros();
        if (readLivrosDto is null) 
            return NotFound();
        return Ok(readLivrosDto);
    }
    
    [HttpGet, Route("obter-livro-por-id")]
    [ProducesResponseType(200, Type = typeof(LerLivroDTO))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public IActionResult ObterLivroPorId(long id)
    {
        LerLivroDTO lerLivroDto =  _bibliotecaService.ObterLivroPorId(id);
        if (lerLivroDto is null) 
            return NotFound(lerLivroDto);
        return Ok(lerLivroDto);
    }
    
    [HttpGet, Route("obter-livro-por-isbn-13")]
    [ProducesResponseType(200, Type = typeof(LerLivroDTO))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public IActionResult ObterLivroPorIsbn13(string isbn13)
    {
        LerLivroDTO lerLivroDto =  _bibliotecaService.ObterLivroPorIsbn13(isbn13);
        if (lerLivroDto is null) 
            return NotFound(lerLivroDto);
        return Ok(lerLivroDto);
    }

    [HttpGet, Route("obter-livro-por-titulo")]
    [ProducesResponseType(200, Type = typeof(LerLivroDTO))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public IActionResult ObterLivroPorTitulo([FromQuery] string titulo, [FromQuery] string subTitulo)
    {
        List<LerLivroDTO> lerLivroDto =  _bibliotecaService.ObterLivroPorTitulo(titulo, subTitulo);
        if (lerLivroDto is null) 
            return NotFound(lerLivroDto);
        return Ok(lerLivroDto);
    }
    
    [HttpPut, Route("atualizar-livro-por-id")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult AtualizarLivroPorId(long id, AtualizarLivroDTO livroDto)
    {
        Result result = _bibliotecaService.AtualizarLivroPorId(id, livroDto);
        if (result.IsFailed)
            return NotFound();
        return NoContent();
    }
    
    [HttpPut, Route("atualizar-livro-por-isbn-13")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult AtualizarLivroPorIsbn13(string isbn13, AtualizarLivroDTO livroDto)
    {
        Result result = _bibliotecaService.AtualizarLivroPorIsbn13(isbn13, livroDto);
        if (result.IsFailed)
            return NotFound();
        return NoContent();
    }
    
    [HttpDelete, Route("remover-livro-por-id")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult RemoverLivroPorId(long id)
    {
        Result result = _bibliotecaService.RemoverLivroPorId(id);
        if (result.IsFailed)
            return NotFound();
        return NoContent();
    }
    
    [HttpDelete, Route("remover-livro-por-isbn-13")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult RemoverLivroPorIsbn13(string isbn)
    {
        Result result = _bibliotecaService.RemoverLivroPorIsbn13(isbn);
        if (result.IsFailed)
            return NotFound();
        return NoContent();
    }
}