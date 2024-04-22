using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using Unicam.Paradigmi.Progetto.Application.Models.Request;
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
        public IActionResult AddDestinatario(AddDestinatarioRequest addDestinatariorequest)
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
            var idUtente = Convert.ToInt32(jwtToken.Claims.First(claim => claim.Type == "IdUtente").Value);
            var idProprietario = listaDistribuzioneService.GetidProprietario(addDestinatariorequest.IdLista);
            if (idProprietario.Equals(idUtente))
            {
                var aggiunto = listaUtenzeAssociateService.AddDestinatario(addDestinatariorequest.IdLista, addDestinatariorequest.Email);
                if (aggiunto == null)
                {
                    return NoContent();//badRequest
                }
            }
            else { return NoContent(); } //badRequest
            return Ok();
        }

        [HttpDelete]
        [Route("deleteDestinatario")]
        public IActionResult DeleteDestinatario(DeleteDestinatarioRequest deleteDestinatarioRequest)
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
            var idUtente = Convert.ToInt32(jwtToken.Claims.First(claim => claim.Type == "IdUtente").Value);
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

