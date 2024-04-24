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
            destinatarioRepository.Add(new Destinatario
            {
                Email = email
            });
            destinatarioRepository.Save();
        }
        public async Task<Destinatario> GetByEmailAsync(string email) 
        { 
            return destinatarioRepository.GetByEmail(email);
        }
         public async Task<List<Destinatario>> GetDestinatariAsync(int idListaDestinatari)
        {
            return destinatarioRepository.GetListaDestinatari(idListaDestinatari);
        }
    }
}
