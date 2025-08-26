using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.src.Modules.Usuario.Domain.Entities;

namespace CampusLove_BraydenYJuan.src.Modules.intereses.Domain.Entities
{
    public class Interes
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public ICollection<Usuario?> Usuarios { get; set; } = new List<Usuario?>();   
    }
}