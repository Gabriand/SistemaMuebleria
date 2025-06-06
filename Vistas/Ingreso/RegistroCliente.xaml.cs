using System;
using System.Windows;
using System.Windows.Controls;

namespace MuebleriaPIS.Vistas.Ingreso
{
    public partial class RegistroCliente : Page
    {
        // Simulación de clientes en memoria
        private static int _ultimoId = 1;

        public RegistroCliente()
        {
            InitializeComponent();
        }

        private void btnRegistrarse_Click(object sender, RoutedEventArgs e)
        {
            string nombres = txtNombre.Text;
            string apellidos = txtApellido.Text;
            string usuario = txtUsuario.Text;
            string correoElectronico = txtCorreo.Text;
            string telefono = txtTelefono.Text;
            string direccion = txtDireccion.Text;
            string contrasena = txtContrasena.Password;

            if (string.IsNullOrWhiteSpace(nombres) || string.IsNullOrWhiteSpace(apellidos) ||
                string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(correoElectronico) ||
                string.IsNullOrWhiteSpace(telefono) || string.IsNullOrWhiteSpace(direccion) ||
                string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Simulación de registro exitoso
            _ultimoId++;
            MessageBox.Show("Registro exitoso (simulado)", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

            txtNombre.Clear();
            txtApellido.Clear();
            txtUsuario.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtContrasena.Clear();
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new IngresoPage());
        }
    }
}
