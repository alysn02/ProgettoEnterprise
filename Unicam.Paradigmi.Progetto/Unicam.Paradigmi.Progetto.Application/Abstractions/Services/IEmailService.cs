using Microsoft.Graph.Models;

namespace Unicam.Paradigmi.Progetto.Application.Abstractions.Services
{
    public interface IEmailService
    {
        public List<Recipient> SendEmail(string subject, string body, int idListaDestinatari);
    }
}
