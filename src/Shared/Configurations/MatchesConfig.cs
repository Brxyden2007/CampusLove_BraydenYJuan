using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove_BraydenYJuan.src.Modules.matches.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CampusLove_BraydenYJuan.src.Shared.Configurations
{
    public class MatchesConfig : IEntityTypeConfiguration<Match>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Match> builder)
        {
            builder.ToTable("matches");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.FechaMatch)
                   .IsRequired();

            // Configuración de relaciones
            builder.HasOne(m => m.Usuario1)
                   .WithMany() // Asumiendo que no hay una colección de Matches en Usuario
                   .HasForeignKey(m => m.Usuario1Id)
                   .OnDelete(DeleteBehavior.Restrict); // Evitar eliminación en cascada

            builder.HasOne(m => m.Usuario2)
                   .WithMany() // Asumiendo que no hay una colección de Matches en Usuario
                   .HasForeignKey(m => m.Usuario2Id)
                   .OnDelete(DeleteBehavior.Restrict); // Evitar eliminación en cascada
        }
    }
}