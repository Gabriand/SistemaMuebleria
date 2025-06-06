using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MuebleriaPIS.Vistas.GestionUsuarios
{
    public partial class DetalleUsuario : Page
    {
        private int _idCliente;

        // Simulación de datos de usuario en memoria
        private static UsuarioSimulado usuarioSimulado = new UsuarioSimulado
        {
            Nombres = "Juan",
            Apellidos = "Pérez",
            Correo = "juan@correo.com",
            Telefono = "123456789",
            Direccion = "Calle Falsa 123"
        };

        public DetalleUsuario(int idCliente)
        {
            InitializeComponent();
            _idCliente = idCliente;
            CargarDatosUsuario();
        }

        private void CargarDatosUsuario()
        {
            try
            {
                txtNombresUs.Text = usuarioSimulado.Nombres;
                txtApellidosUs.Text = usuarioSimulado.Apellidos;
                txtCorreoUs.Text = usuarioSimulado.Correo;
                txtTelefonoUs.Text = usuarioSimulado.Telefono;
                txtDireccionUs.Text = usuarioSimulado.Direccion;

                txtNombresUs.IsEnabled = false;
                txtApellidosUs.IsEnabled = false;
                txtCorreoUs.IsEnabled = false;
                txtTelefonoUs.IsEnabled = false;
                txtDireccionUs.IsEnabled = false;

                txtNombresUs.Background = new SolidColorBrush(Colors.LightGray);
                txtApellidosUs.Background = new SolidColorBrush(Colors.LightGray);
                txtCorreoUs.Background = new SolidColorBrush(Colors.LightGray);
                txtTelefonoUs.Background = new SolidColorBrush(Colors.LightGray);
                txtDireccionUs.Background = new SolidColorBrush(Colors.LightGray);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del usuario: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EditarPerfilBtn_Click(object sender, RoutedEventArgs e)
        {
            txtNombresUs.IsEnabled = true;
            txtApellidosUs.IsEnabled = true;
            txtCorreoUs.IsEnabled = true;
            txtTelefonoUs.IsEnabled = true;
            txtDireccionUs.IsEnabled = true;

            txtNombresUs.Background = new SolidColorBrush(Colors.White);
            txtApellidosUs.Background = new SolidColorBrush(Colors.White);
            txtCorreoUs.Background = new SolidColorBrush(Colors.White);
            txtTelefonoUs.Background = new SolidColorBrush(Colors.White);
            txtDireccionUs.Background = new SolidColorBrush(Colors.White);

            btnGuardarCambios.Visibility = Visibility.Visible;
            btnEditarPerfil.Visibility = Visibility.Collapsed;
        }

        private void GuardarCambiosBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombresUs.Text) ||
                string.IsNullOrWhiteSpace(txtApellidosUs.Text) ||
                string.IsNullOrWhiteSpace(txtCorreoUs.Text) ||
                string.IsNullOrWhiteSpace(txtTelefonoUs.Text) ||
                string.IsNullOrWhiteSpace(txtDireccionUs.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos incompletos", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!EsCorreoValido(txtCorreoUs.Text))
            {
                MessageBox.Show("El formato del correo electrónico no es válido.", "Correo no válido", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            usuarioSimulado.Nombres = txtNombresUs.Text.Trim();
            usuarioSimulado.Apellidos = txtApellidosUs.Text.Trim();
            usuarioSimulado.Correo = txtCorreoUs.Text.Trim();
            usuarioSimulado.Telefono = txtTelefonoUs.Text.Trim();
            usuarioSimulado.Direccion = txtDireccionUs.Text.Trim();

            MessageBox.Show("Los datos del cliente se han actualizado correctamente (simulado).", "Actualización exitosa", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private bool EsCorreoValido(string correo)
        {
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(correo, patron);
        }

        private void CerrarSesionBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Vistas/Ingreso/Ingreso.xaml", UriKind.Relative));
        }

        private class UsuarioSimulado
        {
            public string Nombres { get; set; }
            public string Apellidos { get; set; }
            public string Correo { get; set; }
            public string Telefono { get; set; }
            public string Direccion { get; set; }
        }
    }
}
