using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CampusLove.src.Shared.Utils
{
    public class Validaciones
    {
       public static bool EsSoloLetras(string valor)
        {
            return !string.IsNullOrWhiteSpace(valor) &&
                   valor.All(char.IsLetter);
        }

        // ✅ Letras + espacios (para nombres completos o carreras)
        public static bool EsSoloLetrasConEspacios(string valor)
        {
            return !string.IsNullOrWhiteSpace(valor) &&
                   valor.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }

        public static bool EsEmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public static bool EsPasswordValido(string password)
        {
            return !string.IsNullOrWhiteSpace(password) && password.Length >= 4;
        }

        public static bool EsEdadValida(string valor, out int edad)
        {
            return int.TryParse(valor, out edad) && edad > 0 && edad <= 120;
        }

        public static bool EsGeneroValido(string genero)
        {
            return genero.ToUpper() == "M" || genero.ToUpper() == "F";
        }

        public static bool EsInteresesValido(string intereses)
        {
            return !string.IsNullOrWhiteSpace(intereses);
        }

        public static bool EsFraseValida(string frase)
        {
            return !string.IsNullOrWhiteSpace(frase);
        }
    }
}