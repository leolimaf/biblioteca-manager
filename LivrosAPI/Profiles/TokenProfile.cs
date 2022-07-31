using AutoMapper;
using LivrosAPI.Data.Requests;
using LivrosAPI.Models;

namespace LivrosAPI.Profiles;

public class TokenProfile : Profile
{
    public TokenProfile()
    {
        CreateMap<TokenValue, Token>();
    }
}