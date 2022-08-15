using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using LivrosAPI.Configurations;
using LivrosAPI.Data;
using LivrosAPI.Data.Requests;
using LivrosAPI.Models;

namespace LivrosAPI.Services;

public class AutenticacaoService
{
    private AppDbContext _context;
    private IMapper _mapper;
    private TokenConfiguration _configuration;
    private TokenService _tokenService;
    private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";

    public AutenticacaoService(AppDbContext context, IMapper mapper, TokenConfiguration configuration, TokenService tokenService)
    {
        _context = context;
        _mapper = mapper;
        _configuration = configuration;
        _tokenService = tokenService;
    }

    public Token AutenticarUsuario(LoginRequest credenciais)
    {
        var senha = ComputeHash(credenciais.Senha, new SHA256CryptoServiceProvider());
        var usuario =  _context.Usuarios.FirstOrDefault(u => u.Matricula == credenciais.Matricula && u.Senha == senha);
        
        if (usuario is null)
            return null;
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
            new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Matricula)
        };

        var accessToken = _tokenService.GenerateAccessToken(claims);
        var refreshToken = _tokenService.GenerateRefreshToken();

        usuario.Token = refreshToken;
        usuario.ValidadeToken = DateTime.Now.AddDays(_configuration.DaysToExpiry);
        
        var user = _context.Usuarios.FirstOrDefault(u => u.Matricula == usuario.Matricula);
        
        if (user is null)
            return null;
        _context.SaveChanges();

        DateTime dataCriacao = DateTime.Now;
        DateTime dataExpiracao = dataCriacao.AddMinutes(_configuration.Minutes);
        
        return new Token(
            true, 
            dataCriacao.ToString(DATE_FORMAT), 
            dataExpiracao.ToString(DATE_FORMAT),
            accessToken,
            refreshToken
            );
    }
    
    public Token AutenticarUsuario(TokenValue tokenValue)
    {
        var accessToken = tokenValue.AccessToken;
        var refreshToken = tokenValue.RefreshToken;

        var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);
        var matricula = principal.Identity.Name;
        var usuario = _context.Usuarios.FirstOrDefault(u => u.Matricula == matricula);

        if (usuario is null || usuario.Token != refreshToken || usuario.ValidadeToken <= DateTime.Now)
            return null;

        accessToken = _tokenService.GenerateAccessToken(principal.Claims);
        refreshToken = _tokenService.GenerateRefreshToken();

        usuario.Token = refreshToken;
        
        var user = _context.Usuarios.FirstOrDefault(u => u.Matricula == usuario.Matricula);
        
        if (user is null)
            return null;
        _context.SaveChanges();

        DateTime dataCriacao = DateTime.Now;
        DateTime dataExpiracao = dataCriacao.AddMinutes(_configuration.Minutes);
        
        return new Token(
            true, 
            dataCriacao.ToString(DATE_FORMAT), 
            dataExpiracao.ToString(DATE_FORMAT),
            accessToken,
            refreshToken
        );
    }

    public bool RevokeToken(string matricula)
    {
        var usuario = _context.Usuarios.FirstOrDefault(u => (u.Matricula == matricula));
        
        if (usuario is null)
            return false;
        
        usuario.Token = null;
        _context.SaveChanges();
        
        return true;
    }

    private string ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
    {
        byte[] inputBytes = Encoding.UTF8.GetBytes(input);
        byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
        return BitConverter.ToString(hashedBytes);
    }
}