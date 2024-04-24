
using Microsoft.AspNetCore.Mvc;
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
        public  async Task AddUtenteAsync(Utente utente)
        {
            _utenteRepository.Aggiungi(utente);
            _utenteRepository.Save();
        }

        public async Task<Utente> GetUtenteByEmailAsync(string email)
        {
            return _utenteRepository.GetUtenteByEmail(email);
        }

        public async Task<Utente> GetUtenteByIdAsync(int idUtente)
        {
            return _utenteRepository.GetUtenteById(idUtente);
        }

    }
}
