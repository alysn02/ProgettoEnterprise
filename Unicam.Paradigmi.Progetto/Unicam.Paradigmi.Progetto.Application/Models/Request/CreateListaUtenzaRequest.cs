using Unicam.Paradigmi.Progetto.Models.Entities;

namespace Unicam.Paradigmi.Progetto.Application.Models.Request
{
    public class CreateListaUtenzaRequest
    {
        public string Nome { get; set; } = string.Empty;

        public string EmailProprietario { get; set; } = string.Empty;
        public ListaUtenza ToEntity()
        {
            var lista = new ListaUtenza();
            lista.Nome = Nome;
            lista.EmailProprietario = EmailProprietario;
            return lista;
        }
    }
}
