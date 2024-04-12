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
    public class ListaUtenzaConfiguration : IEntityTypeConfiguration<ListaUtenza>
    {
        public void Configure(EntityTypeBuilder<ListaUtenza> builder)
        {
            builder.ToTable("ListeUtenze");
            builder.HasKey(u => u.IdUtenza);
            builder.Property(u => u.IdUtenza).IsRequired();

            builder.HasOne(l => l.Proprietario)
                   .WithMany(u => u.ListeUtenze)
                   .HasForeignKey(l => l.EmailProprietario);

           

        }
    }
}
