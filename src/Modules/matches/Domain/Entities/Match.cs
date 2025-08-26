using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.src.Modules.Usuario.Domain.Entities;

namespace CampusLove_BraydenYJuan.src.Modules.matches.Domain.Entities
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime FechaMatch { get; set; }

        // Foreign key and navigation property for the first user in the match.
        public int? UsuarioId { get; set; }
        public int Usuario1Id { get; set; }
        public Usuario? Usuario1 { get; set; }

        // Foreign key and navigation property for the second user in the match.
        public int Usuario2Id { get; set; }
        public Usuario? Usuario2 { get; set; }
    }
}
