using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove_BraydenYJuan.src.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace CampusLove.src.Modules.Usuario.UI;
public class MenuUsuario
{
    public static async Task MostrarMenu()
    {
        var context = DbContextFactory.Create();
        bool salir = false;
        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("\n --- Menu Usuario ---");
            Console.WriteLine("1. Ver perfil");
            Console.WriteLine("2. Editar perfil");
            Console.WriteLine("3. Ver mis coincidencias (Matches)");
            Console.WriteLine("4. Ver estadisticas del sistema (usuarios con más likes, más matches, etc.)");
            Console.WriteLine("5. Salir");
            Console.Write("Opcion: ");
            int opm = int.Parse(Console.ReadLine()!);
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
                    Console.WriteLine("Opcion invalida. Presiona Enter para continuar.");
                    Console.ReadLine();
                    break;
            }
        }
    }
}