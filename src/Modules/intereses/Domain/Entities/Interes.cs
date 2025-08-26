using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.src.Modules.Usuario.Domain.Entities;
using CampusLove_BraydenYJuan.src.Modules.usuarios_intereses.Domain.Entities;

namespace CampusLove_BraydenYJuan.src.Modules.intereses.Domain.Entities
{
    public class Interes
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public ICollection<Usuario>? Usuarios { get; set; } = new List<Usuario>();
        public ICollection<UsuarioInteres> UsuarioIntereses { get; set; } = new List<UsuarioInteres>();
    }
}