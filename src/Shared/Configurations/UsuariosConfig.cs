using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.src.Modules.Usuario.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CampusLove.src.Shared.Configurations
{
    public class UsuariosConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuarios");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

            builder.Property(u => u.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(50);

            builder.Property(u => u.Apellido)
            .HasColumnName("apellido")
            .HasMaxLength(50);

            builder.Property(u => u.Email)
            .HasColumnName("email")
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(u => u.PasswordUser)
            .HasColumnName("passworduser")
            .HasMaxLength(255)
            .IsRequired();

            builder.Property(u => u.Edad)
            .HasColumnName("edad")
            .IsRequired();

            builder.Property(u => u.Genero)
            .HasColumnName("genero")
            .HasMaxLength(2);

            builder.Property(u => u.Carrera)
            .HasColumnName("carrera")
            .HasMaxLength(120);

            builder.Property(u => u.Intereses)
            .HasColumnName("intereses")
            .HasMaxLength(255);

            builder.Property(u => u.Frase)
            .HasColumnName("frase")
            .HasMaxLength(255);
        }
    }
}