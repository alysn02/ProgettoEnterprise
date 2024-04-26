﻿using Unicam.Paradigmi.Progetto.Models.Entities;
using Unicam.Paradigmi.Progetto.Models.Repositories;

namespace Unicam.Paradigmi.Progetto.Application.Abstractions.Services
{
    public interface IUtenteService
    {
        public Task AddUtenteAsync(Utente utente);
        public Task<Utente> GetUtenteByEmailAsync(string email);
        public Task<Utente> GetUtenteByIdAsync(int idUtente);
        
    }
}
