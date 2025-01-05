using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using System.Windows;
using MuebleriaPIS.Modelos;
using MuebleriaPIS.Vistas;
using MuebleriaPIS.Vistas.Catalogo;

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
                //Agregado para pruebas
                new Usuario { Id = 4, Nombre = "JuanPere", Rol = "Cliente", Correo = "usuario1@muebleria.com", Contrasena = "abcd" },
            };
        }

        public Usuario Autenticar(string identificador, string contrasena)
        {
            return Usuarios.FirstOrDefault(u => (u.Correo == identificador || u.Nombre == identificador) && u.Contrasena == contrasena);
        }
    }
}