namespace Unicam.Paradigmi.Progetto.Application.Models.Request
{
    public class AddDestinatarioRequest
    {
        public int IdLista { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
