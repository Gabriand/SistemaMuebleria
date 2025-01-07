using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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
                    txtNombreCompletoUs.Text = $"{usuario.Nombre} {usuario.Apellido}" ?? string.Empty;
                    txtCorreoUs.Text = usuario.Correo ?? string.Empty;
                    txtTelefonoUs.Text = usuario.Telefono.HasValue ? usuario.Telefono.Value.ToString() : string.Empty;
                    txtDireccionUs.Text = usuario.Direccion ?? string.Empty;

                    txtNombreCompletoUs.IsReadOnly = true;
                    txtCorreoUs.IsReadOnly = true;
                    txtTelefonoUs.IsReadOnly = true;
                    txtDireccionUs.IsReadOnly = true;

                    txtNombreCompletoUs.Foreground = Brushes.Gray;
                    txtCorreoUs.Foreground = Brushes.Gray;
                    txtTelefonoUs.Foreground = Brushes.Gray;
                    txtDireccionUs.Foreground = Brushes.Gray;
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
            txtNombreCompletoUs.IsReadOnly = false;
            txtCorreoUs.IsReadOnly = false;
            txtTelefonoUs.IsReadOnly = false;
            txtDireccionUs.IsReadOnly = false;

            txtNombreCompletoUs.Foreground = Brushes.Black;
            txtCorreoUs.Foreground = Brushes.Black;
            txtTelefonoUs.Foreground = Brushes.Black;
            txtDireccionUs.Foreground = Brushes.Black;

            btnEditarPerfil.Visibility = Visibility.Collapsed;
            btnGuardarCambios.Visibility = Visibility.Visible;
        }

        private void GuardarCambiosBtn_Click(object sender, RoutedEventArgs e)
        {
            // Separar el nombre completo en nombre y apellido
            var nombreCompleto = txtNombreCompletoUs.Text.Split(' ');
            if (nombreCompleto.Length >= 2)
            {
                _detalleUsuarioVistaModelo.UsuarioAutenticado.Nombre = nombreCompleto[0];
                _detalleUsuarioVistaModelo.UsuarioAutenticado.Apellido = string.Join(" ", nombreCompleto.Skip(1));
            }
            else
            {
                _detalleUsuarioVistaModelo.UsuarioAutenticado.Nombre = nombreCompleto[0];
                _detalleUsuarioVistaModelo.UsuarioAutenticado.Apellido = string.Empty;
            }

            // Ejecutar el comando GuardarCommand
            _detalleUsuarioVistaModelo.GuardarCommand.Execute(null);

            // Volver a la vista de solo lectura
            txtNombreCompletoUs.IsReadOnly = true;
            txtCorreoUs.IsReadOnly = true;
            txtTelefonoUs.IsReadOnly = true;
            txtDireccionUs.IsReadOnly = true;

            txtNombreCompletoUs.Foreground = Brushes.Gray;
            txtCorreoUs.Foreground = Brushes.Gray;
            txtTelefonoUs.Foreground = Brushes.Gray;
            txtDireccionUs.Foreground = Brushes.Gray;

            btnEditarPerfil.Visibility = Visibility.Visible;
            btnGuardarCambios.Visibility = Visibility.Collapsed;
        }

        private void CerrarSesionBtn_Click(object sender, RoutedEventArgs e)
        {
            // Navegar a la página de ingreso
            NavigationService.Navigate(new Uri("/Vistas/Ingreso/Ingreso.xaml", UriKind.Relative));
        }
    }
}
