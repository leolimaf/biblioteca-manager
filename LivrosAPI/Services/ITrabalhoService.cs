using LivrosAPI.Data.DTOs.Trabalho;

namespace LivrosAPI.Services;

public interface ITrabalhoService
{
    LerTrabalhoDTO AdicionarTrabalho(AdicionarTrabalhoDTO trabalhoDto);
    LerTrabalhoDTO ObterTrabalhoPorId(long id);
}