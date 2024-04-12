using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Unicam.Paradigmi.Progetto.Models.Context;

namespace Unicam.Paradigmi.Progetto.Models.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddModelServices(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddDbContext<MydbContext>(conf =>
            {
                conf.UseSqlServer(configuration.GetConnectionString("MydbContext"));

            });
            return services;
        }
    }
}
