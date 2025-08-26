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
        public static void MenuMain()
        {
            var context = DbContextFactory.Create();
            bool salir = false;
            while (!salir)
            {

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("=======================================");
                Console.WriteLine("          🌐 MENÚ PRINCIPAL 🌐          ");
                Console.WriteLine("=======================================\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("  [1] 📝 Registrarse como nuevo usuario");
                Console.WriteLine("  [2] 🔑 Login Usuario");
                Console.WriteLine("  [3] 🚪 Salir\n");
                Console.ForegroundColor = ConsoleColor.Green;
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
                string nombre, apellido, email, password, genero, carrera, intereses, frase;
                int edad;

                Console.Write("Nombre: ");
                nombre = Console.ReadLine()!;
                if (!Validaciones.EsSoloLetras(nombre))
                {
                Console.WriteLine("❌ Nombre inválido. Solo letras sin espacios ni caracteres especiales.");
                Console.ReadLine();
                break;
                }

                Console.Write("Apellido: ");
                apellido = Console.ReadLine()!;
                if (!Validaciones.EsSoloLetras(apellido))
                {
                Console.WriteLine("❌ Apellido inválido. Solo letras sin espacios ni caracteres especiales.");
                Console.ReadLine();
                break;
                }

                Console.Write("Email: ");
                email = Console.ReadLine()!;
                if (!Validaciones.EsEmailValido(email))
                {
                Console.WriteLine("❌ Email inválido.");
                Console.ReadLine();
                break;
                }

                Console.Write("Password: ");
                password = Console.ReadLine()!;
                if (!Validaciones.EsPasswordValido(password))
                {
                Console.WriteLine("❌ La contraseña debe tener al menos 4 caracteres.");
                Console.ReadLine();
                break;
                }

                Console.Write("Edad: ");
                if (!Validaciones.EsEdadValida(Console.ReadLine()!, out edad))
                {
                Console.WriteLine("❌ Edad inválida. Debe ser un número entre 1 y 120.");
                Console.ReadLine();
                break;
                }

                Console.Write("Genero (M/F): ");
                genero = Console.ReadLine()!;
                if (!Validaciones.EsGeneroValido(genero))
                {
                Console.WriteLine("❌ Género inválido. Solo 'M' o 'F'.");
                Console.ReadLine();
                break;
                }

                Console.Write("Carrera: ");
                carrera = Console.ReadLine()!;
                if (!Validaciones.EsSoloLetrasConEspacios(carrera))
                {
                    Console.WriteLine("❌ Carrera inválida. Solo letras y espacios.");
                    Console.ReadLine();
                    break;
                }

                Console.Write("Intereses (separados por comas): ");
                intereses = Console.ReadLine()!;
                if (!Validaciones.EsInteresesValido(intereses))
                {
                Console.WriteLine("❌ Intereses inválidos.");
                Console.ReadLine();
                break;
                }

                Console.Write("Frase: ");
                frase = Console.ReadLine()!;
                if (!Validaciones.EsFraseValida(frase))
                {
                Console.WriteLine("❌ La frase no puede estar vacía.");
                Console.ReadLine();
                break;
                }

    // ✅ Guardar en DB
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
            Console.WriteLine("✅ Usuario registrado exitosamente. Presiona Enter para continuar.");
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
                            MenuUsuario.MostrarMenu();
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