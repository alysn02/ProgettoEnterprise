using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Progetto.Models.Context;

namespace Unicam.Paradigmi.Progetto.Models.Entities
{
    public class Utente
    {
        public string Email  { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Cognome { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

       public virtual ICollection<ListaUtenza> ListeUtenze { get; set; }
    }
}
    

