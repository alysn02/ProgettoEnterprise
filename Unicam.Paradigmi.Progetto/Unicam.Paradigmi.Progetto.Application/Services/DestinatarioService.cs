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
        public void AddDestinatarioEmail(string email)
        {
            destinatarioRepository.Add(new Destinatario
            {
                Email = email
            });
            destinatarioRepository.Save();
        }
        public Destinatario GetByEmail(string email) 
        { 
            return destinatarioRepository.GetByEmail(email);
        }
         public List<Destinatario> GetDestinatari(int idListaDestinatari)
        {
            return destinatarioRepository.GetListaDestinatari(idListaDestinatari);
        }
    }
}
