using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove_BraydenYJuan.src.Modules.usuarios_intereses.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CampusLove_BraydenYJuan.src.Shared.Configurations
{
    public class UsuarioInteresConfig : IEntityTypeConfiguration<UsuarioInteres>
    {
        public void Configure(EntityTypeBuilder<UsuarioInteres> builder)
        {
            builder.ToTable("interesusuario");

            // ¡ACTUALIZADO! Las claves primarias usan los nuevos nombres de propiedades en snake_case
            builder.HasKey(ui => new { ui.usuario_id, ui.interes_id });

            // Ya no necesitamos HasColumnName aquí si la propiedad C# ya coincide
            // builder.Property(ui => ui.usuario_id).HasColumnName("usuario_id");
            // builder.Property(ui => ui.interes_id).HasColumnName("interes_id");

            builder.HasOne(ui => ui.Usuario)
               .WithMany(u => u.UsuarioIntereses)
               .HasForeignKey(ui => ui.usuario_id); // ¡ACTUALIZADO!

            builder.HasOne(ui => ui.Interes)
               .WithMany(i => i.UsuarioIntereses)
               .HasForeignKey(ui => ui.interes_id); // ¡ACTUALIZADO!
        }
    }
}
