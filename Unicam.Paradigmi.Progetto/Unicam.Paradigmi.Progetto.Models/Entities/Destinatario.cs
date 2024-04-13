using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicam.Paradigmi.Progetto.Models.Entities
{
    public class Destinatario
    {
        public string Email { get; set; } = string.Empty;
        public int IdDestinatario { get; set; }

        public virtual ICollection<ListaUtenzeAssociate> ListaUtenzeAssociate { get; set; } = null!;

    }
}
