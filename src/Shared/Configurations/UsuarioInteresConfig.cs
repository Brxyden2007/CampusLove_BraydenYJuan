// CampusLove_BraydenYJuan.src.Shared.Configurations/UsuarioInteresConfig.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UsuarioInteresConfig : IEntityTypeConfiguration<UsuarioInteres>
{
    public void Configure(EntityTypeBuilder<UsuarioInteres> builder)
    {
        builder.ToTable("interesusuario");
        
        // Define la clave primaria compuesta
        builder.HasKey(ui => new { ui.UsuarioId, ui.InteresId });

        // Configura la relación con Usuario
        builder.HasOne(ui => ui.Usuario)
            .WithMany(u => u.UsuarioIntereses)
            .HasForeignKey(ui => ui.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configura la relación con Interes
        builder.HasOne(ui => ui.Interes)
            .WithMany(i => i.UsuarioIntereses)
            .HasForeignKey(ui => ui.InteresId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}