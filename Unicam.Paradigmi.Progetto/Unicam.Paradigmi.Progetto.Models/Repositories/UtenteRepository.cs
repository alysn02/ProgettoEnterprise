using System;
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
            _ctx.Set<string>().Add(utente.Email);
            //non traccio i figli 
            //_ctx.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
        }

        public void Save()
        {
            _ctx.SaveChanges();
        }
    }
}
