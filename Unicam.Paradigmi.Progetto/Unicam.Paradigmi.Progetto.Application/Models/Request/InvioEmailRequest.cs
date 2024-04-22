namespace Unicam.Paradigmi.Progetto.Application.Models.Request
{
    public class InvioEmailRequest
    {
        public int IdListaDestinatari { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }
}
