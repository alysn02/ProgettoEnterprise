using Unicam.Paradigmi.Progetto.Models.Entities;

namespace Unicam.Paradigmi.Progetto.Application.Abstractions.Services
{
    public interface IUtenteService
    {
        Task AddUtenteAsync(Utente utente);
    }
}
