using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Progetto.Models.Context;
using Unicam.Paradigmi.Progetto.Models.Entities;

namespace Unicam.Paradigmi.Progetto.Models.Repositories
{
    public class DestinatarioRepository
    {
        public MydbContext _ctx;

        public DestinatarioRepository(MydbContext ctx)
        {
            _ctx = ctx;
        }
        public void Save()
        {
            _ctx.SaveChanges();
        }
        public void Add(Destinatario destinatario)
        {
            _ctx.Set<Destinatario>().Add(destinatario);
        }
        public Destinatario GetByEmail(string email)
        {
            return _ctx.Destinatari.Where(a => a.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }
        public List<Destinatario> GetListaDestinatari(int idLista)
        {
            var lista = _ctx.Destinatari.Where(a => a.ListaUtenzeAssociate.Any(i => i.IdListaDistribuzione == idLista)).ToList();
            return lista;
        }
    }
}
