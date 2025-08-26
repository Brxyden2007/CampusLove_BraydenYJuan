using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove_BraydenYJuan.src.Modules.likes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CampusLove_BraydenYJuan.src.Shared.Configurations
{
    public class LikesConfig : IEntityTypeConfiguration<Like>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Like> builder)
        {
            builder.ToTable("likes");

            builder.HasKey(l => l.Id);

            // Ahora coincide con los nombres reales en la tabla
            builder.Property(l => l.UsuarioDadorId)
                .HasColumnName("UsuarioDadorId")
                .IsRequired();

            builder.Property(l => l.UsuarioId)
                    .HasColumnName("UsuarioId");

            builder.Property(l => l.UsuarioReceptorId)
                .HasColumnName("UsuarioReceptorId")
                .IsRequired();

            builder.Property(l => l.FechaLike)
                .HasColumnName("fecha")
                .IsRequired();

            // Relaciones con Usuario
            builder.HasOne(l => l.UsuarioDador)
                .WithMany(u => u.LikesDados)
                .HasForeignKey(l => l.UsuarioDadorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(l => l.UsuarioReceptor)
                .WithMany(u => u.LikesRecibidos)
                .HasForeignKey(l => l.UsuarioReceptorId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.Property(l => l.UsuarioDadorId).HasColumnName("UsuarioDadorId");
            builder.Property(l => l.UsuarioId).HasColumnName("UsuarioId");
            builder.Property(l => l.UsuarioReceptorId).HasColumnName("UsuarioReceptorId");
            builder.Property(l => l.FechaLike).HasColumnName("fecha");
        }
    }
}
