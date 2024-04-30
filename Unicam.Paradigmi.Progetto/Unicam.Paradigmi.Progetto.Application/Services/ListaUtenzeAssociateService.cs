using Unicam.Paradigmi.Progetto.Application.Abstractions.Services;
using Unicam.Paradigmi.Progetto.Models.Entities;
using Unicam.Paradigmi.Progetto.Models.Repositories;

namespace Unicam.Paradigmi.Progetto.Application.Services
{
    /*
     * This Class implements the IListaUtenzeAssociateService interface.
     * 
     * @param listaUtenzeAssociateRepository: The repository of the associated users list.
     * @param destinatarioService: The service of the recipient.
     * 
     * @return The service of the associated users list.
     * **/
    public class ListaUtenzeAssociateService : IListaUtenzeAssociateService
    {
        private readonly ListaUtenzeAssociateRepository listaUtenzeAssociateRepository;
        private readonly IDestinatarioService destinatarioService;

        public ListaUtenzeAssociateService(ListaUtenzeAssociateRepository listaUtenzeAssociateRepository, IDestinatarioService destinatarioService)
        {
            this.listaUtenzeAssociateRepository = listaUtenzeAssociateRepository;
            this.destinatarioService = destinatarioService;
        }
        
        /*
         * This Method adds a recipient to the associated users list.
         * 
         * @param idLista: The id of the list.
         * @param email: The email of the recipient.
         * @return the destinatario with the email.
         * **/
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

        /*
         * This Method creates a new associated users list.
         * @param idLista: The id of the list.
         * @param idDestinatario: The id of the recipient.
         * @return the list of associated users.
         * **/
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
