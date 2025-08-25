using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusLove.src.Modules.Usuario.Domain.Entities;

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

        // Constructor
        public Usuario()
        {
        }
        public Usuario(int id, string? nombre, string? apellido, string? email, string? passwordUser, int edad, string? genero, string? carrera, string? intereses, string? frase)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            PasswordUser = passwordUser;
            Edad = edad;
            Genero = genero;
            Carrera = carrera;
            Intereses = intereses;
            Frase = frase;
        }
    }