using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusLove.src.Shared.Utils
{
    public class Validaciones
    {
        public static bool EsEmailValido(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool EsEdadValida(int edad)
        {
            return edad >= 18 && edad <= 100;
        }

        public static bool EsGeneroValido(string genero)
        {
            var generosValidos = new List<string> { "M", "F", "O" }; // M: Masculino, F: Femenino, O: Otro
            return generosValidos.Contains(genero.ToUpper());
        }

        public static bool EsPasswordValida(string password)
        {
            // Ejemplo simple: al menos 6 caracteres
            return !string.IsNullOrWhiteSpace(password) && password.Length >= 6;
        }

        public static bool EsNombreValido(string nombre)
        {
            return !string.IsNullOrWhiteSpace(nombre) && nombre.Length <= 50;   
        }

        public static bool EsApellidoValido(string apellido)
        {
            return !string.IsNullOrWhiteSpace(apellido) && apellido.Length <= 50;
        }

        public static bool EsCarreraValida(string carrera)
        {
            return !string.IsNullOrWhiteSpace(carrera) && carrera.Length <= 120;
        }

        public static bool EsInteresesValidos(string intereses)
        {
            return !string.IsNullOrWhiteSpace(intereses) && intereses.Length <= 255;
        }
        
        public static bool EsFraseValida(string frase)
        {
            return !string.IsNullOrWhiteSpace(frase) && frase.Length <= 255;
        }
    }
}