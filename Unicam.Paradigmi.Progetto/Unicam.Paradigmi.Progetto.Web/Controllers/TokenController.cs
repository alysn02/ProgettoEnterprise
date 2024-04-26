using Microsoft.AspNetCore.Mvc;
using Unicam.Paradigmi.Progetto.Application.Abstractions.Services;
using Unicam.Paradigmi.Progetto.Application.Factories;
using Unicam.Paradigmi.Progetto.Application.Models.Request;
using Unicam.Paradigmi.Progetto.Application.Services;

namespace Unicam.Paradigmi.Progetto.Web.Controllers
{
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

        [HttpPost]
        [Route("newToken")]
        public async Task<IActionResult> CreateTokenAsync(CreateTokenRequest request)
        {
            if( await _utenteService.GetUtenteByEmailAsync(request.Email) == null) 
            {
                return BadRequest(ResponseFactory.WithError("email o password non valide"));
            }

            var token = await _tokenService.CreateTokenAsync(request);

            if(token == null)
            {
                return BadRequest(ResponseFactory.WithError("email o password non valide"));
            }

            return Ok(ResponseFactory.WithSuccess(token));
        }
    }
}
