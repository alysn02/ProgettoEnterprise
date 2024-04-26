using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Unicam.Paradigmi.Progetto.Models.Context;
using Unicam.Paradigmi.Progetto.Models.Repositories;

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
            services.AddScoped<UtenteRepository>();
            services.AddScoped<ListaDistribuzioneRepository>();
            services.AddScoped<DestinatarioRepository>();
            services.AddScoped<ListaUtenzeAssociateRepository>();
            return services;
        }
    }
}
