using LivrosAPI.Data.DTOs.Usuario;

namespace LivrosAPI.Services;

public interface IUsuarioService
{
    LerUsuarioDTO CadastrarUsuario(AdicionarUsuarioDTO usuarioDto);
    List<LerUsuarioDTO> ListarUsuarios();
    LerUsuarioDTO ObterUsuarioPorId(long id);

}