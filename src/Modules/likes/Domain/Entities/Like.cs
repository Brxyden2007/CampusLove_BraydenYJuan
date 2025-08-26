using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.src.Modules.Usuario.Domain.Entities;

namespace CampusLove_BraydenYJuan.src.Modules.likes.Domain.Entities
{
    public class Like
    {
         public int Id { get; set; }

    // Clave foránea para el usuario que da el like
        public int UsuarioDadorId { get; set; }
        public Usuario? UsuarioDador { get; set; }

        public int UsuarioId { get; set; }

        // Clave foránea para el usuario que recibe el like
        public int UsuarioReceptorId { get; set; }
        public Usuario? UsuarioReceptor { get; set; }

        // Otras propiedades
        public DateTime FechaLike { get; set; }
    }
}
