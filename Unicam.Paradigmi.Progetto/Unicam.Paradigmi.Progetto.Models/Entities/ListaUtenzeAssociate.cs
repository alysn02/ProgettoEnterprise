
namespace Unicam.Paradigmi.Progetto.Models.Entities
{
    public class ListaUtenzeAssociate
    {
        public int IdDestinatario { get; set; }
        public int IdListaDistribuzione { get; set; }
        public int IdListaAssociata { get; set; }
        public ListaDistribuzione Lista { get; set; } = null!;
        public Destinatario Destinatario { get; set; } = null!;

      
    }
}
