using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicam.Paradigmi.Progetto.Models.Entities
{
    public class ListaUtenze
    {
        public string Nome { get; set; } = string.Empty;
        public string EmailProprietario { get; set; } = string.Empty;
        public List<Utente> Destinatari { get; set; } = new List<Utente>();

        public virtual Utente Proprietario { get; set; } = null!;
    }
}
