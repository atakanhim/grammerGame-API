using grammerGame.Application.Abstractions.Services.Authentications;
using grammerGame.Application.Abstractions.Services;
using grammerGame.Domain.Entities.Identity;
using grammerGame.Persistence.Context;
using grammerGame.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using grammerGame.Application.Mappings;
using grammerGame.Application.Repositories;
using grammerGame.Persistence.Repositories;


namespace grammerGame.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            // context
            //microsoft.extension.configrutaion added json dosyayı okucaz

            //services.AddDbContext<GrammerGameDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));
            services.AddAutoMapper(typeof(grammerGameProfile));

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;

            }).AddEntityFrameworkStores<GrammerGameDbContext>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IExternalAuthentication, AuthService>();
            services.AddScoped<IInternalAuthentication, AuthService>();

            services.AddScoped<IGameProgressReadRepository, GameProgressReadRepository>();
            services.AddScoped<IGameProgressWriteRepository, GameProgressWriteRepository>();


        }

    }
}
