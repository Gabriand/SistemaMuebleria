using System;
using System.Text.RegularExpressions;

namespace MuebleriaPIS.Utilidades
{
    internal class Validador
    {
        public static bool EsCorreoValido(string correo)
        {
            if (string.IsNullOrWhiteSpace(correo))
                return false;

            try
            {
                // Usar una expresión regular para validar el formato del correo electrónico
                var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                return regex.IsMatch(correo);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
