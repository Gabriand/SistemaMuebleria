using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;
using System.Windows.Media;

namespace MuebleriaPIS.Vistas.GestionUsuarios
{
    public partial class DetalleUsuario : Page
    {
        private const string connectionString = "Server=127.0.0.1;Port=3306;Database=muebleria_jpatinio;Uid=root;Pwd=root;";
        private int _idCliente;

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
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT Nombres, Apellidos, Correo_Electronico, Telefono, Direccion FROM cliente WHERE Id_Cliente = @IdCliente";
                    var command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdCliente", _idCliente);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtNombresUs.Text = reader["Nombres"].ToString();
                            txtApellidosUs.Text = reader["Apellidos"].ToString();
                            txtCorreoUs.Text = reader["Correo_Electronico"].ToString();
                            txtTelefonoUs.Text = reader["Telefono"].ToString();
                            txtDireccionUs.Text = reader["Direccion"].ToString();
                        }
                    }
                }

                // Deshabilitar los campos de texto y cambiar el color de fondo a gris
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
            // Habilitar los campos de texto para editar y cambiar el color de fondo a blanco
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

            // Hacer visible el botón "Guardar cambios" y ocultar el botón "Editar perfil"
            btnGuardarCambios.Visibility = Visibility.Visible;
            btnEditarPerfil.Visibility = Visibility.Collapsed;
        }

        private void GuardarCambiosBtn_Click(object sender, RoutedEventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(txtNombresUs.Text) ||
                string.IsNullOrWhiteSpace(txtApellidosUs.Text) ||
                string.IsNullOrWhiteSpace(txtCorreoUs.Text) ||
                string.IsNullOrWhiteSpace(txtTelefonoUs.Text) ||
                string.IsNullOrWhiteSpace(txtDireccionUs.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos incompletos", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Validar el formato del correo electrónico
            if (!EsCorreoValido(txtCorreoUs.Text))
            {
                MessageBox.Show("El formato del correo electrónico no es válido.", "Correo no válido", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Actualizar los datos del cliente
                    string updateQuery = "UPDATE cliente SET Telefono = @NuevoTelefono, Nombres = @Nombres, Apellidos = @Apellidos, Correo_Electronico = @CorreoElectronico, Direccion = @Direccion WHERE Id_Cliente = @IdCliente";
                    var updateCommand = new MySqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@NuevoTelefono", txtTelefonoUs.Text.Trim());
                    updateCommand.Parameters.AddWithValue("@Nombres", txtNombresUs.Text.Trim());
                    updateCommand.Parameters.AddWithValue("@Apellidos", txtApellidosUs.Text.Trim());
                    updateCommand.Parameters.AddWithValue("@CorreoElectronico", txtCorreoUs.Text.Trim());
                    updateCommand.Parameters.AddWithValue("@Direccion", txtDireccionUs.Text.Trim());
                    updateCommand.Parameters.AddWithValue("@IdCliente", _idCliente);

                    int rowsAffected = updateCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Los datos del cliente se han actualizado correctamente.", "Actualización exitosa", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar los datos del cliente.", "Error de actualización", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (MySqlException sqlEx)
            {
                MessageBox.Show($"Error en la consulta de base de datos: {sqlEx.Message}", "Error de base de datos", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al intentar guardar los cambios: {ex.Message}", "Error inesperado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
    }
}
