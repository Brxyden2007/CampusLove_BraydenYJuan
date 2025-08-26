using System;
using System.Linq;
using System.Collections.Generic;
using CampusLove.src.Shared.Utils;
using CampusLove.src.Modules.Usuario.Domain.Entities;
using CampusLove_BraydenYJuan.src.Shared.Helpers;
using CampusLove_BraydenYJuan.src.Modules.intereses.Domain.Entities;
using CampusLove_BraydenYJuan.src.Modules.usuarios_intereses.Domain.Entities; // <-- ¡Asegúrate de incluir este using!
using CampusLove.src.Modules.Usuario.UI;
using CampusLove_BraydenYJuan.src.Shared.Context; // Asegúrate de tener el using para tu DbContextFactory

namespace CampusLove.src.UI
{
    public class MenuPrincipal
    {
        public static void MenuMain()
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("=======================================");
                Console.WriteLine("          🌐 MENÚ PRINCIPAL 🌐         ");
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
                    Console.WriteLine("❌ Opción inválida. Presiona Enter para continuar.");
                    Console.ReadLine();
                    continue;
                }

                switch (opm)
                {
                    case 1:
                        RegistrarUsuario();
                        break;

                    case 2:
                        LoginUsuario();
                        break;

                    case 3:
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("❌ Opción inválida.");
                        Console.WriteLine("Presiona Enter para continuar.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        // 🔹 Método de Registro
        private static void RegistrarUsuario()
        {
            var context = DbContextFactory.Create();

            Console.Clear();
            Console.WriteLine("=== Registro de Usuario ===");

            string nombre, apellido, email, password, genero, carrera, frase;
            int edad;

            Console.Write("Nombre: ");
            nombre = Console.ReadLine()!;
            if (!Validaciones.EsSoloLetras(nombre)) { Console.WriteLine("❌ Nombre inválido."); Console.ReadLine(); return; }

            Console.Write("Apellido: ");
            apellido = Console.ReadLine()!;
            if (!Validaciones.EsSoloLetras(apellido)) { Console.WriteLine("❌ Apellido inválido."); Console.ReadLine(); return; }

            Console.Write("Email: ");
            email = Console.ReadLine()!;
            if (!Validaciones.EsEmailValido(email)) { Console.WriteLine("❌ Email inválido."); Console.ReadLine(); return; }

            if (context.Usuarios.Any(u => u.Email == email))
            {
                Console.WriteLine("❌ Ya existe un usuario con ese correo.");
                Console.ReadLine();
                return;
            }

            Console.Write("Password: ");
            password = Console.ReadLine()!;
            if (!Validaciones.EsPasswordValido(password)) { Console.WriteLine("❌ Contraseña inválida."); Console.ReadLine(); return; }

            Console.Write("Edad: ");
            if (!Validaciones.EsEdadValida(Console.ReadLine()!, out edad)) { Console.WriteLine("❌ Edad inválida."); Console.ReadLine(); return; }

            Console.Write("Genero (M/F): ");
            genero = Console.ReadLine()!;
            if (!Validaciones.EsGeneroValido(genero)) { Console.WriteLine("❌ Género inválido."); Console.ReadLine(); return; }

            Console.Write("Carrera: ");
            carrera = Console.ReadLine()!;
            if (!Validaciones.EsSoloLetrasConEspacios(carrera)) { Console.WriteLine("❌ Carrera inválida."); Console.ReadLine(); return; }

            // Intereses
            var intereses = context.Intereses.ToList();
            Console.WriteLine("\n=== Selecciona tus intereses ===");

            for (int i = 0; i < intereses.Count; i++)
                Console.WriteLine($"[{i + 1}] {intereses[i].Nombre}");

            Console.Write("\n👉 Ingresa los números separados por coma: ");
            var entrada = Console.ReadLine();

            var seleccionados = new List<Interes>();
            if (!string.IsNullOrWhiteSpace(entrada))
            {
                var seleccion = entrada.Split(',')
                    .Select(x => int.TryParse(x.Trim(), out var num) ? num : -1)
                    .Where(x => x > 0 && x <= intereses.Count)
                    .ToList();

                seleccionados = intereses
                    .Where((i, index) => seleccion.Contains(index + 1))
                    .ToList();
            }

            Console.Write("Frase: ");
            frase = Console.ReadLine()!;
            if (!Validaciones.EsFraseValida(frase)) { Console.WriteLine("❌ Frase inválida."); Console.ReadLine(); return; }

            var nuevoUsuario = new Usuario
            {
                Nombre = nombre,
                Apellido = apellido,
                Email = email,
                PasswordUser = password,
                Edad = edad,
                Genero = genero,
                Carrera = carrera,
                Frase = frase
            };

            // Creamos las relaciones explícitas con UsuarioInteres
            foreach (var interes in seleccionados)
            {
                nuevoUsuario.UsuarioIntereses.Add(new UsuarioInteres
                {
                    // ¡ACTUALIZADO! Usamos 'interes_id' (snake_case)
                    interes_id = interes.Id
                });
            }

            context.Usuarios.Add(nuevoUsuario);
            context.SaveChanges(); // <-- Línea 161 que da el error

            Console.WriteLine("✅ Usuario registrado exitosamente. Presiona Enter.");
            Console.ReadLine();
        }

        // 🔹 Método de Login
        private static void LoginUsuario()
        {
            var context = DbContextFactory.Create();

            Console.Clear();
            Console.WriteLine("=== Login Usuario ===");

            Console.Write("Email: ");
            string email = Console.ReadLine()!;

            Console.Write("Password: ");
            string password = Console.ReadLine()!;

            var usuario = context.Usuarios
                .FirstOrDefault(u => u.Email == email && u.PasswordUser == password);

            if (usuario != null)
            {
                Console.WriteLine($"✅ Bienvenido, {usuario.Nombre} {usuario.Apellido}!");
                Console.ReadLine();
                MenuUsuario.MostrarMenu();
            }
            else
            {
                Console.WriteLine("❌ Credenciales inválidas.");
                Console.ReadLine();
            }
        }
    }
}
