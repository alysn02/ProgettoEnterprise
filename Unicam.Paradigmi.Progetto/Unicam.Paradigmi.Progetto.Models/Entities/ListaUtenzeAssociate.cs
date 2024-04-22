using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicam.Paradigmi.Progetto.Models.Entities
{
    public class ListaUtenzeAssociate
    {
        public int IdDestinatario { get; set; }
        public int IdListaDistribuzione { get; set; }
        public int IdListaAssociata { get; set; }
        public ListaDistribuzione Lista { get; set; } = null!;
        public Destinatario Destinatario { get; set; } = null!;

        public ListaUtenzeAssociate (int idLista, int idDestinatario)
        {
            this.IdListaDistribuzione = idLista;
            this.IdDestinatario = idDestinatario;
        }
        public ListaUtenzeAssociate()
        {
        }
    }
}
