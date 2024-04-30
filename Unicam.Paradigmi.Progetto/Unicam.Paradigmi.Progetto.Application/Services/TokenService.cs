using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Unicam.Paradigmi.Progetto.Application.Abstractions.Services;
using Unicam.Paradigmi.Progetto.Application.Models.Request;
using Unicam.Paradigmi.Progetto.Application.Options;
using Unicam.Paradigmi.Progetto.Models.Entities;

namespace Unicam.Paradigmi.Progetto.Application.Services
{
    /*
     * This Class is used to create a JWT token for the user.
     * 
     * @param _jwtAuthOption: The JWTAuthOption object that contains the JWT key and issuer.
     * @param _utenteService: The UtenteService object that contains the methods to interact with the Utente entity.
     * 
     * @return The JWT token.
     * **/
    public class TokenService : ITokenService
    {
        private readonly JWTAuthOption _jwtAuthOption;
        private readonly IUtenteService _utenteService;

        public TokenService(IOptions<JWTAuthOption> jwtAuthOption, IUtenteService utenteService)
        {
            _jwtAuthOption = jwtAuthOption.Value;
            _utenteService = utenteService;
        }

        public async Task<string> CreateTokenAsync(CreateTokenRequest request)
        {
            var utente = await _utenteService.GetUtenteByEmailAsync(request.Email);
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(
                "Email",
                $"{utente.Email}"));
            claims.Add(new Claim(
     "IdUtente",
     $"{utente.IdUtente}"));

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtAuthOption.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var securityToken = new JwtSecurityToken(
                _jwtAuthOption.Issuer,
                null,
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
