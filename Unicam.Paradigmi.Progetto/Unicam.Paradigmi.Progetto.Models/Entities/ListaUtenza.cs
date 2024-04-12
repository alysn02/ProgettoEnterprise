using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicam.Paradigmi.Progetto.Models.Entities
{
    public class ListaUtenza
    {
        public int IdUtenza { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string EmailProprietario { get; set; } = string.Empty;
        public virtual Utente Proprietario { get; set; }

        public virtual ICollection<Destinatari> EmailDestinatarie { get; set; }
    }
}
