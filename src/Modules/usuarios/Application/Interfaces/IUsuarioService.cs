using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.src.Modules.Usuario.Domain.Entities;

namespace CampusLove_BraydenYJuan.src.Modules.usuarios.Application.Interfaces;

    public interface IUsuarioService
{
    Task RegistrarUsuarioAsync(Usuario usuario);
    Task ActualizarUsuarioAsync(Usuario usuario);
    Task EliminarUsuarioAsync(int id);
    Task<Usuario?> ObtenerUsuarioPorIdAsync(int id);
    Task<IEnumerable<Usuario>> ObtenerTodosLosUsuariosAsync();
    }