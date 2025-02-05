using System;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;
using MuebleriaPIS.VistaModelo;
using MuebleriaPIS.Vistas.Catalogo;
using MuebleriaPIS.Vistas.Ingreso;
using MuebleriaPIS.Vistas.GestionUsuarios;
using MuebleriaPIS.Utilidades;
using MuebleriaPIS.Modelos;

namespace MuebleriaPIS.Vistas
{
    public partial class IngresoPage : Page
    {
        private BarraNavegacionVistaModelo _viewModel;

        private const string connectionString = "Server=127.0.0.1;Port=3306;Database=muebleria_jpatinio;Uid=root;Pwd=root;";

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

            if (ValidarPersonal(usuario, contrasena))
            {
                MessageBox.Show("Bienvenido, " + usuario, "Acceso Exitoso", MessageBoxButton.OK, MessageBoxImage.Information);
                if (usuario == "admin" || usuario == "Admin")
                {

                    this.NavigationService.Navigate(new InicioAdmin());
                }
                else
                {
                    this.NavigationService.Navigate(new InicioTrabajador());
                }
            }
            else
            {
                int idCliente = ValidarCliente(usuario, contrasena);
                if (idCliente > 0)
                {
                    Sesion.IdCliente = idCliente; // Almacenar el idCliente en la sesión
                    MessageBox.Show("Bienvenido, " + usuario, "Acceso Exitoso", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.NavigationService.Navigate(new CatalogoProductos()); // Navegar al catálogo de productos
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private int ValidarCliente(string usuario, string contrasena)
        {
            int idCliente = -1;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Id_Cliente FROM cliente WHERE LOWER(Usuario) = LOWER(@Usuario) AND Contrasena = @Contrasena";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Usuario", usuario);
                        cmd.Parameters.AddWithValue("@Contrasena", contrasena);

                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            idCliente = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al validar el cliente: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return idCliente;
        }

        private bool ValidarPersonal(string usuario, string contrasena)
        {
            bool esValido = false;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM personal WHERE LOWER(Usuario) = LOWER(@Usuario) AND Contrasena = @Contrasena";

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
                MessageBox.Show($"Error al validar el personal: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

