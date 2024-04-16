namespace Unicam.Paradigmi.Progetto.Application.Models.Request
{
    public class DeleteDestinatarioRequest
    {
        public int idLista { get; set; }
        public string email { get; set; } = string.Empty;
    }
}
