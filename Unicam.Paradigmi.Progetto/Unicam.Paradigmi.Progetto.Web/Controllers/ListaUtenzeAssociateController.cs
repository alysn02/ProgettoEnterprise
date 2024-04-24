using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using Unicam.Paradigmi.Progetto.Application.Factories;
using Unicam.Paradigmi.Progetto.Application.Models.Dtos;
using Unicam.Paradigmi.Progetto.Application.Models.Request;
using Unicam.Paradigmi.Progetto.Application.Models.Responses;
using Unicam.Paradigmi.Progetto.Application.Services;
using Unicam.Paradigmi.Progetto.Models.Context;

namespace Unicam.Paradigmi.Progetto.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        public async Task<IActionResult> AddDestinatario(AddDestinatarioRequest addDestinatariorequest)
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
            var idUtente = Convert.ToInt32(jwtToken.Claims.First(claim => claim.Type == "IdUtente").Value);
            var idProprietario = await listaDistribuzioneService.GetidProprietarioAsync(addDestinatariorequest.IdLista);
            if (idProprietario.Equals(idUtente))
            {
                var aggiunto = await listaUtenzeAssociateService.AddDestinatarioAsync(addDestinatariorequest.IdLista, addDestinatariorequest.Email);
                if (aggiunto == null)
                {
                    return BadRequest(ResponseFactory.WithError("non esiste l'utente da aggiungere"));
                }
            

                var response = new AddDestinatarioResponse()
                {
                    Destinatario = new DestinatarioDto(aggiunto)
                   
                };
                return Ok(ResponseFactory.WithSuccess(response));
            }
          return BadRequest(ResponseFactory.WithError("non sei proprietario della lista")); 
                
        }


        [HttpDelete]
        [Route("deleteDestinatario")]
        public async Task<IActionResult> DeleteDestinatarioAsync(DeleteDestinatarioRequest deleteDestinatarioRequest)
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
            var idUtente = Convert.ToInt32(jwtToken.Claims.First(claim => claim.Type == "IdUtente").Value);
            var idProprietario = await listaDistribuzioneService.GetidProprietarioAsync(deleteDestinatarioRequest.idLista);
            if (idProprietario.Equals(idUtente))
            {
                var rimosso = await listaUtenzeAssociateService.DeleteDestinatarioAsync(deleteDestinatarioRequest.idLista, deleteDestinatarioRequest.email);
                if (rimosso == false)
                {
                    return BadRequest(ResponseFactory.WithError("il destinatario non esiste"));
                }
            }
            else
            {
                return BadRequest(ResponseFactory.WithError("non sei proprietario della lista"));
            }

            return Ok();
        }

    }
}

