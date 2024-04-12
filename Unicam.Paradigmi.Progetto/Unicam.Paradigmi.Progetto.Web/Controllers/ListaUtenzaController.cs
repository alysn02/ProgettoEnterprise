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
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ListaUtenzaController : ControllerBase
    {
        private readonly ListaUtenzaService _utenzaService;
        // List<Utente> utenti = new List<Utente>();

        public ListaUtenzaController(ListaUtenzaService utenzaService)
        {
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
    }
}
