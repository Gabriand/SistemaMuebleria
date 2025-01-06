using System;
using System.Windows;
using System.Windows.Controls;
using MuebleriaPIS.VistaModelo;

namespace MuebleriaPIS.Vistas.GestionUsuarios
{
    public partial class DetalleUsuario : Page
    {
        private DetalleUsuarioVistaModelo _detalleUsuarioVistaModelo;

        public DetalleUsuario()
        {
            InitializeComponent();
            try
            {
                _detalleUsuarioVistaModelo = new DetalleUsuarioVistaModelo();
                DataContext = _detalleUsuarioVistaModelo;
                MostrarDatosUsuario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar DetalleUsuario: {ex.Message}");
            }
        }

        private void MostrarDatosUsuario()
        {
            try
            {
                var usuario = _detalleUsuarioVistaModelo.UsuarioAutenticado;
                if (usuario != null)
                {
                    txtNombreUs.Text = usuario.Nombre ?? string.Empty;
                    txtCorreoUs.Text = usuario.Correo ?? string.Empty;
                    txtTelefonoUs.Text = usuario.Telefono.HasValue ? usuario.Telefono.Value.ToString() : string.Empty;
                    txtDireccionUs.Text = usuario.Direccion ?? string.Empty;

                    txtNombreUs.IsReadOnly = true;
                    txtCorreoUs.IsReadOnly = true;
                    txtTelefonoUs.IsReadOnly = true;
                    txtDireccionUs.IsReadOnly = true;
                }
                else
                {
                    MessageBox.Show("No se encontró un usuario autenticado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar datos del usuario: {ex.Message}");
            }
        }

        private void EditarPerfilBtn_Click(object sender, RoutedEventArgs e)
        {
            txtNombreUs.IsReadOnly = false;
            txtCorreoUs.IsReadOnly = false;
            txtTelefonoUs.IsReadOnly = false;
            txtDireccionUs.IsReadOnly = false;
        }

        private void CerrarSesionBtn_Click(object sender, RoutedEventArgs e)
        {
            // Navegar a la página de ingreso
            NavigationService.Navigate(new Uri("/Vistas/Ingreso/Ingreso.xaml", UriKind.Relative));
        }
    }
}
