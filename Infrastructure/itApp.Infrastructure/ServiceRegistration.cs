using grammerGame.Application.Abstractions.Token;
using grammerGame.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;


namespace grammerGame.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {

            services.AddScoped<ITokenHandler, TokenHandler>();
        }
    }
}
