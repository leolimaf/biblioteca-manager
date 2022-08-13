using LivrosAPI.Data.DTOs.Emprestimo;

namespace LivrosAPI.Data.DTOs.Usuario;

public class LerUsuarioDTO
{
    public long Id { get; set; }
    public string Matricula { get; set; }
    public string NomeCompleto { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public virtual List<LerEmprestimoDTO> Emprestimos { get; set; }
}