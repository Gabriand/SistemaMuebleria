using MuebleriaPIS.Modelos;
using MuebleriaPIS.Servicios;
using MuebleriaPIS.Utilidades;
using System.Windows;
using System.Windows.Controls;

namespace MuebleriaPIS.Vistas.Ingreso
{
    public partial class RegistroCliente : Page
    {
        private ServicioAutenticacion _servicioAutenticacion;

        public RegistroCliente()
        {
            InitializeComponent();
            _servicioAutenticacion = new ServicioAutenticacion();
        }

        private void btnRegistrarse_Click(object sender, RoutedEventArgs e)
        {
            // Validar los datos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtContrasena.Password))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            if (!Validador.EsCorreoValido(txtCorreo.Text))
            {
                MessageBox.Show("El correo no es válido.");
                return;
            }

            if (_servicioAutenticacion.ExisteUsuario(txtUsuario.Text, txtCorreo.Text))
            {
                MessageBox.Show("El usuario o correo ya está registrado.");
                return;
            }

            // Crear el nuevo usuario
            var nuevoUsuario = new Usuario
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                NomUsuario = txtUsuario.Text,
                Correo = txtCorreo.Text,
                Contrasena = txtContrasena.Password,
                Direccion = txtDireccion.Text,
                Telefono = int.TryParse(txtTelefono.Text, out int telefono) ? (int?)telefono : null,
                Rol = "Cliente"
            };

            // Guardar el nuevo usuario (aquí puedes agregar la lógica para guardar en la base de datos)
            _servicioAutenticacion.RegistrarUsuario(nuevoUsuario);

            MessageBox.Show("Registro exitoso.");
            this.NavigationService.Navigate(new IngresoPage());
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new IngresoPage());
        }
    }
}
