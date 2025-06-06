using System;
using System.Windows;
using System.Windows.Controls;
using MuebleriaPIS.VistaModelo;
using MuebleriaPIS.Vistas.Catalogo;
using MuebleriaPIS.Vistas.Ingreso;
using MuebleriaPIS.Vistas.GestionUsuarios;
using MuebleriaPIS.Utilidades;
using MuebleriaPIS.Modelos;
using MuebleriaPIS.Servicios;

namespace MuebleriaPIS.Vistas
{
    public partial class IngresoPage : Page
    {
        private BarraNavegacionVistaModelo _viewModel;
        private ServicioAutenticacion _servicioAutenticacion = new ServicioAutenticacion();

        public IngresoPage()
        {
            InitializeComponent();

            _viewModel = new BarraNavegacionVistaModelo
            {
                MostrarControlesUsuario = false,
            };
            barraNavegacion.DataContext = _viewModel;

            DataContext = new IngresoVistaModelo();
        }

        private void IngresoBtn_Click(object sender, RoutedEventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contrasena = txtContrasena.Password;

            var usuarioAutenticado = _servicioAutenticacion.Autenticar(usuario, contrasena);

            if (usuarioAutenticado != null)
            {
                MessageBox.Show("Bienvenido, " + usuarioAutenticado.NomUsuario, "Acceso Exitoso", MessageBoxButton.OK, MessageBoxImage.Information);

                if (usuarioAutenticado.Rol == "Admin")
                {
                    this.NavigationService.Navigate(new InicioAdmin());
                }
                else if (usuarioAutenticado.Rol == "Trabajador")
                {
                    this.NavigationService.Navigate(new InicioTrabajador());
                }
                else
                {
                    Sesion.IdCliente = usuarioAutenticado.Id;
                    this.NavigationService.Navigate(new CatalogoProductos());
                }
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnRegistrarse_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistroCliente());
        }

        private void OlvidasteContrasena_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RecuperarContrasena());
        }
    }
}

