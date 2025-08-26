using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.src.Modules.Usuario.Domain.Entities;
using CampusLove_BraydenYJuan.src.Shared.Context;
using CampusLove_BraydenYJuan.src.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using CampusLove_BraydenYJuan.src.Modules.usuarios_intereses.Domain.Entities; // Necesario para UsuarioInteres

namespace CampusLove_BraydenYJuan.src.Modules.usuarios.Application.Services;

public class UsuarioService
{
    private readonly AppDbContext _context;

    public UsuarioService(AppDbContext context)
    {
        _context = context;
    }

    public async Task RegistrarUsuarioAsync(Usuario usuario)
    {
        // Validar email único
        if (await _context.Usuarios.AnyAsync(u => u.Email == usuario.Email))
        {
            throw new Exception("El email ya está registrado.");
        }
        // Hash the password
        usuario.PasswordUser = PasswordHasher.HashPassword(usuario.PasswordUser ?? string.Empty);

        // Validar edad mínima
        if (usuario.Edad < 18)
        {
            throw new Exception("El usuario debe ser mayor de 18 años.");
        }
        // Validar longitud mínima de la contraseña
        if (string.IsNullOrEmpty(usuario.PasswordUser) || usuario.PasswordUser.Length < 6)
        {
            throw new Exception("La contraseña debe tener al menos 6 caracteres.");
        }
        
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> LoginUsuarioAsync(string email, string password)
    {
        var usuario = await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Email == email);
        if (usuario == null)
            return false;

        return usuario.PasswordUser != null &&
            PasswordHasher.VerifyPassword(usuario.PasswordUser, password);
    }

    public async Task AsignarInteresesAsync(int usuarioId, List<int> interesesIds)
    {
        var usuario = await _context.Usuarios
            .Include(u => u.UsuarioIntereses) // Incluir la entidad de unión
            .FirstOrDefaultAsync(u => u.Id == usuarioId);

        if (usuario == null)
            throw new Exception("Usuario no encontrado.");

        // Eliminar intereses existentes para evitar duplicados si se asignan de nuevo
        _context.UsuarioIntereses.RemoveRange(usuario.UsuarioIntereses);

        // Obtener las entidades Interes reales
        var intereses = await _context.Intereses
            .Where(i => interesesIds.Contains(i.Id))
            .ToListAsync();

        // Crear nuevas entidades de unión UsuarioInteres
        foreach (var interes in intereses)
        {
            usuario.UsuarioIntereses.Add(new UsuarioInteres
            {
                usuario_id = usuario.Id,    // ¡ACTUALIZADO!
                interes_id = interes.Id     // ¡ACTUALIZADO!
            });
        }

        await _context.SaveChangesAsync();
    }
}