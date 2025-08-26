using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove_BraydenYJuan.src.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using CampusLove_BraydenYJuan.src.Shared.Context; // Asegúrate de tener el using para DbContextFactory
using CampusLove_BraydenYJuan.src.Modules.usuarios_intereses.Domain.Entities; // Para UsuarioInteres

namespace CampusLove.src.Modules.Usuario.UI;

public class MenuUsuario
{
    public static void MostrarMenu()
    {
        int usuarioActualId = 1; // EJEMPLO: Reemplaza con el ID del usuario logueado.

        var context = DbContextFactory.Create();
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
            Console.WriteLine("  [3]  💖 Ver mis coincidencias (Matches)");
            Console.WriteLine("  [4]  📊 Ver estadísticas del sistema");
            Console.WriteLine("  [5]  🚪 Salir\n");

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
                    VerMatches(usuarioActualId);
                    break;
                case 4:
                    VerEstadisticas();
                    break;
                case 5:
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
        if (int.TryParse(edadStr, out int nuevaEdad))
            usuario.Edad = nuevaEdad;

        Console.Write($"Nueva frase (Actual: {usuario.Frase}): ");
        var frase = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(frase))
            usuario.Frase = frase;

        context.SaveChanges();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n✅ Perfil actualizado correctamente.");
        Console.ResetColor();
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

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("======= 📊 ESTADÍSTICAS DEL SISTEMA =======");
        Console.ResetColor();

        Console.WriteLine($"👥 Total de usuarios registrados: {totalUsuarios}");
        Console.WriteLine($"💖 Total de matches realizados: {totalMatches}");
        Console.WriteLine($"👍 Total de likes dados: {totalLikes}");

        Console.WriteLine("\nPresiona Enter para volver...");
        Console.ReadLine();
    }
}