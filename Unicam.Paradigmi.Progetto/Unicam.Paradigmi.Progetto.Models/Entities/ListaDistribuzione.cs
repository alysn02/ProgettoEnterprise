
namespace Unicam.Paradigmi.Progetto.Models.Entities
{
    public class ListaDistribuzione
    {
        public int IdLista { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int IdProprietario { get; set; }

        public virtual Utente Proprietario { get; set; } = null!;
        public virtual ICollection<ListaUtenzeAssociate> EmailDestinatarie { get; set; } = null!;
    }
}
