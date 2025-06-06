using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using MuebleriaPIS.Modelos;
using MuebleriaPIS.Utilidades;
using MySql.Data.MySqlClient;

namespace MuebleriaPIS.VistaModelo
{
    public class SeleccionarProductosVistaModelo : INotifyPropertyChanged
    {
        private const string connectionString = "Server=127.0.0.1;Port=3306;Database=muebleria_jpatinio;Uid=root;Pwd=root;";
        public ObservableCollection<Producto> Productos { get; set; }
        public ICommand AgregarProductoCommand { get; }

        public SeleccionarProductosVistaModelo()
        {
            Productos = new ObservableCollection<Producto>();
            AgregarProductoCommand = new RelayCommand<Producto>(AgregarProducto);
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

        private void AgregarProducto(Producto producto)
        {
            if (producto == null) return;

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO lista_deseo (Id_Cliente, nombre, Id_Producto, nombre_del_producto, precio, Fecha_agregado) VALUES (@IdCliente, @Nombre, @IdProducto, @NombreProducto, @Precio, @FechaAgregado)";
                    var command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdCliente", ObtenerIdClienteActual()); // Reemplaza con el Id del cliente actual
                    command.Parameters.AddWithValue("@Nombre", ObtenerNombreClienteActual()); // Reemplaza con el nombre del cliente actual
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

        private int ObtenerIdClienteActual()
        {
            // Implementa la lógica para obtener el Id del cliente actual
            return 1; // Ejemplo: reemplaza con el Id real del cliente
        }

        private string ObtenerNombreClienteActual()
        {
            // Implementa la lógica para obtener el nombre del cliente actual
            return "NombreCliente"; // Ejemplo: reemplaza con el nombre real del cliente
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
