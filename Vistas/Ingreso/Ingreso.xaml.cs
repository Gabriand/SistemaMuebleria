using System;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;
using MuebleriaPIS.VistaModelo;
using MuebleriaPIS.Vistas.Catalogo;
using MuebleriaPIS.Vistas.Ingreso;  // Agregar la referencia al espacio de nombres Catalogo

namespace MuebleriaPIS.Vistas
{
    public partial class IngresoPage : Page
    {
        private BarraNavegacionVistaModelo _viewModel;

        // Cadena de conexión a la base de datos
        private const string connectionString = "Server=127.0.0.1;Port=3306;Database=muebleria_jpatinio;Uid=root;Pwd=bryan2004;";

        public IngresoPage()
        {
            InitializeComponent();

            // Barra de Navegación
            _viewModel = new BarraNavegacionVistaModelo
            {
                MostrarControlesUsuario = false, // Oculta los controles de usuario en la página de ingreso
            };
            barraNavegacion.DataContext = _viewModel;

            // Configurar el DataContext para IngresoVistaModelo
            DataContext = new IngresoVistaModelo();
        }

        private void IngresoBtn_Click(object sender, RoutedEventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contrasena = txtContrasena.Password;

            // Validar acceso para administrador o trabajador con credenciales fijas
            if ((usuario == "admin" || usuario == "trabajador") && contrasena == "1234")
            {
                // Lógica para administrador o trabajador
                MessageBox.Show("Bienvenido, " + usuario, "Acceso Exitoso", MessageBoxButton.OK, MessageBoxImage.Information);

                // Redirigir a la página de catálogo para administrador o trabajador
                this.NavigationService.Navigate(new CatalogoProductos());
            }
            else
            {
                // Verificar usuario y contraseña en la base de datos para clientes
                bool usuarioValido = ValidarCliente(usuario, contrasena);
                if (usuarioValido)
                {
                    MessageBox.Show("Bienvenido, " + usuario, "Acceso Exitoso", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Redirigir a la página de catálogo para clientes
                    this.NavigationService.Navigate(new CatalogoProductos());
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private bool ValidarCliente(string usuario, string contrasena)
        {
            bool esValido = false;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM usuario WHERE NombreUsuario = @Usuario AND Contrasena = @Contrasena";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Usuario", usuario);
                        cmd.Parameters.AddWithValue("@Contrasena", contrasena);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count > 0)
                        {
                            esValido = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al validar el cliente: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return esValido;
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
