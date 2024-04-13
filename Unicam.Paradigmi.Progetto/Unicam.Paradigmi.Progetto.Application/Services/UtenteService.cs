
using Unicam.Paradigmi.Progetto.Application.Abstractions.Services;
using Unicam.Paradigmi.Progetto.Models.Entities;
using Unicam.Paradigmi.Progetto.Models.Repositories;

namespace Unicam.Paradigmi.Progetto.Application.Services
{
    public class UtenteService : IUtenteService
    {
        private readonly UtenteRepository _utenteRepository;
        public UtenteService(UtenteRepository utenteRepository)
        {
            _utenteRepository = utenteRepository;
        }
        public void AddUtente(Utente utente)
        {
            _utenteRepository.Aggiungi(utente);
            _utenteRepository.Save();
        }

        public Utente GetUtenteByEmail(string email)
        {
            return _utenteRepository.GetUtenteByEmail(email);
        }

    }
}
