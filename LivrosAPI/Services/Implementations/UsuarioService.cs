using AutoMapper;
using LivrosAPI.Data;
using LivrosAPI.Data.DTOs.Usuario;
using LivrosAPI.Models;

namespace LivrosAPI.Services.Implementations;

public class UsuarioService : IUsuarioService
{
    private AppDbContext _context;
    private IMapper _mapper;

    public UsuarioService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public LerUsuarioDTO CadastrarUsuario(AdicionarUsuarioDTO usuarioDto)
    {
        Usuario usuario = _mapper.Map<Usuario>(usuarioDto);
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
        return _mapper.Map<LerUsuarioDTO>(usuario);
    }

    public List<LerUsuarioDTO> ListarUsuarios()
    {
        List<Usuario> usuarios = _context.Usuarios.ToList();
        return _mapper.Map<List<LerUsuarioDTO>>(usuarios);
    }

    public LerUsuarioDTO ObterUsuarioPorId(long id)
    {
        Usuario usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.Id == id);
        if (usuario is not null)
        {
            LerUsuarioDTO usuarioDto = _mapper.Map<LerUsuarioDTO>(usuario);
            return usuarioDto;
        }
        return null;
    }
}