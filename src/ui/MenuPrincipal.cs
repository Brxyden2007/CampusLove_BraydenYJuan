using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using CampusLove.src.Modules.Usuario.Domain.Entities;
using CampusLove.src.Modules.Usuario.UI;
using CampusLove.src.Shared.Utils;
using CampusLove_BraydenYJuan.src.Shared.Helpers;

namespace CampusLove.src.ui
{
    public class MenuPrincipal
    {
        public static async Task MenuMain()
        {
            var context = DbContextFactory.Create();
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("\n --- Menu Principal ---");
                Console.WriteLine("1. Registrarse como nuevo usuario");
                Console.WriteLine("2. Login Usuario");
                Console.WriteLine("3. Salir");
                Console.Write("Opcion: ");
                int opm = int.Parse(Console.ReadLine()!);
                switch (opm)
                {
                    case 1:
                        string nombre, apellido, email, password, genero, carrera, intereses, frase;
                        int edad;
                        Console.Write("Nombre: ");
                        nombre = Console.ReadLine()!;
                        Validaciones.EsNombreValido(nombre);
                        if (!Validaciones.EsNombreValido(nombre))
                        {
                            Console.WriteLine("Nombre invalido. Presiona Enter para continuar.");
                            Console.ReadLine();
                            break;
                        }
                        Console.Write("Apellido: ");
                        apellido = Console.ReadLine()!;
                        Console.Write("Email: ");
                        email = Console.ReadLine()!;
                        Console.Write("Password: ");
                        password = Console.ReadLine()!;
                        Console.Write("Edad: ");
                        edad = int.Parse(Console.ReadLine()!);
                        Console.Write("Genero (M/F): ");
                        genero = Console.ReadLine()!.ToUpper();
                        if (genero != "M" && genero != "F")
                        {
                            Console.WriteLine("Genero invalido. Presiona Enter para continuar.");
                            Console.ReadLine();
                            break;
                        }
                        Console.Write("Carrera: ");
                        carrera = Console.ReadLine()!;
                        Console.Write("Intereses (separados por comas): ");
                        intereses = Console.ReadLine()!;
                        Console.Write("Frase: ");
                        frase = Console.ReadLine()!;
                        var nuevoUsuario = new Usuario
                        {
                            Nombre = nombre,
                            Apellido = apellido,
                            Email = email,
                            PasswordUser = password,
                            Edad = edad,
                            Genero = genero,
                            Carrera = carrera,
                            Intereses = intereses,
                            Frase = frase
                        };
                        context.Usuarios.Add(nuevoUsuario);
                        context.SaveChanges();
                        Console.WriteLine("Usuario registrado exitosamente. Presiona Enter para continuar.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("Email: ");
                        string emailLogin = Console.ReadLine()!;
                        Console.Write("Password: ");
                        string passwordLogin = Console.ReadLine()!;
                        var usuario = context.Usuarios.FirstOrDefault(u => u.Email == emailLogin && u.PasswordUser == passwordLogin);
                        if (usuario != null)
                        {
                            Console.WriteLine($"Bienvenido, {usuario.Nombre} {usuario.Apellido}! Presiona Enter para continuar.");
                            Console.ReadLine();
                            _ = MenuUsuario.MostrarMenu();
                        }
                        else
                        {
                            Console.WriteLine("Credenciales invalidas. Presiona Enter para continuar.");
                            Console.ReadLine();
                        }
                        Console.Clear();
                        break;
                    case 3:
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opcion Invalida, vuelva a introducir una opcion correcta.");
                        Console.ReadLine();
                        break;
                        // Falta implementar que se pueda establecer bien ya que al insertar una letra se quita automaticamente el sistema
                        // Falta implementar el hash de la password
                        // Falta implementar el menu de usuario
                        // Falta implementar las validaciones de los datos al registrarse
                        // Falta implementar que no se pueda registrar dos usuarios con el mismo email
                        // Falta implementar el logout
                }   
            }
        }
    }
}