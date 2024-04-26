using Unicam.Paradigmi.Progetto.Application.Abstractions.Services;
using Unicam.Paradigmi.Progetto.Models.Entities;
using Unicam.Paradigmi.Progetto.Models.Repositories;

namespace Unicam.Paradigmi.Progetto.Application.Services
{
    public class DestinatarioService : IDestinatarioService
    {
        private readonly DestinatarioRepository destinatarioRepository;
           public DestinatarioService(DestinatarioRepository destinatarioRepository)
        {
            this.destinatarioRepository = destinatarioRepository;
        }
        public async Task AddDestinatarioEmailAsync(string email)
        {
            await destinatarioRepository.AggiungiAsync(new Destinatario
            {
                Email = email
            });
            await destinatarioRepository.SaveAsync();
        }
        public async Task<Destinatario> GetByEmailAsync(string email) 
        { 
            return await destinatarioRepository.GetByEmailAsync(email);
        }
         public async Task<List<Destinatario>> GetDestinatariAsync(int idListaDestinatari)
        {
            return await destinatarioRepository.GetListaDestinatariAsync(idListaDestinatari);
        }
    }
}
