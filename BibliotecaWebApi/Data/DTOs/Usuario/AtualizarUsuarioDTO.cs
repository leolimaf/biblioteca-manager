namespace BibliotecaWebApi.Data.DTOs.Usuario;

public class AtualizarUsuarioDTO
{
    public string Matricula { get; set; }
    public string Senha { get; set; }
    public string NomeCompleto { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
}