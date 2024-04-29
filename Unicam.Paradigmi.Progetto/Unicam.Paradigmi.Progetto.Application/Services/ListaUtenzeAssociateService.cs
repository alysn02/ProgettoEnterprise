using Unicam.Paradigmi.Progetto.Application.Abstractions.Services;
using Unicam.Paradigmi.Progetto.Models.Entities;
using Unicam.Paradigmi.Progetto.Models.Repositories;

namespace Unicam.Paradigmi.Progetto.Application.Services
{
    public class ListaUtenzeAssociateService : IListaUtenzeAssociateService
    {
        private readonly ListaUtenzeAssociateRepository listaUtenzeAssociateRepository;
        private readonly IDestinatarioService destinatarioService;

        public ListaUtenzeAssociateService(ListaUtenzeAssociateRepository listaUtenzeAssociateRepository, IDestinatarioService destinatarioService)
        {
            this.listaUtenzeAssociateRepository = listaUtenzeAssociateRepository;
            this.destinatarioService = destinatarioService;
        }
        

       public async Task<Destinatario> AddDestinatarioAsync(int idLista, string email)
        {
           Destinatario destinatario = await destinatarioService.GetByEmailAsync(email);
            if(destinatario == null){
                await destinatarioService.AddDestinatarioEmailAsync(email);
                var dest = await destinatarioService.GetByEmailAsync(email);
                 CreaAsync(idLista, dest.IdDestinatario);
                return dest;
            }
            if(await listaUtenzeAssociateRepository.GetAsync(idLista,destinatario.IdDestinatario) == null)
            {
                 CreaAsync(idLista, destinatario.IdDestinatario);
                return destinatario;
            }
            return destinatario;
        } 
        public async Task CreaAsync(int idLista, int idDestinatario)
        {
            var lista = new ListaUtenzeAssociate(idLista, idDestinatario);
            await listaUtenzeAssociateRepository.AggiungiAsync(lista);
            await listaUtenzeAssociateRepository.SaveAsync();
        }

        public async Task<bool> DeleteDestinatarioAsync(string nomeLista, string email)
        {
            Destinatario destinatario = await destinatarioService.GetByEmailAsync(email);
            if (destinatario != null)
            {
            await listaUtenzeAssociateRepository.DeleteDestinatarioAsync(nomeLista, destinatario);
                return true;
            }
            return false;

        }

    }
   
}
