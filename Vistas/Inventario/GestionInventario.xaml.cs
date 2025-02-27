﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MuebleriaPIS.Vistas.Inventario
{
    public partial class GestionInventario : Page
    {
        private const string connectionString = "Server=127.0.0.1;Port=3306;Database=muebleria_jpatinio;Uid=root;Pwd=root;";

        public GestionInventario()
        {
            InitializeComponent();
            CargarDatosInventario();
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

                dgInventario.ItemsSource = datosInventario;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del inventario: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AgregarOActualizarProducto_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarEntradas()) return;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Verificar si el producto existe
                    string verificarProductoQuery = "SELECT COUNT(*) FROM producto WHERE Id_Producto = @IdProducto";
                    using (MySqlCommand verificarCommand = new MySqlCommand(verificarProductoQuery, connection))
                    {
                        verificarCommand.Parameters.AddWithValue("@IdProducto", txtIdProducto.Text);
                        int count = Convert.ToInt32(verificarCommand.ExecuteScalar());

                        if (count == 0)
                        {
                            // Si el producto no existe, se agrega
                            AgregarProducto(connection);
                        }
                        else
                        {
                            // Si el producto existe, se actualiza
                            ActualizarProducto(connection);
                        }
                    }
                }

                MessageBox.Show("Operación realizada correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                CargarDatosInventario(); // Refrescar la lista de inventario
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la operación: {ex.Message}. Por favor, intente nuevamente.",
                                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AgregarProducto(MySqlConnection connection)
        {
            string queryProducto = @"
        INSERT INTO producto (Id_Producto, Nombre, Precio, Id_Categoria, Stock, Ultima_Actualizacion)
        VALUES (@IdProducto, @Nombre, @Precio, @IdCategoria, @Stock, @UltimaActualizacion)";

            using (MySqlCommand commandProducto = new MySqlCommand(queryProducto, connection))
            {
                AgregarParametrosComunes(commandProducto);
                commandProducto.ExecuteNonQuery();
            }
        }

        private void ActualizarProducto(MySqlConnection connection)
        {
            string queryProducto = @"
                UPDATE producto
                SET Nombre = @Nombre, Precio = @Precio, Id_Categoria = @IdCategoria, Stock = @Stock, Ultima_Actualizacion = @UltimaActualizacion
                WHERE Id_Producto = @IdProducto";

            using (MySqlCommand commandProducto = new MySqlCommand(queryProducto, connection))
            {
                AgregarParametrosComunes(commandProducto);
                commandProducto.ExecuteNonQuery();
            }
        }

        private void AgregarParametrosComunes(MySqlCommand command)
        {
            command.Parameters.AddWithValue("@IdProducto", txtIdProducto.Text);
            command.Parameters.AddWithValue("@Nombre", txtNombreProducto.Text);
            command.Parameters.AddWithValue("@Precio", decimal.Parse(txtPrecioProducto.Text));
            command.Parameters.AddWithValue("@Stock", int.Parse(txtStockProducto.Text));
            command.Parameters.AddWithValue("@UltimaActualizacion", DateTime.Now);

            string categoria = txtCategoriaProducto.Text.Trim().ToLower();
            int idCategoria;

            switch (categoria)
            {
                case "mueble":
                    idCategoria = 1;
                    break;
                case "silla":
                    idCategoria = 2;
                    break;
                case "comedor":
                    idCategoria = 3;
                    break;
                default:
                    throw new Exception("Categoría no válida. Las categorías permitidas son: Mueble, Silla, Comedor.");
            }

            command.Parameters.AddWithValue("@IdCategoria", idCategoria);
        }

        private bool ValidarEntradas()
        {
            if (string.IsNullOrWhiteSpace(txtIdProducto.Text) ||
                string.IsNullOrWhiteSpace(txtNombreProducto.Text) ||
                string.IsNullOrWhiteSpace(txtPrecioProducto.Text) ||
                string.IsNullOrWhiteSpace(txtCategoriaProducto.Text) ||
                string.IsNullOrWhiteSpace(txtStockProducto.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!decimal.TryParse(txtPrecioProducto.Text, out _) || !int.TryParse(txtStockProducto.Text, out _))
            {
                MessageBox.Show("Por favor, ingresa valores numéricos válidos para el precio y la cantidad.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            var image = sender as Image;
            if (image != null)
            {
                image.Cursor = Cursors.Hand;
                image.Opacity = 0.7; // Cambia la opacidad para dar un efecto visual
            }
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            var image = sender as Image;
            if (image != null)
            {
                image.Cursor = Cursors.Arrow;
                image.Opacity = 1.0; // Restaura la opacidad original
            }
        }

        private void RegresarBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new InicioTrabajador());
        }
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
