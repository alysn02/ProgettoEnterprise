using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using System.IdentityModel.Tokens.Jwt;
using Unicam.Paradigmi.Progetto.Application.Abstractions.Services;
using Unicam.Paradigmi.Progetto.Application.Factories;
using Unicam.Paradigmi.Progetto.Application.Models.Dtos;
using Unicam.Paradigmi.Progetto.Application.Models.Request;
using Unicam.Paradigmi.Progetto.Application.Models.Responses;


namespace Unicam.Paradigmi.Progetto.Web.Controllers
{
    /*
     * This class is a controller that manages the requests related to the distribution list
     * 
     * @route: the route of the controller is api/v1/[controller] where [controller] is the name of the controller
     * @param _listaDistribuzioneService: service that manages the distribution list
     * return: the response to the request
     * **/
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ListaDistribuzioneController : ControllerBase
    {
        private readonly IListaDistribuzioneService _listaDistribuzioneService;
        private readonly IEmailService _emailServices;
        private readonly IUtenteService _utenteService;

        public ListaDistribuzioneController(IListaDistribuzioneService listaDistribuzioneService, IEmailService emailServices, IUtenteService utenteService)
        {
            _emailServices = emailServices;
            _listaDistribuzioneService = listaDistribuzioneService;
            _utenteService = utenteService;
        }

        /*
         * This method manages the request to create a new distribution list.
         * We check if the user exists, if it exists we create the list and return the response with the list created
         * We Use async to make the method asynchronous, so that it can be executed in parallel with other methods
         * 
         * @param request: request to create a new distribution list
         * @return the response to the request
         * **/

        [HttpPost]
        [Route("newLista")]
        public async Task<IActionResult> CreateListaAsync(CreateListaDistribuzioneRequest request)
        {

            if (await _utenteService.GetUtenteByIdAsync(request.IdProprietario) != null)
            {

                if (await _listaDistribuzioneService.GetListaByNomeAsync(request.Nome) == null)
                {
                    var lista = request.ToEntity();
                    await _listaDistribuzioneService.AddListaAsync(lista);

                    var response = new CreateListaDistribuzioneResponse();
                    response.ListaUtenza = new ListaUtenzaDto(lista);
                    return Ok(ResponseFactory.WithSuccess(response));
                }
            }
            return BadRequest(ResponseFactory.WithError("dati forniti non validi"));
        }

        /*
         * This method manages the request to Send Email.
         * We check if the user is Equals then owner of the list, if it is we send the email and return the response with the email sent
         * We Use async to make the method asynchronous, so that it can be executed in parallel with other methods
         * 
         * @param invioEmailRequest: request to send email
         * **/
        [HttpPost]
        [Route("messaggioLista")]
        public async Task<IActionResult> InvioEmailAsync(InvioEmailRequest invioEmailRequest)
        {
            var idUtente = (int)HttpContext.Items["IdUtente"];
            //var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            //var tokenHandler = new JwtSecurityTokenHandler();
            //var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
            //var idUtente = Convert.ToInt32(jwtToken.Claims.First(claim => claim.Type == "IdUtente").Value);
            var idProprietario = await _listaDistribuzioneService.GetidProprietarioAsync(invioEmailRequest.IdListaDestinatari);
            if (idProprietario.Equals(idUtente))
            {
                var destinatari = await _emailServices.SendEmailAsync(invioEmailRequest.Subject, invioEmailRequest.Body, invioEmailRequest.IdListaDestinatari);
                var response = new InvioEmailResponse
                {
                    Destinatari = destinatari.Select(d => new DestinatarioDto(d)).ToList()
                };
                return Ok(ResponseFactory.WithSuccess(response));
            }


            return BadRequest(ResponseFactory.WithError("qualcosa è andato storto"));
        }

        /*
         * This method manages the request to get the list of recipients.
         * We make the pagination of the list of recipients
         * We check totalNum if it is 0 we return an error message because there are no lists for that user
         * 
         * @param get: request to get the list of recipients
         * return the response to the request
         * **/
        [HttpPost]
        [Route("getListe")]
        public async Task<IActionResult> GetListeDestinatariAsync(GetListeDestinatariRequest get)
        {
            var idUtente = Convert.ToInt32(HttpContext.Items["IdUtente"]);
            
            var (liste, totalNum) = await _listaDistribuzioneService.GetListeAsync(idUtente, get.PageNumber * get.PageSize, get.PageSize, get.Email);

            if (totalNum == 0)
            {
                return BadRequest(ResponseFactory.WithError("non ci sono liste per quell'utente"));
            }
            var pageFounded = (totalNum / (decimal)get.PageSize);
            var response = new GetListeResponse
            {
                Liste = liste.Select(s =>
                new ListaUtenzaDto(s)).ToList(),
                NPagine = (int)Math.Ceiling(pageFounded)
            };

            return Ok(ResponseFactory.WithSuccess(response));
        }

    }
}
