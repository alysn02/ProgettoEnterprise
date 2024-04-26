using FluentValidation;
using Unicam.Paradigmi.Progetto.Application.Abstractions.Services;
using Unicam.Paradigmi.Progetto.Application.Services;

namespace Unicam.Paradigmi.Progetto.Application.Extensions
{
    public static class ServiceExtension 
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration) {
            services.AddValidatorsFromAssembly(
            AppDomain.CurrentDomain.GetAssemblies().
           SingleOrDefault(assembly => assembly.GetName().Name == "Unicam.Paradigmi.Progetto.Application")
    );
            services.AddScoped<IUtenteService, UtenteService>();
            services.AddScoped<IListaDistribuzioneService, ListaDistribuzioneService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IDestinatarioService, DestinatarioService>();
            services.AddScoped<IListaUtenzeAssociateService, ListaUtenzeAssociateService>();
            services.AddScoped<IEmailService, EmailServices>();
            return services;
        }
    }
}
