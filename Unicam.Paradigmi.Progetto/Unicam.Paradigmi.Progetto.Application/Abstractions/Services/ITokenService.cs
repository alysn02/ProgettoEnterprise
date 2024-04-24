using Unicam.Paradigmi.Progetto.Application.Models.Request;

namespace Unicam.Paradigmi.Progetto.Application.Abstractions.Services
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(CreateTokenRequest request);
    }
}
