using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Progetto.Models.Entities;

namespace Unicam.Paradigmi.Progetto.Models.Configurations
{
    public class DestinatariConfiguration
    {
        public void Configure(EntityTypeBuilder<Destinatari> builder)
        {
            builder.ToTable("Destinatari");
            builder.HasKey(u => u.Email);

            builder.HasOne(l => l.ListaUtenza)
                  .WithMany(u => u.EmailDestinatarie)
                  .HasForeignKey(l => l.IdUtenza);
        }
    }
}
