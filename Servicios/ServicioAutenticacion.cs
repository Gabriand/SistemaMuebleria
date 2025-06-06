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
                new Usuario { Id = 1, Nombre = "Admin", Apellido = "Admin", NomUsuario = "admin", Rol = "Admin", Correo = "admin@muebleria.com", Contrasena = "1234" },
                new Usuario { Id = 2, Nombre = "Trabajador", Apellido = "Trabajador", NomUsuario = "trabajador", Rol = "Trabajador", Correo = "trabajador@muebleria.com", Contrasena = "1234" },
                new Usuario { Id = 3, Nombre = "Cliente", Apellido = "Cliente", NomUsuario = "cliente", Rol = "Cliente", Correo = "cliente@muebleria.com", Contrasena = "1234" },
                //Usuario de prueba
                new Usuario { Id = 4, Nombre = "Juan", Apellido = "Perez", NomUsuario = "juanperez", Rol = "Cliente", Correo = "usuario1@muebleria.com", Contrasena = "1234", Direccion = "Calle Falsa 123", Telefono = 123456789 },
                new Usuario { Id = 5, Nombre = "Natalia", Apellido = "Vera", NomUsuario = "nataliav", Rol = "Cliente", Correo = "usuario2@muebleria.com", Contrasena = "1234", Direccion = "Calle Falsa 456", Telefono = 123456789 }
            };
        }

        public Usuario Autenticar(string identificador, string contrasena)
        {
            var usuario = Usuarios.FirstOrDefault(u => (u.Correo == identificador || u.NomUsuario == identificador) && u.Contrasena == contrasena);
            if (usuario != null)
            {
                EstadoAutenticacion.Instancia.UsuarioAutenticado = usuario;
            }
            return usuario;
        }

        public bool ExisteUsuario(string usuario, string correo)
        {
            return Usuarios.Any(u => u.NomUsuario == usuario || u.Correo == correo);
        }

        public void RegistrarUsuario(Usuario nuevoUsuario)
        {
            Usuarios.Add(nuevoUsuario);
        }
    }
}
