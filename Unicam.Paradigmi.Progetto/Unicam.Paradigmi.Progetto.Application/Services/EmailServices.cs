using Azure.Identity;
using Microsoft.Extensions.Options;
using Microsoft.Graph.Models;
using Microsoft.Graph;
using Unicam.Paradigmi.Progetto.Application.Abstractions.Services;
using Unicam.Paradigmi.Progetto.Application.Options;
using Microsoft.Graph.Users.Item.SendMail;
using Unicam.Paradigmi.Progetto.Models.Entities;

namespace Unicam.Paradigmi.Progetto.Application.Services
{
    public class EmailServices : IEmailService
    {
        public readonly EmailOption _emailOption;
        public readonly DestinatarioService destinatarioService;

        public EmailServices(DestinatarioService destinatarioService, IOptions<EmailOption> emailOption)
        {
            this._emailOption = emailOption.Value;
            this.destinatarioService = destinatarioService;
        }

        public List<Recipient> SendEmail(string subject, string body, int idListaDestinatari)
        {
            var destinatariEmail = destinatarioService.GetDestinatari(idListaDestinatari);

            List<Recipient> destinatari = new List<Recipient>();

            var clientCredential = new ClientSecretCredential(_emailOption.TenantId
                , _emailOption.ClientId
                , _emailOption.ClientSecret
                );

            var client = new GraphServiceClient(clientCredential);

            foreach ( var destinatario in destinatariEmail ) 
            {
                destinatari.Add(new Recipient()
                {
                    EmailAddress = new EmailAddress()
                    {
                        Address = destinatario.Email
                    }
                });
            }

            Message message = new()
            {
                Subject = subject,
                Body = new ItemBody
                {
                    ContentType = Microsoft.Graph.Models.BodyType.Text,
                    Content = body
                },
                ToRecipients = destinatari
            };

            var postRequestBody = new SendMailPostRequestBody();

            postRequestBody.Message = message;

            postRequestBody.SaveToSentItems = true;

             client.Users[_emailOption.From]
                .SendMail.PostAsync(postRequestBody);
            return destinatari;
        }
    }
}
