using LivrosAPI.Data.Requests;
using LivrosAPI.Models;

namespace LivrosAPI.Services.Implementations;

public interface IAutenticacaoService
{
    Token AutenticarUsuario(LoginRequest credenciais);
    Token AutenticarUsuario(TokenValue tokenValue);
    bool RevokeToken(string matricula);
}