
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
            await _utenteRepository.AggiungiAsync(utente);
            await _utenteRepository.SaveAsync();
        }

        public async Task<Utente> GetUtenteByEmailAsync(string email)
        {
            return await _utenteRepository.GetUtenteByEmailAsync(email);
        }

        public async Task<Utente> GetUtenteByIdAsync(int idUtente)
        {
            return await _utenteRepository.GetUtenteByIdAsync(idUtente);
        }

    }
}
