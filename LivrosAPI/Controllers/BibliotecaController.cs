using FluentResults;
using LivrosAPI.Data.DTOs.Livro;
using LivrosAPI.Data.DTOs.Usuario;
using LivrosAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LivrosAPI.Controllers;

[ApiController]
[Authorize("Bearer")]
[ApiVersion("1.0")]
[Route("v{version:apiVersion}/biblioteca")]
[Produces("application/json")]
public class BibliotecaController : ControllerBase
{

    private readonly ILivroService _livroService;
    private readonly IUsuarioService _usuarioService;

    public BibliotecaController(ILivroService livroService, IUsuarioService usuarioService)
    {
        _livroService = livroService;
        _usuarioService = usuarioService;
    }

    /// <remarks>
    ///	O endpoint adiciona um novo livro (schema AdicionarLivroDTO) na base de dados.
    ///	
    ///      Parâmetros obrigatórios:                      
    ///      titulo, isbn-13 e autor.
    /// 
    ///      O parâmetro isbn-10 deve ter exatamente 10 caracteres.
    ///      O parâmetro isbn-13 deve ter exatamente 13 caracteres.
    ///     
    /// </remarks>
    /// <response code="201">Retorna o livro que foi adicionado (schema LerLivroDTO).</response>
    /// <response code="400">Se o payload informado não estiver conforme a especificação.</response>
    /// <response code="401">Caso o cliente não possua um token válido para realizar a requisição.</response>
    [HttpPost, Route("livro/adicionar-livro")]
    [ProducesResponseType(201, Type = typeof(LerLivroDTO))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult AdicionarLivro([FromBody] AdicionarLivroDTO livroDto)
    {
        LerLivroDTO lerLivroDto = _livroService.AdicionarLivro(livroDto);
        return CreatedAtAction(nameof(ObterLivroPorId), new {Id = lerLivroDto.Id}, lerLivroDto);
    }
    
    [HttpGet, Route("livro/listar-livros")]
    [ProducesResponseType(200, Type = typeof(List<LerLivroDTO>))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public IActionResult ListarLivros([FromQuery] string? generos, string? autor, string? editora)
    {
        List<LerLivroDTO> readLivrosDto = _livroService.ListarLivros(generos, autor, editora);
        if (readLivrosDto is null) 
            return NotFound();
        return Ok(readLivrosDto);
    }
    
    [HttpGet, Route("livro/obter-livro-por-id")]
    [ProducesResponseType(200, Type = typeof(LerLivroDTO))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public IActionResult ObterLivroPorId(long id)
    {
        LerLivroDTO lerLivroDto =  _livroService.ObterLivroPorId(id);
        if (lerLivroDto is null) 
            return NotFound(lerLivroDto);
        return Ok(lerLivroDto);
    }
    
    [HttpGet, Route("livro/obter-livro-por-isbn-13")]
    [ProducesResponseType(200, Type = typeof(LerLivroDTO))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public IActionResult ObterLivroPorIsbn13(string isbn13)
    {
        LerLivroDTO lerLivroDto =  _livroService.ObterLivroPorIsbn13(isbn13);
        if (lerLivroDto is null) 
            return NotFound(lerLivroDto);
        return Ok(lerLivroDto);
    }

    [HttpGet, Route("livro/obter-livro-por-titulo")]
    [ProducesResponseType(200, Type = typeof(LerLivroDTO))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public IActionResult ObterLivroPorTitulo([FromQuery] string titulo, [FromQuery] string subTitulo)
    {
        List<LerLivroDTO> lerLivroDto =  _livroService.ObterLivroPorTitulo(titulo, subTitulo);
        if (lerLivroDto is null) 
            return NotFound(lerLivroDto);
        return Ok(lerLivroDto);
    }
    
    [HttpPut, Route("livro/atualizar-livro-por-id")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult AtualizarLivroPorId(long id, AtualizarLivroDTO livroDto)
    {
        Result result = _livroService.AtualizarLivroPorId(id, livroDto);
        if (result.IsFailed)
            return NotFound();
        return NoContent();
    }
    
    [HttpPut, Route("livro/atualizar-livro-por-isbn-13")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult AtualizarLivroPorIsbn13(string isbn13, AtualizarLivroDTO livroDto)
    {
        Result result = _livroService.AtualizarLivroPorIsbn13(isbn13, livroDto);
        if (result.IsFailed)
            return NotFound();
        return NoContent();
    }
    
    [HttpDelete, Route("livro/remover-livro-por-id")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult RemoverLivroPorId(long id)
    {
        Result result = _livroService.RemoverLivroPorId(id);
        if (result.IsFailed)
            return NotFound();
        return NoContent();
    }
    
    [HttpDelete, Route("livro/remover-livro-por-isbn-13")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult RemoverLivroPorIsbn13(string isbn)
    {
        Result result = _livroService.RemoverLivroPorIsbn13(isbn);
        if (result.IsFailed)
            return NotFound();
        return NoContent();
    }
    
    /// <remarks>
    ///	O endpoint adiciona um novo usuario (schema AdicionarUsuarioDTO) na base de dados.
    ///	
    ///      Todos os parâmetros são obrigatórios.
    /// 
    ///      O parâmetro matricula deve ter no mínimo 6 e no máximo 12 caracteres.
    ///      O parâmetro senha deve ter no mínimo 8 e no máximo 25 caracteres.
    ///      O parâmetro cpf deve ter exatamente 11 caracteres numéricos.
    ///     
    /// </remarks>
    /// <response code="201">Retorna o usuario que foi cadastrado (schema LerUsuarioDTO).</response>
    /// <response code="400">Se o payload informado não estiver conforme a especificação.</response>
    /// <response code="401">Caso o cliente não possua um token válido para realizar a requisição.</response>
    [HttpPost, Route("usuario/adicionar-usuario")]
    [ProducesResponseType(201, Type = typeof(LerUsuarioDTO))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult CadastrarUsuario([FromBody] AdicionarUsuarioDTO usuarioDto)
    {
        LerUsuarioDTO lerUsuarioDto = _usuarioService.CadastrarUsuario(usuarioDto);
        return CreatedAtAction(nameof(ObterUsuarioPorId), new {Id = lerUsuarioDto.Id}, lerUsuarioDto);
    }
    
    [HttpGet, Route("usuario/listar-usuarios")]
    [ProducesResponseType(200, Type = typeof(List<LerUsuarioDTO>))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public IActionResult ListarUsuarios()
    {
        List<LerUsuarioDTO> readUsuariosDto = _usuarioService.ListarUsuarios();
        if (readUsuariosDto is null) 
            return NotFound();
        return Ok(readUsuariosDto);
    }
    
    [HttpGet, Route("usuario/obter-usuario-por-id")]
    [ProducesResponseType(200, Type = typeof(LerUsuarioDTO))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public IActionResult ObterUsuarioPorId(long id)
    {
        LerUsuarioDTO lerUsuarioDto =  _usuarioService.ObterUsuarioPorId(id);
        if (lerUsuarioDto is null) 
            return NotFound(lerUsuarioDto);
        return Ok(lerUsuarioDto);
    }
}