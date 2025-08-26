using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove_BraydenYJuan.src.Modules.intereses.Domain.Entities;
using CampusLove_BraydenYJuan.src.Modules.likes.Domain.Entities;
using CampusLove_BraydenYJuan.src.Modules.matches.Domain.Entities;
using CampusLove_BraydenYJuan.src.Modules.usuarios_intereses.Domain.Entities;

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
    public string? Frase { get; set; }

    // Relaciones
    public ICollection<Match>? Matches { get; set; }
    public ICollection<Like>? Likes { get; set; } 
    public ICollection<UsuarioInteres> UsuarioIntereses { get; set; } = new List<UsuarioInteres>();

    // Constructor
    public Usuario()
    {
    }
    public Usuario(int id, string? nombre, string? apellido, string? email, string? passwordUser, int edad, string? genero, string? carrera, string? frase)
    {
        Id = id;
        Nombre = nombre;
        Apellido = apellido;
        Email = email;
        PasswordUser = passwordUser;
        Edad = edad;
        Genero = genero;
        Carrera = carrera;
        Frase = frase;
    }
}