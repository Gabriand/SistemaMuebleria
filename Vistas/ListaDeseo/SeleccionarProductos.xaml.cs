using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;
using MuebleriaPIS.Modelos;
using MuebleriaPIS.Vistas.Catalogo;

namespace MuebleriaPIS.Vistas.ListaDeseo
{
    public partial class SeleccionarProductos : Page
    {
        private const string connectionString = "Server=127.0.0.1;Port=3306;Database=muebleria_jpatinio;Uid=root;Pwd=root;";
        public ObservableCollection<Producto> Productos { get; set; }

        public SeleccionarProductos()
        {
            InitializeComponent();
            Productos = new ObservableCollection<Producto>();
            dataGridProductos.ItemsSource = Productos;
            CargarProductos();
        }

        private void CargarProductos()
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Id_Producto, Nombre, Descripcion, Precio, Id_Categoria, Stock, Ultima_Actualizacion FROM producto";
                    var command = new MySqlCommand(query, connection);
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Productos.Add(new Producto
                        {
                            Id_Producto = reader.GetInt32("Id_Producto"),
                            Nombre = reader.GetString("Nombre"),
                            Descripcion = reader.GetString("Descripcion"),
                            Precio = reader.GetDecimal("Precio"),
                            Stock = reader.GetInt32("Stock"),
                            Ultima_Actualizacion = reader.GetDateTime("Ultima_Actualizacion"),
                            Categoria = new Categoria { Id_Categoria = reader.GetInt32("Id_Categoria") }
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AgregarProducto_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridProductos.SelectedItem is Producto producto)
            {
                try
                {
                    using (var connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "INSERT INTO lista_deseo (Id_Cliente, nombre, Id_Producto, nombre_del_producto, precio, Fecha_agregado) VALUES (@IdCliente, @Nombre, @IdProducto, @NombreProducto, @Precio, @FechaAgregado)";
                        var command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@IdCliente", 1); // Reemplaza con el Id del cliente actual
                        command.Parameters.AddWithValue("@Nombre", "NombreCliente"); // Reemplaza con el nombre del cliente actual
                        command.Parameters.AddWithValue("@IdProducto", producto.Id_Producto);
                        command.Parameters.AddWithValue("@NombreProducto", producto.Nombre);
                        command.Parameters.AddWithValue("@Precio", producto.Precio);
                        command.Parameters.AddWithValue("@FechaAgregado", DateTime.Now);
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Producto agregado a la lista de deseos.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al agregar producto a la lista de deseos: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void RegresarCatalogo_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CatalogoProductos());
        }
    }
}

