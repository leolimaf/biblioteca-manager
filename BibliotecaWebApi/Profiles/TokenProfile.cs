using AutoMapper;
using BibliotecaWebApi.Data.Requests;
using BibliotecaWebApi.Models;

namespace BibliotecaWebApi.Profiles;

public class TokenProfile : Profile
{
    public TokenProfile()
    {
        CreateMap<TokenValue, Token>();
    }
}