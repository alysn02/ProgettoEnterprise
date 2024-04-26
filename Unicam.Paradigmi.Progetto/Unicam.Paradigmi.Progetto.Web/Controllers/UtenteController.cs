
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unicam.Paradigmi.Application.Models.Dtos;
using Unicam.Paradigmi.Application.Models.Request;
using Unicam.Paradigmi.Application.Models.Responses;
using Unicam.Paradigmi.Progetto.Application.Abstractions.Services;
using Unicam.Paradigmi.Progetto.Application.Factories;
namespace Unicam.Paradigmi.Progetto.Web.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class UtenteController : ControllerBase
    {
        private readonly IUtenteService _utenteService;

        public UtenteController(IUtenteService utenteService)
        {
            _utenteService = utenteService;
        }


        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> CreateUtenteAsync(CreateUtenteRequest request)
        {
            if(await _utenteService.GetUtenteByEmailAsync(request.Email) == null) { 
                var utente = request.ToEntity();
                await _utenteService.AddUtenteAsync(utente);
    
                var response = new CreateUtenteResponse();
                response.Utente = new UtenteDto(utente);
                return Ok(ResponseFactory.WithSuccess(response));
            }
            return BadRequest(ResponseFactory.WithError("utente già esistente"));    
        }
    }
}
