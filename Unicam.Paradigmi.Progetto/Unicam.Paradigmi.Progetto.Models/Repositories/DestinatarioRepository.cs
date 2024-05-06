using Microsoft.EntityFrameworkCore;
using Unicam.Paradigmi.Models.Repositories;
using Unicam.Paradigmi.Progetto.Models.Context;
using Unicam.Paradigmi.Progetto.Models.Entities;

namespace Unicam.Paradigmi.Progetto.Models.Repositories
{
    public class DestinatarioRepository : GenericRepository<Destinatario>
    {
        public MydbContext _ctx;

        public DestinatarioRepository(MydbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
        public async Task<Destinatario> GetByEmailAsync(string email)
        {
            return await _ctx.Destinatari.Where(a => a.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
        }
        public async Task<List<Destinatario>> GetListaDestinatariAsync(int idLista)
        {
            var lista = await _ctx.Destinatari.Where(a => a.ListaUtenzeAssociate.Any(i => i.IdListaDistribuzione == idLista)).ToListAsync();
            return lista;
        }
    }
}
