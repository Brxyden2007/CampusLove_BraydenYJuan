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

            builder.Property(l => l.UsuarioQueDaLikeId)
                .HasColumnName("usuario_id")
                .IsRequired();

            builder.Property(l => l.UsuarioQueRecibeLikeId)
                .HasColumnName("usuario_liked_id")
                .IsRequired();

            builder.Property(l => l.FechaLike)
                .HasColumnName("fecha")
                .IsRequired();

            // Relaciones
            builder.HasOne(l => l.UsuarioQueDaLike)
                .WithMany()
                .HasForeignKey(l => l.UsuarioQueDaLikeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(l => l.UsuarioQueRecibeLike)
                .WithMany()
                .HasForeignKey(l => l.UsuarioQueRecibeLikeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}