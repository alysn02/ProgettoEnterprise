using Unicam.Paradigmi.Progetto.Models.Entities;

namespace Unicam.Paradigmi.Progetto.Application.Abstractions.Services
{
    public interface IListaUtenzeAssociateService
    {
        public Task<Destinatario> AddDestinatarioAsync(int idLista, string email);
    }
}
