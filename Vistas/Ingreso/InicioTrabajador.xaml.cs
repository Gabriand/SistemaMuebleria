using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using MuebleriaPIS.Vistas.Inventario;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using MuebleriaPIS.Vistas.Reportes;

namespace MuebleriaPIS.Vistas
{
    public partial class InicioTrabajador : Page
    {
        private const string connectionString = "Server=127.0.0.1;Port=3306;Database=muebleria_jpatinio;Uid=root;Pwd=root;";

        public InicioTrabajador()
        {
            InitializeComponent();
            CargarDatosInventario();
            CargarCantidadClientes();
            CargarCantidadProductos();
        }

        private void GenerarReporte_Click(object sender, RoutedEventArgs e)
        {
            ReporteInventario reporteInventario = new ReporteInventario();
            NavigationService.Navigate(reporteInventario);
        }

        private void CargarDatosInventario()
        {
            try
            {
                var datosInventario = new List<ProductoInventario>();

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT 
                            p.Id_Producto, 
                            p.Nombre, 
                            p.Precio, 
                            c.Nombre_Categoria AS Categoria, 
                            p.Ultima_Actualizacion, 
                            p.Stock AS Cantidad_disponible
                        FROM 
                            producto p
                        INNER JOIN 
                            categorias c 
                        ON 
                            p.Id_Categoria = c.Id_Categoria";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            datosInventario.Add(new ProductoInventario
                            {
                                IdProducto = reader.IsDBNull(reader.GetOrdinal("Id_Producto")) ? 0 : reader.GetInt32("Id_Producto"),
                                Nombre = reader.IsDBNull(reader.GetOrdinal("Nombre")) ? "Desconocido" : reader.GetString("Nombre"),
                                Precio = reader.IsDBNull(reader.GetOrdinal("Precio")) ? 0.0m : reader.GetDecimal("Precio"),
                                Categoria = reader.IsDBNull(reader.GetOrdinal("Categoria")) ? "Desconocida" : reader.GetString("Categoria"),
                                FechaIngreso = reader.IsDBNull(reader.GetOrdinal("Ultima_Actualizacion")) ? DateTime.MinValue : reader.GetDateTime("Ultima_Actualizacion"),
                                CantidadDisponible = reader.IsDBNull(reader.GetOrdinal("Cantidad_disponible")) ? 0 : reader.GetInt32("Cantidad_disponible")
                            });
                        }
                    }
                }

                vgInventario.ItemsSource = datosInventario;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del inventario: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CargarCantidadClientes()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM cliente";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        ClientCount = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la cantidad de clientes: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CargarCantidadProductos()
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
                        ProductCount = result != DBNull.Value ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la cantidad de productos: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public int ClientCount { get; set; } = 0; // Inicializar con 0
        public int OrderCount { get; set; } = 0; // Ejemplo de datos con 0
        public int ProductCount { get; set; } = 0; // Inicializar con 0
    }

    public class ProductoInventario
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Categoria { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int CantidadDisponible { get; set; }
    }
}
