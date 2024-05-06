using Unicam.Paradigmi.Progetto.Models.Entities;

namespace Unicam.Paradigmi.Progetto.Application.Abstractions.Services
{
    public interface IDestinatarioService
    {
        public Task AddDestinatarioEmailAsync(string email);

        public Task<Destinatario> GetByEmailAsync(string email);

        public Task<List<Destinatario>> GetDestinatariAsync(int idListaDestinatari);
    }   

}
