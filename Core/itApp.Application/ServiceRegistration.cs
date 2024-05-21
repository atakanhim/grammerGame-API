
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using grammerGame.Application.Mappings;
using grammerGame.Application.Abstractions.Services;
using grammerGame.Application.Abstractions.Utilities;
using grammerGame.Application.Utilities;

namespace grammerGame.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            
            services.AddMediatR(typeof(ServiceRegistration)); // bu sınıfın bulundugu assemlbdeki tüm , ihandler , irequest sınıflarını bul ve aracı ol
            services.AddSingleton<ICustomGuidConverter, CustomGuidConverter>();

        }
    }
}