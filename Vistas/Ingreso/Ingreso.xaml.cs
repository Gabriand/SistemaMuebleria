using System;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;
using MuebleriaPIS.VistaModelo;
using MuebleriaPIS.Vistas.Catalogo;
using MuebleriaPIS.Vistas.Ingreso; 

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

            if ((usuario == "Admin" || usuario == "admin" || usuario == "Trabajador" || usuario == "trabajador") && contrasena == "1234")
            {
                MessageBox.Show("Bienvenido, " + usuario, "Acceso Exitoso", MessageBoxButton.OK, MessageBoxImage.Information);

                this.NavigationService.Navigate(new InicioTrabajador());
            }
            else
            {
                bool usuarioValido = ValidarCliente(usuario, contrasena);
                if (usuarioValido)
                {
                    MessageBox.Show("Bienvenido, " + usuario, "Acceso Exitoso", MessageBoxButton.OK, MessageBoxImage.Information);
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
