using AspNetCoreRateLimit;

namespace BibliotecaWebApi.Configurations;

public class QueryStringClientIdResolveContributor : IClientResolveContributor
{
    public Task<string> ResolveClientAsync(HttpContext httpContext)
    {
        return Task.FromResult<string>(httpContext.Request.Query["APIKey"]);
    }
}