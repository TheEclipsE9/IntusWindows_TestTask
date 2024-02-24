using Microsoft.Extensions.DependencyInjection;
using MyApp.Domain.Contracts.Application;

namespace MyApp.Application.Services
{
    public static class DependencyInjectionConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IWindowService, WindowService>();
            services.AddScoped<ISubElementService, SubElementService>();
        }
    }
}
