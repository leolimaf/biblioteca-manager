using LivrosAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LivrosAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class LivroController : ControllerBase
{
    public static List<Livro?> Livros { get; set; } = new List<Livro?>();
    private static int id = 1;
    
    [HttpPost]
    public IActionResult AdicionarLivro([FromBody] Livro? livro)
    {
        livro.Id = id++;
        Livros.Add(livro);
        return CreatedAtAction(nameof(AdicionarLivro), new {Id = livro.Id}, livro);
    }

    [HttpGet]
    public IActionResult ListarLivros()
    {
        return Ok(Livros);
    }
    
    [HttpGet("{id:int}")]
    public IActionResult ObterLivroPorId(int id)
    {
        var livro =  Livros.FirstOrDefault(l => l.Id == id);
        if (livro != null)
        {
            Ok(livro);
        }
        return NotFound(livro);
    }
}