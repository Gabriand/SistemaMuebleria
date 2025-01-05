using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MuebleriaPIS.Modelos;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MuebleriaPIS;
using MuebleriaPIS.VistaModelo;
using MuebleriaPIS.Vistas.Compartido;
using MuebleriaPIS.Vistas.Ingreso;
using MuebleriaPIS.Vistas.Catalogo;

namespace MuebleriaPIS.Vistas
{
    public partial class IngresoPage : Page
    {
        private BarraNavegacionVistaModelo _viewModel;

        private List<Usuario> Usuarios;

        public IngresoPage()
        {
            InitializeComponent();
            Usuarios = new List<Usuario>
            {
                new Usuario { Id = 1, Nombre = "Admin", Rol = "Administrador", Correo = "admin@muebleria.com", Contrasena = "1234" },
                new Usuario { Id = 2, Nombre = "Trabajador", Rol = "Trabajador", Correo = "trabajador@muebleria.com", Contrasena = "1234" },
                new Usuario { Id = 3, Nombre = "Cliente", Rol = "Cliente", Correo = "cliente@muebleria.com", Contrasena = "1234" }
            };

            //Barra de Navegacion
            _viewModel = new BarraNavegacionVistaModelo
            {
                MostrarControlesUsuario = false,  // Oculta los controles de usuario en la página de ingreso
            };
            barraNavegacion.DataContext = _viewModel;
        }

        private void IngresoBtn_Click(object sender, RoutedEventArgs e)
        {
            string correo = txtUsuario.Text;
            string contraseña = txtContrasena.Password;

            var usuario = Usuarios.FirstOrDefault(u => u.Correo == correo && u.Contrasena == contraseña);

            if (usuario != null)
            {
                MessageBox.Show($"Bienvenido, {usuario.Nombre}");
                this.NavigationService.Navigate(new CatalogoProductos());
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas.");
            }
        }

        private void btnRegistrarse_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistroCliente());
        }

        private void OlvidasteContrasena_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RecuperarContrasena());
        }
    }
}
