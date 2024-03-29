using AspNetCoreRateLimit;
using Microsoft.Extensions.Options;

namespace BibliotecaWebApi.Configurations;

public class CustomRateLimitConfiguration : RateLimitConfiguration
{
    public CustomRateLimitConfiguration(IOptions<IpRateLimitOptions> ipOptions, 
        IOptions<ClientRateLimitOptions> clientOptions)
        : base(ipOptions, clientOptions)
    {
    }

    public override void RegisterResolvers()
    {
        ClientResolvers.Add(new QueryStringClientIdResolveContributor());
    }
}