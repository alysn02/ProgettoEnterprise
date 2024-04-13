using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicam.Paradigmi.Progetto.Models.Entities
{
    public class ListaUtenzeAssociate
    {
        public int IdUtente { get; set; }
        public int IdListaDistribuzione { get; set; }
        public int IdListaAssociata { get; set; }
        public ListaDistribuzione Lista { get; set; } = null!;
        public Destinatario Destinatario { get; set; }
    }
}
