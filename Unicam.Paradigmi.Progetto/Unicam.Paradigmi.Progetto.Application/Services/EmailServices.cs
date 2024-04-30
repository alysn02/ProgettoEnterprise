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
    /*
     * This Class is a Service that manages the sending of emails. It implements the IEmailService interface.
     * 
     * @param _emailOption: the options of the email service
     * @param destinatarioService: the service that manages the recipients
     * 
     * @return the service that manages the sending of emails
     * **/
    public class EmailServices : IEmailService
    {
        public readonly EmailOption _emailOption;
        public readonly IDestinatarioService destinatarioService;

        public EmailServices(IDestinatarioService destinatarioService, IOptions<EmailOption> emailOption)
        {
            this._emailOption = emailOption.Value;
            this.destinatarioService = destinatarioService;
        }

        /*
         * This Method sends an email to the recipients of a distribution list.
         * 
         * @param subject: the subject of the email
         * @param body: the body of the email
         * @param idListaDestinatari: the id of the distribution list
         * 
         * @return a list of recipients
         * **/
        public async Task<List<Destinatario>> SendEmailAsync(string subject, string body, int idListaDestinatari)
        {
            var destinatariEmail = await destinatarioService.GetDestinatariAsync(idListaDestinatari);

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
            return destinatariEmail;
        }
    }
}
