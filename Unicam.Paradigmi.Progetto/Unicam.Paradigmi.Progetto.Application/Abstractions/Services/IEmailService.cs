using Unicam.Paradigmi.Progetto.Models.Entities;

namespace Unicam.Paradigmi.Progetto.Application.Abstractions.Services
{
    public interface IEmailService
    {
        public Task<List<Destinatario>> SendEmailAsync(string subject, string body, int idListaDestinatari);
    }
}
