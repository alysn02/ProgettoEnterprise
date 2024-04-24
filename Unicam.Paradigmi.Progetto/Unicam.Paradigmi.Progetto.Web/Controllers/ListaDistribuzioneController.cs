using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Unicam.Paradigmi.Progetto.Application.Factories;
using Unicam.Paradigmi.Progetto.Application.Models.Dtos;
using Unicam.Paradigmi.Progetto.Application.Models.Request;
using Unicam.Paradigmi.Progetto.Application.Models.Responses;
using Unicam.Paradigmi.Progetto.Application.Services;
using Unicam.Paradigmi.Progetto.Models.Repositories;

namespace Unicam.Paradigmi.Progetto.Web.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ListaDistribuzioneController : ControllerBase
    {
        private readonly ListaDistribuzioneService _listaDistribuzioneService;
        private readonly EmailServices _emailServices;
        private readonly UtenteService _utenteService;

        public ListaDistribuzioneController(ListaDistribuzioneService listaDistribuzioneService, EmailServices emailServices, UtenteService utenteService)
        {
            _emailServices = emailServices;
            _listaDistribuzioneService = listaDistribuzioneService;
            _utenteService = utenteService;
        }


        [HttpPost]
        [Route("newLista")]
        public async Task<IActionResult> CreateListaAsync(CreateListaDistribuzioneRequest request)
        {
            if(await _utenteService.GetUtenteByIdAsync(request.IdProprietario) != null)
            {
                if(await _listaDistribuzioneService.GetListaByNomeAsync(request.Nome) != null)
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

        [HttpPost]
        [Route("messaggioLista")]
        public async Task<IActionResult> InvioEmailAsync(InvioEmailRequest invioEmailRequest)
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
            var idUtente = Convert.ToInt32(jwtToken.Claims.First(claim => claim.Type == "IdUtente").Value);
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

        [HttpPost]
        [Route("getListe")]
        public async Task<IActionResult> GetListeDestinatariAsync(GetListeDestinatariRequest get)
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
            var idUtente = Convert.ToInt32(jwtToken.Claims.First(claim => claim.Type == "IdUtente").Value);

            int totalNum = 0;
            var liste = await _listaDistribuzioneService.GetListeAsync(idUtente, get.PageNumber * get.PageSize, get.PageSize, get.Email, out totalNum);

            if (totalNum == 0)
            {
                return BadRequest(ResponseFactory.WithError("non ci sono liste per quell'utente"));
            }
            var response = new GetListeResponse();
            var pageFounded = (totalNum / (decimal)get.PageSize);
            response.NPagine = (int)Math.Ceiling(pageFounded);
            response.Liste = liste.Select(s =>
            new Application.Models.Dtos.ListaUtenzaDto(s)).ToList();


            return Ok(ResponseFactory.WithSuccess(response));
        }

    }
}
