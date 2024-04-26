using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Repositories;
using Unicam.Paradigmi.Progetto.Models.Context;
using Unicam.Paradigmi.Progetto.Models.Entities;

namespace Unicam.Paradigmi.Progetto.Models.Repositories
{
    public class UtenteRepository : GenericRepository <Utente>
    {
        protected MydbContext _ctx;
        public UtenteRepository(MydbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
        public async Task<Utente> GetUtenteByEmailAsync(string email)
        {
            return await _ctx.Utenti.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<Utente> GetUtenteByIdAsync(int idUtente)
        {
            return await _ctx.Utenti.FirstOrDefaultAsync(x => x.IdUtente == idUtente);
        }
    }
}
