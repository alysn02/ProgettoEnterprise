using Microsoft.AspNetCore.Mvc;
using Unicam.Paradigmi.Progetto.Application.Abstractions.Services;
using Unicam.Paradigmi.Progetto.Application.Models.Request;

namespace Unicam.Paradigmi.Progetto.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenConotroller : Controller
    {
        private readonly ITokenService _tokenService;
        public TokenConotroller(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("newToken")]
        public IActionResult CreateToken(CreateTokenRequest request)
        {
            var token = _tokenService.CreateToken(request);
            return Ok(token);
        }
    }
}
