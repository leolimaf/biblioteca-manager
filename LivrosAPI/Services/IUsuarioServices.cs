using FluentResults;
using LivrosAPI.Data.Requests;
using LivrosAPI.Models;

namespace LivrosAPI.Services;

public interface IUsuarioService
{
    Usuario AutenticarUsuario(LoginRequest credenciais);
    Usuario AtualizarDadosCadastrados(Usuario credenciais);
}