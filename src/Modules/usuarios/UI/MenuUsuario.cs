using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove_BraydenYJuan.src.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace CampusLove.src.Modules.Usuario.UI;
public class MenuUsuario
{
    public static void MostrarMenu()
{
    var context = DbContextFactory.Create();
    bool salir = false;
    while (!salir)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=======================================");
        Console.WriteLine("           🌟 MENÚ USUARIO 🌟           ");
        Console.WriteLine("=======================================\n");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("  [1]  👤 Ver perfil");
        Console.WriteLine("  [2]  ✏️  Editar perfil");
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
                Console.Clear();
                break;
            case 2:
                Console.Clear();
                break;
            case 3:
                Console.Clear();
                break;
            case 4:
                Console.Clear();
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

}