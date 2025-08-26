// CampusLove_BraydenYJuan.src.Modules.usuarios_intereses.Domain.Entities/UsuarioInteres.cs
using System.ComponentModel.DataAnnotations.Schema;
using CampusLove.src.Modules.Usuario.Domain.Entities;
using CampusLove_BraydenYJuan.src.Modules.intereses.Domain.Entities;

public class UsuarioInteres
{
    // Claves primarias compuestas
    public int UsuarioId { get; set; }
    public int InteresId { get; set; }
    
    // Propiedades de navegación
    public Usuario? Usuario { get; set; }
    public Interes? Interes { get; set; }
}