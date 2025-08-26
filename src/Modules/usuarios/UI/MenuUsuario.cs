using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove_BraydenYJuan.src.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using CampusLove_BraydenYJuan.src.Shared.Context;
using CampusLove.src.Modules.Usuario.Domain.Entities;
using CampusLove_BraydenYJuan.src.Modules.intereses.Domain.Entities;
using CampusLove_BraydenYJuan.src.Modules.likes.Domain.Entities;
using CampusLove_BraydenYJuan.src.Modules.matches.Domain.Entities;

namespace CampusLove.src.Modules.Usuario.UI;

public class MenuUsuario
{
    private static int usuarioActualId = 0; // Mantener usuario actual

    public static void MostrarMenu(int usuarioId = 0)
    {
        if (usuarioId > 0)
            usuarioActualId = usuarioId;

        bool salir = false;
        while (!salir)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=======================================");
            Console.WriteLine("           🌟 MENÚ USUARIO 🌟          ");
            Console.WriteLine("=======================================\n");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  [1]  👤 Ver perfil");
            Console.WriteLine("  [2]  ✏️ Editar perfil");
            Console.WriteLine("  [3]  🎯 Editar intereses");
            Console.WriteLine("  [4]  💖 Ver mis coincidencias (Matches)");
            Console.WriteLine("  [5]  👍 Dar likes a otros usuarios");
            Console.WriteLine("  [6]  📊 Ver estadísticas del sistema");
            Console.WriteLine("  [7]  🚪 Salir\n");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=======================================");
            Console.ResetColor();
            Console.Write("👉 Elige una opción: ");

            if (!int.TryParse(Console.ReadLine(), out int opm))
            {
                Console.WriteLine("Opción inválida. Presiona Enter para continuar.");
                Console.ReadLine();
                continue;
            }

            switch (opm)
            {
                case 1:
                    VerPerfil(usuarioActualId);
                    break;
                case 2:
                    EditarPerfil(usuarioActualId);
                    break;
                case 3:
                    EditarIntereses(usuarioActualId);
                    break;
                case 4:
                    VerMatches(usuarioActualId);
                    break;
                case 5:
                    DarLikes(usuarioActualId);
                    break;
                case 6:
                    VerEstadisticas();
                    break;
                case 7:
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción inválida. Presiona Enter para continuar.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    public static void VerPerfil(int usuarioId)
    {
        using var context = DbContextFactory.Create();

        var usuario = context.Usuarios
            .Include(u => u.UsuarioIntereses)
            .ThenInclude(ui => ui.Interes)
            .FirstOrDefault(u => u.Id == usuarioId);

        if (usuario == null)
        {
            Console.WriteLine("❌ Usuario no encontrado.");
            Console.ReadLine();
            return;
        }

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("======= 👤 PERFIL DE USUARIO =======");
        Console.ResetColor();

        Console.WriteLine($"📛 Nombre: {usuario.Nombre} {usuario.Apellido}");
        Console.WriteLine($"📧 Email: {usuario.Email}");
        Console.WriteLine($"🎓 Carrera: {usuario.Carrera}");
        Console.WriteLine($"📅 Edad: {usuario.Edad}");
        Console.WriteLine($"⚧ Género: {usuario.Genero}");
        Console.WriteLine($"💬 Frase: {usuario.Frase}");

        if (usuario.UsuarioIntereses != null && usuario.UsuarioIntereses.Any())
        {
            Console.Write("🎯 Intereses: ");
            Console.WriteLine(string.Join(", ", usuario.UsuarioIntereses.Select(ui => ui.Interes?.Nombre)));
        }
        else
        {
            Console.WriteLine("🎯 Intereses: Ninguno");
        }

        Console.WriteLine("\nPresiona Enter para volver...");
        Console.ReadLine();
    }

    public static void EditarPerfil(int usuarioId)
    {
        using var context = DbContextFactory.Create();

        var usuario = context.Usuarios.FirstOrDefault(u => u.Id == usuarioId);
        if (usuario == null)
        {
            Console.WriteLine("❌ Usuario no encontrado.");
            Console.ReadLine();
            return;
        }

        Console.Clear();
        Console.WriteLine("=== ✏️ Editar Perfil ===");
        Console.WriteLine("Deja en blanco si no quieres cambiar el campo.\n");

        Console.Write($"Nueva carrera (Actual: {usuario.Carrera}): ");
        var carrera = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(carrera))
            usuario.Carrera = carrera;

        Console.Write($"Nueva edad (Actual: {usuario.Edad}): ");
        var edadStr = Console.ReadLine();
        if (int.TryParse(edadStr, out int nuevaEdad) && nuevaEdad >= 18 && nuevaEdad <= 100)
            usuario.Edad = nuevaEdad;

        Console.Write($"Nueva frase (Actual: {usuario.Frase}): ");
        var frase = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(frase))
            usuario.Frase = frase;

        try
        {
            context.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n✅ Perfil actualizado correctamente.");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n❌ Error al actualizar perfil: {ex.Message}");
            Console.ResetColor();
        }
        
        Console.ReadLine();
    }

    public static void EditarIntereses(int usuarioId)
    {
        using var context = DbContextFactory.Create();

        var usuario = context.Usuarios
            .Include(u => u.UsuarioIntereses)
            .ThenInclude(ui => ui.Interes)
            .FirstOrDefault(u => u.Id == usuarioId);

        if (usuario == null)
        {
            Console.WriteLine("❌ Usuario no encontrado.");
            Console.ReadLine();
            return;
        }

        Console.Clear();
        Console.WriteLine("=== 🎯 Editar Intereses ===");

        if (usuario.UsuarioIntereses != null && usuario.UsuarioIntereses.Any())
        {
            Console.WriteLine("Tus intereses actuales:");
            foreach (var ui in usuario.UsuarioIntereses)
                Console.WriteLine($"- {ui.Interes?.Nombre}");
        }
        else
        {
            Console.WriteLine("No tienes intereses registrados.");
        }

        Console.WriteLine("\n¿Deseas cambiar tus intereses? (s/n): ");
        var respuesta = Console.ReadLine();

        if (respuesta?.ToLower() == "s")
        {
            if (usuario.UsuarioIntereses != null)
                context.UsuarioIntereses.RemoveRange(usuario.UsuarioIntereses);

            var intereses = context.Intereses.ToList();
            Console.WriteLine("\n=== Selecciona tus nuevos intereses ===");

            for (int i = 0; i < intereses.Count; i++)
                Console.WriteLine($"[{i + 1}] {intereses[i].Nombre}");

            Console.Write("\n👉 Ingresa los números separados por coma: ");
            var entrada = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(entrada))
            {
                var seleccion = entrada.Split(',')
                    .Select(x => int.TryParse(x.Trim(), out var num) ? num : -1)
                    .Where(x => x > 0 && x <= intereses.Count)
                    .ToList();

                foreach (var index in seleccion)
                {
                    var interes = intereses[index - 1];
                    var usuarioInteres = new UsuarioInteres
                    {
                        UsuarioId = usuarioId,
                        InteresId = interes.Id
                    };
                    context.UsuarioIntereses.Add(usuarioInteres);
                }
            }

            try
            {
                context.SaveChanges();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n✅ Intereses actualizados correctamente.");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n❌ Error al actualizar intereses: {ex.Message}");
                Console.ResetColor();
            }
        }

        Console.ReadLine();
    }

    public static void DarLikes(int usuarioId)
    {
        using var context = DbContextFactory.Create();

        var otrosUsuarios = context.Usuarios
            .Where(u => u.Id != usuarioId)
            .Include(u => u.UsuarioIntereses)
            .ThenInclude(ui => ui.Interes)
            .ToList();

        if (!otrosUsuarios.Any())
        {
            Console.WriteLine("❌ No hay otros usuarios disponibles.");
            Console.ReadLine();
            return;
        }

        Console.Clear();
        Console.WriteLine("=== 👍 Dar Likes ===");

        foreach (var usuario in otrosUsuarios.Take(5))
        {
            Console.WriteLine($"\n👤 {usuario.Nombre} {usuario.Apellido}");
            Console.WriteLine($"🎓 Carrera: {usuario.Carrera}");
            Console.WriteLine($"📅 Edad: {usuario.Edad}");
            Console.WriteLine($"💬 Frase: {usuario.Frase}");
            
            if (usuario.UsuarioIntereses != null && usuario.UsuarioIntereses.Any())
                Console.WriteLine($"🎯 Intereses: {string.Join(", ", usuario.UsuarioIntereses.Select(ui => ui.Interes?.Nombre))}");

            Console.Write("\n¿Te gusta este usuario? (s/n): ");
            var respuesta = Console.ReadLine();

            if (respuesta?.ToLower() == "s")
            {
                var likeExistente = context.Likes
                    .FirstOrDefault(l => l.UsuarioDadorId == usuarioId && l.UsuarioReceptorId == usuario.Id);

                if (likeExistente == null)
                {
                    var nuevoLike = new Like
                    {
                        UsuarioDadorId = usuarioId,
                        UsuarioReceptorId = usuario.Id,
                        FechaLike = DateTime.Now
                    };
                    context.Likes.Add(nuevoLike);

                    var likeReciproco = context.Likes
                        .FirstOrDefault(l => l.UsuarioDadorId == usuario.Id && l.UsuarioReceptorId == usuarioId);

                    if (likeReciproco != null)
                    {
                        var nuevoMatch = new Match
                        {
                            Usuario1Id = usuarioId,
                            Usuario2Id = usuario.Id,
                            FechaMatch = DateTime.Now
                        };
                        context.Matches.Add(nuevoMatch);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("🎉 ¡Es un MATCH! 💖");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("👍 Like enviado.");
                        Console.ResetColor();
                    }

                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Ya le diste like a este usuario.");
                }
            }
        }

        Console.WriteLine("\nPresiona Enter para volver...");
        Console.ReadLine();
    }

    public static void VerMatches(int usuarioId)
    {
        using var context = DbContextFactory.Create();

        var matches = context.Matches
            .Include(m => m.Usuario1)
            .Include(m => m.Usuario2)
            .Where(m => m.Usuario1Id == usuarioId || m.Usuario2Id == usuarioId)
            .ToList();

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("======= 💖 MIS MATCHES =======");
        Console.ResetColor();

        if (!matches.Any())
        {
            Console.WriteLine("Aún no tienes coincidencias 😢");
        }
        else
        {
            foreach (var match in matches)
            {
                var otroUsuario = match.Usuario1Id == usuarioId ? match.Usuario2 : match.Usuario1;
                Console.WriteLine($"👉 {otroUsuario?.Nombre} {otroUsuario?.Apellido} - {otroUsuario?.Carrera}");
                Console.WriteLine($"   📅 Match desde: {match.FechaMatch:dd/MM/yyyy}");
            }
        }

        Console.WriteLine("\nPresiona Enter para volver...");
        Console.ReadLine();
    }

    public static void VerEstadisticas()
    {
        using var context = DbContextFactory.Create();

        var totalUsuarios = context.Usuarios.Count();
        var totalMatches = context.Matches.Count();
        var totalLikes = context.Likes.Count();
        var totalIntereses = context.Intereses.Count();

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("======= 📊 ESTADÍSTICAS DEL SISTEMA =======");
        Console.ResetColor();

        Console.WriteLine($"👥 Total de usuarios registrados: {totalUsuarios}");
        Console.WriteLine($"💖 Total de matches realizados: {totalMatches}");
        Console.WriteLine($"👍 Total de likes dados: {totalLikes}");
        Console.WriteLine($"🎯 Total de intereses disponibles: {totalIntereses}");

        Console.WriteLine("\nPresiona Enter para volver...");
        Console.ReadLine();
    }
}
