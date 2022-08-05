using LivrosAPI.Data.DTOs.Usuario;

namespace LivrosAPI.Services;

public interface IUsuarioService
{
    LerUsuarioDTO CadastrarUsuario(AdicionarUsuarioDTO livro);
    List<LerUsuarioDTO> ListarUsuarios();
    LerUsuarioDTO ObterUsuarioPorId(long id);

}