using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.src.Modules.Usuario.Domain.Entities;

namespace CampusLove_BraydenYJuan.src.Modules.usuarios.Application.Interfaces;

    public interface IUsuarioRepository
    {
        
        Task<Usuario?> GetByIdAsync(int id);
        Task<IEnumerable<Usuario>> GetAllAsync();
        void Add(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(Usuario usuario);
        Task SaveAsync();
    }