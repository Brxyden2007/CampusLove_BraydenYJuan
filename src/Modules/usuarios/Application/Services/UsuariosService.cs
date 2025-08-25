using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.src.Modules.Usuario.Domain.Entities;
using CampusLove_BraydenYJuan.src.Shared.Context;
using CampusLove_BraydenYJuan.src.Shared.Utils;
using Microsoft.EntityFrameworkCore;

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
        //

        var hash = PasswordHasher.HashPassword(usuario.PasswordUser ?? string.Empty);


        // Validar edad mínima
        if (usuario.Edad < 18)
        {
            throw new Exception("El usuario debe ser mayor de 18 años.");
        }
        // Validar longitud mínima de la contraseña
        if (usuario.PasswordUser.Length < 6)
        {
            throw new Exception("La contraseña debe tener al menos 6 caracteres.");
        }
        // Agregar usuario
        var usuarios = new Usuario
        {
            Nombre = usuario.Nombre,
            Apellido = usuario.Apellido,
            Email = usuario.Email,
            PasswordUser = usuario.PasswordUser, // si alcanzamos, hashear la contraseña
            Edad = usuario.Edad,
            Genero = usuario.Genero,
            Carrera = usuario.Carrera,
            Intereses = usuario.Intereses,
            Frase = usuario.Frase
        };
        _context.Usuarios.Add(usuarios);
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
}