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
    public class ListaDistribuzioneRepository : GenericRepository<ListaDistribuzione>
    {
        protected MydbContext _ctx;
        public ListaDistribuzioneRepository(MydbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
        public async Task<ListaDistribuzione> GetListaByNomeAsync(string nome)
        {
            return await _ctx.ListeDistribuzioni.FirstOrDefaultAsync(x => x.Nome == nome);
        }
        public async Task<int> GetIdFromListaAsync(int idListaDistribuzione)
        {
            var lista = await _ctx.ListeDistribuzioni.FirstAsync(x => x.IdLista == idListaDistribuzione);
            return  lista.IdProprietario;
        }
        public async Task<(List<ListaDistribuzione>, int)> GetListeAsync(int idUtente, int tpXps, int ps, string? email)
        {
            var liste = _ctx.ListeDistribuzioni.Where(a => a.IdProprietario == idUtente).AsQueryable();

            if (!string.IsNullOrEmpty(email))
            {
                liste = liste.Include(l => l.EmailDestinatarie).
                    Where(w => w.EmailDestinatarie.Any(d => d.Destinatario.Email.ToLower().Contains(email.ToLower())));
               
            }

            var totalNum = await liste.CountAsync(); // Count after applying all filters
            var filteredList = await liste
                             .OrderBy(o => o.IdLista)
                             .Skip(tpXps)
                             .Take(ps)
                             .ToListAsync();


            return (filteredList, totalNum);
        }
    }
}
