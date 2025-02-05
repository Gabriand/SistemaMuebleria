using MySql.Data.MySqlClient;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MuebleriaPIS.Vistas.GestionUsuarios
{
    public partial class EliminarUsuario : Page
    {
        public EliminarUsuario()
        {
            InitializeComponent();
        }

        private void EliminarUsuario_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Server=127.0.0.1;Port=3306;Database=muebleria_jpatinio;Uid=root;Pwd=root;";
            int idUsuario;

            // Validar que el ID ingresado es un número
            if (!int.TryParse(txtIdUsuario.Text, out idUsuario))
            {
                lblEstado.Text = "Por favor, ingrese un ID de usuario válido.";
                lblEstado.Foreground = new SolidColorBrush(Colors.Red);
                return;
            }

            string queryVerificarUsuario = "SELECT COUNT(*) FROM usuario WHERE Id_Usuario = @IdUsuario;";
            string queryCliente = "DELETE FROM cliente WHERE Id_Usuario = @IdUsuario;";
            string queryUsuario = "DELETE FROM usuario WHERE Id_Usuario = @IdUsuario;";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Verificar si el usuario existe
                    using (MySqlCommand cmdVerificarUsuario = new MySqlCommand(queryVerificarUsuario, connection))
                    {
                        cmdVerificarUsuario.Parameters.AddWithValue("@IdUsuario", idUsuario);
                        int count = Convert.ToInt32(cmdVerificarUsuario.ExecuteScalar());

                        if (count == 0)
                        {
                            lblEstado.Text = "El usuario no existe.";
                            lblEstado.Foreground = new SolidColorBrush(Colors.Red);
                            return;
                        }
                    }

                    // Eliminar primero en la tabla cliente
                    using (MySqlCommand cmdCliente = new MySqlCommand(queryCliente, connection))
                    {
                        cmdCliente.Parameters.AddWithValue("@IdUsuario", idUsuario);
                        cmdCliente.ExecuteNonQuery();
                    }

                    // Eliminar luego en la tabla usuario
                    using (MySqlCommand cmdUsuario = new MySqlCommand(queryUsuario, connection))
                    {
                        cmdUsuario.Parameters.AddWithValue("@IdUsuario", idUsuario);
                        cmdUsuario.ExecuteNonQuery();
                    }

                    lblEstado.Text = "Usuario eliminado correctamente.";
                    lblEstado.Foreground = new SolidColorBrush(Colors.Green);
                }
            }
            catch (Exception ex)
            {
                lblEstado.Text = "Error al eliminar usuario: " + ex.Message;
                lblEstado.Foreground = new SolidColorBrush(Colors.Red);
            }
        }
    }
}
