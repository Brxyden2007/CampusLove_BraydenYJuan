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
        public int UsuarioQueDaLikeId { get; set; }
        public int UsuarioQueRecibeLikeId { get; set; }
        public DateTime FechaLike { get; set; }
        public Usuario? UsuarioQueDaLike { get; set; }
        public Usuario? UsuarioQueRecibeLike { get; set; }
    }
}