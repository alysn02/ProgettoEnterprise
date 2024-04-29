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
