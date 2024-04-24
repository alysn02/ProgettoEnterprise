﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Progetto.Models.Context;
using Unicam.Paradigmi.Progetto.Models.Entities;

namespace Unicam.Paradigmi.Progetto.Models.Repositories
{
    public class UtenteRepository
    {
        protected MydbContext _ctx;
        public UtenteRepository(MydbContext ctx)
        {
            _ctx = ctx;
        }
        public void Aggiungi(Utente utente)
        {
            _ctx.Set<Utente>().Add(utente);
           
        }

        public void Save()
        {
            _ctx.SaveChanges();
        }

        public Utente GetUtenteByEmail(string email)
        {
            return _ctx.Utenti.FirstOrDefault(x => x.Email == email);
        }

        public Utente GetUtenteById(int idUtente)
        {
            return _ctx.Utenti.FirstOrDefault(x => x.IdUtente == idUtente);
        }
    }
}
