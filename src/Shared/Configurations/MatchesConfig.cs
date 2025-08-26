using System;
using CampusLove_BraydenYJuan.src.Modules.matches.Domain.Entities;
using CampusLove.src.Modules.Usuario.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CampusLove_BraydenYJuan.src.Shared.Configurations
{
    public class MatchesConfig : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.ToTable("matches");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.FechaMatch)
                   .HasColumnName("FechaMatch")
                   .HasColumnType("timestamp")
                   .IsRequired();

            builder.Property(m => m.UsuarioId)
                    .HasColumnName("UsuarioId");

            // Relaciones
            builder.HasOne(m => m.Usuario1)
                   .WithMany(u => u.Matches1)
                   .HasForeignKey(m => m.Usuario1Id)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(m => m.Usuario2)
                   .WithMany(u => u.Matches2)
                   .HasForeignKey(m => m.Usuario2Id)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(m => m.UsuarioId).HasColumnName("UsuarioId");
            builder.Property(m => m.Usuario1Id).HasColumnName("Usuario1Id");
            builder.Property(m => m.Usuario2Id).HasColumnName("Usuario2Id");
            builder.Property(m => m.FechaMatch).HasColumnName("FechaMatch");
        }
    }
}
