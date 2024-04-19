using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using Unicam.Paradigmi.Progetto.Application.Models.Request;
using Unicam.Paradigmi.Progetto.Application.Services;

namespace Unicam.Paradigmi.Progetto.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ListaUtenzeAssociateController : Controller
    {
       private readonly ListaUtenzeAssociateService listaUtenzeAssociateService;
        private readonly ListaDistribuzioneService listaDistribuzioneService;

        public ListaUtenzeAssociateController (ListaUtenzeAssociateService listaUtenzeAssociateService, ListaDistribuzioneService listaDistribuzioneService)
        {
            this.listaUtenzeAssociateService = listaUtenzeAssociateService;
            this.listaDistribuzioneService = listaDistribuzioneService;
        }

        [HttpPost]
        [Route("newDestinatario")]
        public  IActionResult AddDestinatario(AddDestinatarioRequest addDestinatariorequest)
        {
            int idUtente = 0; //da fare 
            var idProprietario = listaDistribuzioneService.GetidProprietario(addDestinatariorequest.IdLista);
            if (idProprietario.Equals(idUtente))
            {
                var aggiunto = listaUtenzeAssociateService.AddDestinatario(idUtente, addDestinatariorequest.Email);
                if(aggiunto == null)
                {
                    return NoContent();//badRequest
                }
            }
            else { return NoContent();} //badRequest
            return Ok();
        }

        [HttpDelete]
        [Route("deleteDestinatario")]
        public IActionResult DeleteDestinatario(DeleteDestinatarioRequest deleteDestinatarioRequest)
        {
            int idUtente = 0; //da fare
            var idProprietario = listaDistribuzioneService.GetidProprietario(deleteDestinatarioRequest.idLista);
            if (idProprietario.Equals(idUtente))
            {
                var rimosso = listaUtenzeAssociateService.DeleteDestinatario(deleteDestinatarioRequest.idLista, deleteDestinatarioRequest.email);
                if (rimosso == null)
                {
                    return NoContent(); //bad request
                }
            }
            else
            {
                return NoContent(); //bad Request
            }

            return Ok();
        }

    }
    }

