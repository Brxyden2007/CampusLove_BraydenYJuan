using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusLove.src.Modules.Usuario.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        public string? PasswordUser { get; set; }
        public int Edad { get; set; }
        public string? Genero { get; set; }
        public string? Carrera { get; set; }
        public string? Intereses { get; set; }
        public string? Frase { get; set; }
    }
}