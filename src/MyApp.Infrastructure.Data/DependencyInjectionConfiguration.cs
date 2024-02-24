using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Domain.Contracts.Infrastructure;

namespace MyApp.Infrastructure.Data
{
    public static class DependencyInjectionConfiguration
    {
        public static void ConfigureData(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => 
            {
                var connectionString = configuration.GetConnectionString("DataBase");
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            services.AddScoped<IAppDbContext, AppDbContext>();
        }
    }
}
