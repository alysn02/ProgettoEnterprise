using Microsoft.AspNetCore.Mvc;
using Unicam.Paradigmi.Progetto.Application.Abstractions.Services;
using Unicam.Paradigmi.Progetto.Application.Factories;
using Unicam.Paradigmi.Progetto.Application.Models.Request;
using Unicam.Paradigmi.Progetto.Application.Services;

namespace Unicam.Paradigmi.Progetto.Web.Controllers
{
    /*
     * this class is a controller that manages the requests related to the token 
     * we use the token service to create a new token
     * 
     * @param _tokenService: service that manages the token
     * @param _utenteService: service that manages the user
     * 
     * return: the response to the request
     * **/
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUtenteService _utenteService;
        public TokenController(ITokenService tokenService, IUtenteService utenteService)
        {
            _utenteService = utenteService;
            _tokenService = tokenService;
        }

        /*
         * this class manages the request to create a new token.       
         * We check if the user exists, if it exists we create the token and return the response with the token created
         * We Use async to make the method asynchronous, so that it can be executed in parallel with other methods
         * @param request: request to create a new token
         * return the response to the request
         **/

        [HttpPost]
        [Route("newToken")]
        public async Task<IActionResult> CreateTokenAsync(CreateTokenRequest request)
        {
            if( await _utenteService.GetUtenteByEmailAsync(request.Email) == null) 
            {
                //return BadRequest(ResponseFactory.WithError("email o password non valide"));
                throw new InvalidOperationException("email o password non valide");
            }

            var token = await _tokenService.CreateTokenAsync(request);

            if(token == null)
            {
                //return BadRequest(ResponseFactory.WithError("email o password non valide"));
                throw new InvalidOperationException("token nullo");
            }

            return Ok(ResponseFactory.WithSuccess(token));
        }
    }
}
