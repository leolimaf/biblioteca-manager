using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using LivrosAPI.Configurations;
using LivrosAPI.Data;
using LivrosAPI.Data.Requests;
using LivrosAPI.Models;

namespace LivrosAPI.Services.Implementations;

public class AutenticacaoService : IAutenticacaoService
{
    private AppDbContext _context;
    private IMapper _mapper;
    private TokenConfiguration _configuration;
    private ITokenService _tokenService;
    private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";

    public AutenticacaoService(AppDbContext context, IMapper mapper, TokenConfiguration configuration, ITokenService tokenService)
    {
        _context = context;
        _mapper = mapper;
        _configuration = configuration;
        _tokenService = tokenService;
    }

    public Token AutenticarUsuario(LoginRequest credenciais)
    {
        var senha = ComputeHash(credenciais.Senha, new SHA256CryptoServiceProvider());
        var usuario =  _context.Usuarios.FirstOrDefault(u => u.Matricula == credenciais.Matricula && u.Senha == credenciais.Senha);
        
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
        
        Usuario user = _context.Usuarios.FirstOrDefault(u => u.Matricula == usuario.Matricula);
        
        if (user is null)
            return null;
        // _mapper.Map(user, usuario); TODO: AJUSTAR
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
    
    private string ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
    {
        byte[] inputBytes = Encoding.UTF8.GetBytes(input);
        byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
        return BitConverter.ToString(hashedBytes);
    }
}