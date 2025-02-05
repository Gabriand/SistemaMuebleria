using System;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace MuebleriaPIS.Vistas.Ingreso
{
    public partial class RegistroCliente : Page
    {
        // Conexión a la base de datos
        private const string connectionString = "Server=127.0.0.1;Port=3306;Database=muebleria_jpatinio;Uid=root;Pwd=root;";

        public RegistroCliente()
        {
            InitializeComponent();
        }

        private void btnRegistrarse_Click(object sender, RoutedEventArgs e)
        {
            // Obtener los valores de los campos
            string nombres = txtNombre.Text;
            string apellidos = txtApellido.Text;
            string usuario = txtUsuario.Text;
            string correoElectronico = txtCorreo.Text;
            string telefono = txtTelefono.Text;
            string direccion = txtDireccion.Text;
            string contrasena = txtContrasena.Password;

            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(nombres) || string.IsNullOrWhiteSpace(apellidos) ||
                string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(correoElectronico) ||
                string.IsNullOrWhiteSpace(telefono) || string.IsNullOrWhiteSpace(direccion) ||
                string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Iniciar una transacción para asegurar la inserción
                    using (MySqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Inserción en la tabla de cliente
                            string queryCliente = "INSERT INTO cliente (Usuario, Contrasena, Nombres, Apellidos, Direccion, Telefono, Correo_Electronico, Fecha_registro) " +
                                                  "VALUES (@Usuario, @Contrasena, @Nombres, @Apellidos, @Direccion, @Telefono, @CorreoElectronico, @FechaRegistro);";
                            using (MySqlCommand cmdCliente = new MySqlCommand(queryCliente, connection, transaction))
                            {
                                cmdCliente.Parameters.AddWithValue("@Usuario", usuario);
                                cmdCliente.Parameters.AddWithValue("@Contrasena", contrasena); // Hash de la contraseña si es necesario
                                cmdCliente.Parameters.AddWithValue("@Nombres", nombres);
                                cmdCliente.Parameters.AddWithValue("@Apellidos", apellidos);
                                cmdCliente.Parameters.AddWithValue("@Direccion", direccion);
                                cmdCliente.Parameters.AddWithValue("@Telefono", telefono);
                                cmdCliente.Parameters.AddWithValue("@CorreoElectronico", correoElectronico);
                                cmdCliente.Parameters.AddWithValue("@FechaRegistro", DateTime.Now);

                                // Ejecutar la inserción
                                cmdCliente.ExecuteNonQuery();
                            }

                            // Confirmar la transacción
                            transaction.Commit();
                            MessageBox.Show("Registro exitoso", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

                            // Limpiar los campos después del registro
                            txtNombre.Clear();
                            txtApellido.Clear();
                            txtUsuario.Clear();
                            txtCorreo.Clear();
                            txtTelefono.Clear();
                            txtDireccion.Clear();
                            txtContrasena.Clear();
                        }
                        catch (Exception ex)
                        {
                            // Revertir la transacción en caso de error
                            transaction.Rollback();
                            MessageBox.Show($"Error al registrar el cliente: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con la base de datos: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new IngresoPage());
        }
    }
}
