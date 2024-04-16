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
        

       public bool AddDestinatario(int idLista, string email)
        {
           Destinatario destinatario = destinatarioService.GetByEmail(email);
            if(destinatario == null){
                destinatarioService.AddDestinatarioEmail(email);
                 Crea(idLista, destinatario.IdDestinatario);
                return true;
            }
            if(listaUtenzeAssociateRepository.Get(idLista,destinatario.IdDestinatario) == null)
            {
                 Crea(idLista, destinatario.IdDestinatario);
                return true;
            }
            return true;
        } 
        public void Crea(int idLista, int idDestinatario)
        {
            var lista = new ListaUtenzeAssociate(idLista, idDestinatario);
            listaUtenzeAssociateRepository.Add(lista);
            listaUtenzeAssociateRepository.Save();
        }

       /* public bool DeleteDestinatario(int idLista, string email)
        {
            Destinatario destinatario = destinatarioService.GetByEmail(email);
            listaUtenzeAssociateRepository.DeleteDestinatario(idLista, destinatario);
            return true;
        }*/

    }
   
}
