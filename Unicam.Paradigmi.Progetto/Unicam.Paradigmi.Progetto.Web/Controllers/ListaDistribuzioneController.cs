using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unicam.Paradigmi.Application.Models.Dtos;
using Unicam.Paradigmi.Application.Models.Request;
using Unicam.Paradigmi.Application.Models.Responses;
using Unicam.Paradigmi.Progetto.Application.Abstractions.Services;
using Unicam.Paradigmi.Progetto.Application.Models.Dtos;
using Unicam.Paradigmi.Progetto.Application.Models.Request;
using Unicam.Paradigmi.Progetto.Application.Models.Responses;
using Unicam.Paradigmi.Progetto.Application.Services;

namespace Unicam.Paradigmi.Progetto.Web.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ListaDistribuzioneController : ControllerBase
    {
        private readonly ListaDistribuzioneService _utenzaService;
        private readonly EmailServices _emailServices;

        public ListaDistribuzioneController(ListaDistribuzioneService utenzaService, EmailServices emailServices)
        {
            _emailServices = emailServices;
            _utenzaService = utenzaService;
        }


        [HttpPost]
        [Route("newLista")]
        public IActionResult CreateLista(CreateListaUtenzaRequest request)
        {
            var lista = request.ToEntity();
            _utenzaService.AddLista(lista);

            var response = new CreateListaUtenzaResponse();
            response.ListaUtenza = new ListaUtenzaDto(lista);
            return Ok();
        }
        [HttpPost]
        [Route("messaggioLista")]
        public IActionResult InvioEmail(InvioEmailRequest invioEmailRequest)
        {
            int idUtente = 0; //da fare
            var idProprietario = _utenzaService.GetidProprietario(invioEmailRequest.IdListaDestinatari);
            if (idProprietario.Equals(idUtente))
            {
                _emailServices.SendEmail(invioEmailRequest.Subject, invioEmailRequest.Body, invioEmailRequest.IdListaDestinatari);
                /*var rispostona = new RispostonaEmail {
                 destinatari = emailservice.destinatari(?)
                 }*/
                return Ok();
            }

            return BadRequest();
        }

    }
}
