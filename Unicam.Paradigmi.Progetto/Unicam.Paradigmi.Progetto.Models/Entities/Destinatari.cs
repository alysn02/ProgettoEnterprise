using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicam.Paradigmi.Progetto.Models.Entities
{
    public class Destinatari
    {
        public string Email { get; set; } = string.Empty;
        public int IdUtenza { get; set; }

        public virtual ListaUtenza ListaUtenza{get; set ;}
    }
}
