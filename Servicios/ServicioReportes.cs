using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace MuebleriaPIS.Servicios
{
    internal class ServicioReportes
    {
        private const string connectionString = "Server=127.0.0.1;Port=3306;Database=muebleria_jpatinio;Uid=root;Pwd=root;";

        public int ObtenerCantidadClientes()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM cliente";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la cantidad de clientes: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
        }

        public int ObtenerCantidadProductos()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM producto";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la cantidad de productos: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
        }

        public int ObtenerCantidadStock()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT SUM(Stock) FROM producto";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        var result = command.ExecuteScalar();
                        return result != DBNull.Value ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la cantidad de stock: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
        }
    }
}
