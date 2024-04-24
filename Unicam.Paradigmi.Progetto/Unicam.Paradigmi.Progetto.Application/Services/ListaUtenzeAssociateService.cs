using Unicam.Paradigmi.Progetto.Application.Abstractions.Services;
using Unicam.Paradigmi.Progetto.Models.Entities;
using Unicam.Paradigmi.Progetto.Models.Repositories;

namespace Unicam.Paradigmi.Progetto.Application.Services
{
    public class ListaUtenzeAssociateService : IListaUtenzeAssociateService
    {
        ListaUtenzeAssociateRepository listaUtenzeAssociateRepository;
        DestinatarioService destinatarioService;

        public ListaUtenzeAssociateService(ListaUtenzeAssociateRepository listaUtenzeAssociateRepository, DestinatarioService destinatarioService)
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
            if(listaUtenzeAssociateRepository.Get(idLista,destinatario.IdDestinatario) == null)
            {
                 CreaAsync(idLista, destinatario.IdDestinatario);
                return destinatario;
            }
            return destinatario;
        } 
        public void CreaAsync(int idLista, int idDestinatario)
        {
            var lista = new ListaUtenzeAssociate(idLista, idDestinatario);
            listaUtenzeAssociateRepository.Add(lista);
            listaUtenzeAssociateRepository.Save();
        }

        public async Task<bool> DeleteDestinatarioAsync(int idLista, string email)
        {
            Destinatario destinatario = await destinatarioService.GetByEmailAsync(email);
            if (destinatario != null)
            {
            listaUtenzeAssociateRepository.DeleteDestinatario(idLista, destinatario.IdDestinatario);
                return true;
            }
            return false;

        }

    }
   
}
