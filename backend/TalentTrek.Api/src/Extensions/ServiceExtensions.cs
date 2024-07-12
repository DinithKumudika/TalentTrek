using Microsoft.EntityFrameworkCore;
using Serilog;
using TalentTrek.Api.Data;
using TalentTrek.Api.Repositories;
using TalentTrek.Api.Repositories.Interfaces;
using TalentTrek.Api.Services;
using TalentTrek.Api.Services.Interfaces;

namespace TalentTrek.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
        }

        public static void AddLogger(this IHostBuilder hostBuilder)
        {
            hostBuilder.UseSerilog((context, services, configuration) => configuration
                .ReadFrom.Configuration(context.Configuration)
            );
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        public static void AddAppConfigs(this IServiceCollection services, IConfiguration configuration)
        {
            
        }

        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
        }
    }
}