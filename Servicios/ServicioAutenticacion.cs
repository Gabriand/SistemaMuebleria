using System;
using System.Collections.Generic;
using System.Linq;
using MuebleriaPIS.Modelos;

namespace MuebleriaPIS.Servicios
{
    internal class ServicioAutenticacion
    {
        private List<Usuario> Usuarios;

        public ServicioAutenticacion()
        {
            Usuarios = new List<Usuario>
            {
                new Usuario { Id = 1, Nombre = "Admin", Rol = "Admin", Correo = "admin@muebleria.com", Contrasena = "1234" },
                new Usuario { Id = 2, Nombre = "Trabajador", Rol = "Trabajador", Correo = "trabajador@muebleria.com", Contrasena = "1234" },
                new Usuario { Id = 3, Nombre = "Cliente", Rol = "Cliente", Correo = "cliente@muebleria.com", Contrasena = "1234" },
                //Usuario de prueba
                new Usuario { Id = 4, Nombre = "JuanPerez", Rol = "Cliente", Correo = "usuario1@muebleria.com", Contrasena = "abcd", Direccion = "Calle Falsa 123", Telefono = 123456789 },
                new Usuario {Id = 5, Nombre = "Nataliap", Rol = "Cliente", Correo = "Usuario2@muebleria.com", Contrasena = "abcd", Direccion = "Calle Falsa 456", Telefono = 123456789 }
            };
        }

        public Usuario Autenticar(string identificador, string contrasena)
        {
            var usuario = Usuarios.FirstOrDefault(u => (u.Correo == identificador || u.Nombre == identificador) && u.Contrasena == contrasena);
            if (usuario != null)
            {
                EstadoAutenticacion.Instancia.UsuarioAutenticado = usuario;
            }
            return usuario;
        }
    }
}
