using ASP.NET_Identity.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace ASP.NET_Identity.Config
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddAuthorizationConfih(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("PodeExcluir", policy => policy.RequireClaim("PodeExcluir"));

                options.AddPolicy("PodeLer", policy => policy.AddRequirements(new PermissaoNecessaria("PodeLer")));
                options.AddPolicy("PodeEscrever", policy => policy.AddRequirements(new PermissaoNecessaria("PodeEscrever")));
            });
            return services;
        }
    }
}
