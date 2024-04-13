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
    public class ListaDistribuzioneConfiguration : IEntityTypeConfiguration<ListaDistribuzione>
    {
        public void Configure(EntityTypeBuilder<ListaDistribuzione> builder)
        {
            builder.ToTable("ListeDistribuzioni");
            builder.HasKey(u => u.IdLista);
            builder.Property(u => u.IdLista).IsRequired();

            builder.HasOne(l => l.Proprietario)
                   .WithMany(u => u.ListeUtenze)
                   .HasForeignKey(l => l.IdProprietario);
        }
    }
}
