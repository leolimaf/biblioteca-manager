using LivrosAPI.Data.DTOs.Autor;
using LivrosAPI.Data.DTOs.Livro;

namespace LivrosAPI.Data.DTOs.Trabalho;

public class LerTrabalhoDTO
{
    public long Id { get; set; }
    public LerLivroDTO Livro { get; set; }
    public LerAutorDTO Autor { get; set; }
}