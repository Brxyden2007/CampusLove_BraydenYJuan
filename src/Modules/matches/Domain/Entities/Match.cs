using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.src.Modules.Usuario.Domain.Entities;

namespace CampusLove_BraydenYJuan.src.Modules.matches.Domain.Entities
{
    public class Match
    {
        public int Id { get; set; }
        public int Usuario1Id { get; set; }
        public int Usuario2Id { get; set; }
        public Usuario? Usuario1 { get; set; }
        public Usuario? Usuario2 { get; set; }
        public DateTime FechaMatch { get; set; }
    }
}