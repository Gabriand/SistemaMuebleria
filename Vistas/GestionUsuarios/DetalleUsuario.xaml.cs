using System;
using System.Windows;
using System.Windows.Controls;

namespace MuebleriaPIS.Vistas.GestionUsuarios
{
    public partial class DetalleUsuario : Page
    {
        // Cadena de conexión a la base de datos (ajustada con la que proporcionaste)
        private const string connectionString = "Server=127.0.0.1;Port=3306;Database=muebleria_jpatinio;Uid=root;Pwd=root;";

        public DetalleUsuario()
        {
            InitializeComponent();
        }

        // Método que se ejecuta al hacer clic en el botón "Editar perfil"
        private void EditarPerfilBtn_Click(object sender, RoutedEventArgs e)
        {
            // Hacer visibles los campos de texto para editar
            txtNombresUs.IsEnabled = true;
            txtApellidosUs.IsEnabled = true;
            txtCorreoUs.IsEnabled = true;
            txtTelefonoUs.IsEnabled = true;
            txtDireccionUs.IsEnabled = true;

            // Hacer visible el botón "Guardar cambios" y ocultar el botón "Editar perfil"
            btnGuardarCambios.Visibility = Visibility.Visible;
            btnEditarPerfil.Visibility = Visibility.Collapsed;
        }

        // Método que se ejecuta al hacer clic en el botón "Guardar cambios"
        private void GuardarCambiosBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Validar que el campo de teléfono anterior y el teléfono nuevo no estén vacíos
                if (string.IsNullOrEmpty(txtTelefonoAnterior.Text) || string.IsNullOrEmpty(txtTelefonoUs.Text))
                {
                    MessageBox.Show("Por favor, ingrese tanto el teléfono anterior como el nuevo.", "Campos incompletos", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Obtener el teléfono anterior y el nuevo teléfono
                string telefonoAnterior = txtTelefonoAnterior.Text.Trim();
                string nuevoTelefono = txtTelefonoUs.Text.Trim();

                // Usar la cadena de conexión proporcionada
                using (var connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
                {
                    // Verificar la conexión
                    connection.Open();

                    // Consultar el Id_Cliente usando el teléfono anterior
                    string query = "SELECT Id_Cliente FROM Cliente WHERE Telefono = @TelefonoAnterior";  // Cambié 'Clientes' a 'Cliente'
                    var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TelefonoAnterior", telefonoAnterior);

                    // Ejecutar la consulta
                    var result = command.ExecuteScalar();

                    // Si se encuentra un cliente con el teléfono anterior
                    if (result != null && result is int idCliente)
                    {
                        // Actualizar los datos del cliente
                        string updateQuery = "UPDATE Cliente SET Telefono = @NuevoTelefono, Nombres = @Nombres, Apellidos = @Apellidos, Correo_Electronico = @CorreoElectronico, Direccion = @Direccion WHERE Id_Cliente = @IdCliente";  // Cambié 'Correo' a 'Correo_Electronico'
                        var updateCommand = new MySql.Data.MySqlClient.MySqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@NuevoTelefono", nuevoTelefono);
                        updateCommand.Parameters.AddWithValue("@Nombres", txtNombresUs.Text.Trim());
                        updateCommand.Parameters.AddWithValue("@Apellidos", txtApellidosUs.Text.Trim());
                        updateCommand.Parameters.AddWithValue("@CorreoElectronico", txtCorreoUs.Text.Trim());  // Cambié 'Correo' a 'Correo_Electronico'
                        updateCommand.Parameters.AddWithValue("@Direccion", txtDireccionUs.Text.Trim());
                        updateCommand.Parameters.AddWithValue("@IdCliente", idCliente);

                        // Ejecutar la actualización
                        int rowsAffected = updateCommand.ExecuteNonQuery();

                        // Mostrar mensaje de éxito
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Los datos del cliente se han actualizado correctamente.", "Actualización exitosa", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar los datos del cliente.", "Error de actualización", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontró un cliente con el teléfono anterior ingresado.", "Cliente no encontrado", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException sqlEx)
            {
                MessageBox.Show($"Error en la consulta de base de datos: {sqlEx.Message}", "Error de base de datos", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al intentar guardar los cambios: {ex.Message}", "Error inesperado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CerrarSesionBtn_Click(object sender, RoutedEventArgs e)
        {
            // Navegar a la página de ingreso
            NavigationService.Navigate(new Uri("/Vistas/Ingreso/Ingreso.xaml", UriKind.Relative));
        }
    }
}
