using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusLove.src.Modules.Usuario.UI
{
    public class MenuUsuario
    {
        public static async Task MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("\n --- Menu Usuario ---");
            Console.WriteLine("1. Ver perfil");
            Console.WriteLine("2. Editar perfil");
            Console.WriteLine("3. Ver mis coincidencias (Matches)");
            Console.WriteLine("4. Ver estadisticas del sistema (usuarios con más likes, más matches, etc.)");
        }
    }
}