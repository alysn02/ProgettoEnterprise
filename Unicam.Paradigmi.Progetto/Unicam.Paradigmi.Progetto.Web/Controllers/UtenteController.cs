
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Unicam.Paradigmi.Application.Models.Dtos;
using Unicam.Paradigmi.Application.Models.Request;
using Unicam.Paradigmi.Application.Models.Responses;
using Unicam.Paradigmi.Progetto.Application.Abstractions.Services;
using Unicam.Paradigmi.Progetto.Application.Factories;
using Unicam.Paradigmi.Progetto.Application.Validators;

namespace Unicam.Paradigmi.Progetto.Web.Controllers
{
    /*
     * this class is a controller that manages the requests related to the user
     * 
     * @param _utenteService: service that manages the user
     * return: the response to the request
     * 
     * **/

    [ApiController] //indicates that the class is a controller  
    [Route("api/v1/[controller]")] //indicates the route of the controller
    public class UtenteController : ControllerBase
    {
        private readonly IUtenteService _utenteService;

        public UtenteController(IUtenteService utenteService)
        {
            _utenteService = utenteService;
        }

        /*
         * this class manages the request to create a new user.       
         * We check if the user already exists, if it does not exist we create it and return the response with the user created
         * We Use async to make the method asynchronous, so that it can be executed in parallel with other methods
         * 
         * @param request: request to create a new user
         * return the response to the request
         * **/
        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> CreateUtenteAsync(CreateUtenteRequest request)
        {
            if (await _utenteService.GetUtenteByEmailAsync(request.Email) == null)
            {
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
