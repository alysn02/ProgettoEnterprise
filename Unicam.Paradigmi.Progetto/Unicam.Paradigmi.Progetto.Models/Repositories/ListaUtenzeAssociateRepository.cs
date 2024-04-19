using Microsoft.EntityFrameworkCore;
using Unicam.Paradigmi.Progetto.Models.Context;
using Unicam.Paradigmi.Progetto.Models.Entities;

namespace Unicam.Paradigmi.Progetto.Models.Repositories
{
    public class ListaUtenzeAssociateRepository
    {
        protected MydbContext _ctx;
        public ListaUtenzeAssociateRepository(MydbContext ctx)
        {
            _ctx = ctx;
        }
        public  ListaUtenzeAssociate Get(int idLista,int idDestinatario)
        {

            return _ctx.ListaUtenzeAssociate.Where(x => x.IdListaDistribuzione == idLista && x.IdDestinatario == idDestinatario).FirstOrDefault();
        }
        public void Save()
        {
            _ctx.SaveChanges();
        }

        public void Add(ListaUtenzeAssociate item )
        {
            _ctx.Set<ListaUtenzeAssociate>().Add(item);
        }

        public Destinatario GetDestinatario( int idDestinatario)
        {
            return _ctx.Destinatari.Where(x => x.IdDestinatario == idDestinatario).FirstOrDefault();
        }
        public void DeleteDestinatario(int idLista, int idDestinatario)
        {
            var destinatario = GetDestinatario(idDestinatario);

            if (destinatario != null)
            {
                _ctx.ListaUtenzeAssociate.Remove(_ctx.ListaUtenzeAssociate.Where(a => a.IdDestinatario == destinatario.IdDestinatario).FirstOrDefault());
            }
            //return errore(?)
        }

    }
}
