using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.src.Modules.Usuario.Domain.Entities;
using CampusLove_BraydenYJuan.src.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace CampusLove_BraydenYJuan.src.Modules.usuarios.Infrastructure.Repositories
{
    public class UsuariosRepository
    {
    private readonly AppDbContext _context;
    public UsuariosRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Usuario?> GetByIdAsync(int id)
    {
        return await _context.Usuarios
        .FirstOrDefaultAsync(ui => ui.Id == id);
    }

    public async Task<IEnumerable<Usuario>> GetAllAsync()
    {
        return await _context.Usuarios.ToListAsync();
    }

    public void Add(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
    }
    public void Update(Usuario usuario)
    {
        _context.Usuarios.Update(usuario);
    }

    public void Delete(Usuario usuario)
    {
        _context.Usuarios.Remove(usuario);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
    }
}