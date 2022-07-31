using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using FluentResults;
using LivrosAPI.Data;
using LivrosAPI.Data.Requests;
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

    public Usuario AutenticarUsuario(LoginRequest credenciais)
    {
        var senha = ComputeHash(credenciais.Senha, new SHA256CryptoServiceProvider());
        return _context.Usuarios.FirstOrDefault(u => u.Matricula == credenciais.Matricula && u.Senha == credenciais.Senha);
    }

    public Usuario AtualizarDadosCadastrados(Usuario dadosDoUsuario)
    {

        Usuario usuario = _context.Usuarios.FirstOrDefault(u => u.Matricula == dadosDoUsuario.Matricula);
        
        if (usuario is null)
            return null;
        _mapper.Map(dadosDoUsuario, usuario);
        _context.SaveChanges();
        return usuario;
    }

    private string ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
    {
        byte[] inputBytes = Encoding.UTF8.GetBytes(input);
        byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
        return BitConverter.ToString(hashedBytes);
    }
}