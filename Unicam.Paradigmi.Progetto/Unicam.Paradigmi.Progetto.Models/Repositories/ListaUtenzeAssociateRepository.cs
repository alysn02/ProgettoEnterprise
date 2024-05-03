using Microsoft.EntityFrameworkCore;
using Unicam.Paradigmi.Models.Repositories;
using Unicam.Paradigmi.Progetto.Models.Context;
using Unicam.Paradigmi.Progetto.Models.Entities;

namespace Unicam.Paradigmi.Progetto.Models.Repositories
{
    public class ListaUtenzeAssociateRepository : GenericRepository<ListaUtenzeAssociate>
    {
        protected MydbContext _ctx;
        private readonly ListaDistribuzioneRepository _listaDistribuzioneRepository;
        public ListaUtenzeAssociateRepository(MydbContext ctx, ListaDistribuzioneRepository listaDistribuzioneRepository) : base(ctx)
        {
            _ctx = ctx;
            _listaDistribuzioneRepository = listaDistribuzioneRepository;
        }
        public  async Task<ListaUtenzeAssociate> GetAsync(int idLista,int idDestinatario)
        {

            return await _ctx.ListaUtenzeAssociate.Where(x => x.IdListaDistribuzione == idLista && x.IdDestinatario == idDestinatario).FirstOrDefaultAsync();
        }
        public async Task<Destinatario> GetDestinatarioAsync( int idDestinatario)
        {
            return await _ctx.Destinatari.Where(x => x.IdDestinatario == idDestinatario).FirstOrDefaultAsync();
        }

        public async Task DeleteDestinatarioAsync(string nomeLista, Destinatario destinatario)
        {
            var lista = await _listaDistribuzioneRepository.GetListaByNomeAsync(nomeLista);
            if (lista != null) 
            {
                var id = lista.IdLista;
            _ctx.ListaUtenzeAssociate.Remove(_ctx.ListaUtenzeAssociate.Where(a => a.IdDestinatario == destinatario.IdDestinatario && a.IdListaDistribuzione == id).FirstOrDefault());
            await SaveAsync();
            }
        }
    }

}
