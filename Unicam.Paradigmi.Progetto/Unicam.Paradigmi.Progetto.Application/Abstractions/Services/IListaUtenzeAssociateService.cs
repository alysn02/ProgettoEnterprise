using Unicam.Paradigmi.Progetto.Models.Entities;

namespace Unicam.Paradigmi.Progetto.Application.Abstractions.Services
{
    public interface IListaUtenzeAssociateService
    {
        public Task<Destinatario> AddDestinatarioAsync(int idLista, string email);
    
        public Task CreaAsync(int idLista, int idDestinatario);

        public Task<bool> DeleteDestinatarioAsync(string nomeLista, string email);
   } 
}
