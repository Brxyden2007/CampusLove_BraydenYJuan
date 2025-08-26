// CampusLove_BraydenYJuan.src.Modules.intereses.Domain.Entities/Interes.cs

namespace CampusLove_BraydenYJuan.src.Modules.intereses.Domain.Entities
{
    public class Interes
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        
        // Propiedad de navegación a la tabla de unión
        public ICollection<UsuarioInteres> UsuarioIntereses { get; set; } = new List<UsuarioInteres>();
    }
}