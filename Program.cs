using CampusLove.src.ui;
using CampusLove_BraydenYJuan.src.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    public static void Main(String[] args)
    {
        try
        {
            using var context = DbContextFactory.Create(); // Crea instancia del contexto

            // Fuerza la apertura de la conexión a la base de datos
            context.Database.OpenConnection();
            Console.WriteLine("✅ Conexión a la base de datos exitosa.");

            // Cierra la conexión luego de la prueba
            context.Database.CloseConnection();
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ Error al conectar con la base de datos:");
            Console.WriteLine(ex.Message);
        }

        _ = MenuPrincipal.MenuMain();
    }
}