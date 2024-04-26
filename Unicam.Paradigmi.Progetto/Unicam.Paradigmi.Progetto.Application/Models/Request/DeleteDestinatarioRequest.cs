namespace Unicam.Paradigmi.Progetto.Application.Models.Request
{
    public class DeleteDestinatarioRequest
    {
        public int IdLista { get; set; }
        public string Email { get; set; } = string.Empty;
        public string NomeLista { get; set; } = string.Empty;
    }
}
