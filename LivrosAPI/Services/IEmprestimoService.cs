using LivrosAPI.Data.DTOs.Emprestimo;

namespace LivrosAPI.Services;

public interface IEmprestimoService
{
    LerEmprestimoDTO AdicionarEmprestimo(AdicionarEmprestimoDTO emprestimoDto);
    LerEmprestimoDTO ObterEmprestimoPorId(long id);
}