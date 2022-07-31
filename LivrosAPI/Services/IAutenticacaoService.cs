using LivrosAPI.Data.Requests;
using LivrosAPI.Models;

namespace LivrosAPI.Services.Implementations;

public interface IAutenticacaoService
{
    Token AutenticarUsuario(LoginRequest credenciais);
}