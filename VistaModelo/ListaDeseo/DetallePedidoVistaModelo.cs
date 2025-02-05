using System;
using System.Collections.Generic;
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
    public class DetallePedidoVistaModelo : INotifyPropertyChanged
    {
        private static Dictionary<string, ObservableCollection<Producto>> _listasDeseosPorUsuario = new Dictionary<string, ObservableCollection<Producto>>();
        private string _usuarioActual;
        private const string connectionString = "Server=127.0.0.1;Port=3306;Database=muebleria_jpatinio;Uid=root;Pwd=root;";

        public ObservableCollection<Producto> ListaDeseos
        {
            get
            {
                if (_usuarioActual != null && _listasDeseosPorUsuario.ContainsKey(_usuarioActual))
                {
                    return _listasDeseosPorUsuario[_usuarioActual];
                }
                return new ObservableCollection<Producto>();
            }
        }

        public ICommand EliminarProductoCommand { get; }
        public ICommand GenerarPedidoCommand { get; }

        public DetallePedidoVistaModelo(string usuarioActual)
        {
            _usuarioActual = usuarioActual;
            if (!_listasDeseosPorUsuario.ContainsKey(_usuarioActual))
            {
                _listasDeseosPorUsuario[_usuarioActual] = new ObservableCollection<Producto>();
            }

            EliminarProductoCommand = new RelayCommand<Producto>(EliminarProducto);
            GenerarPedidoCommand = new RelayCommand(GenerarPedido);
        }

        public void AgregarProductoALista(Producto producto)
        {
            if (producto != null && !_listasDeseosPorUsuario[_usuarioActual].Contains(producto))
            {
                _listasDeseosPorUsuario[_usuarioActual].Add(producto);
                OnPropertyChanged(nameof(ListaDeseos));
            }
        }

        private void EliminarProducto(Producto producto)
        {
            if (producto != null && _listasDeseosPorUsuario[_usuarioActual].Contains(producto))
            {
                _listasDeseosPorUsuario[_usuarioActual].Remove(producto);
                OnPropertyChanged(nameof(ListaDeseos));
            }
        }

        private void GenerarPedido()
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Obtener el Id_Cliente a partir del nombre de usuario o correo electrónico
                    string getIdClienteQuery = "SELECT Id_Cliente FROM cliente WHERE Correo_Electronico = @UsuarioActual"; // O reemplazar Correo_Electronico por el campo adecuado
                    var getIdClienteCommand = new MySqlCommand(getIdClienteQuery, connection);
                    getIdClienteCommand.Parameters.AddWithValue("@UsuarioActual", _usuarioActual);

                    object result = getIdClienteCommand.ExecuteScalar();
                    if (result == null)
                    {
                        MessageBox.Show("No se encontró un cliente con ese nombre de usuario.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    int idCliente = Convert.ToInt32(result);

                    // Insertar el pedido en la tabla pedidos
                    string insertPedidoQuery = "INSERT INTO pedidos (Id_Cliente, Fecha_creacion, Total_pedido) VALUES (@IdCliente, @FechaCreacion, @TotalPedido)";
                    var insertPedidoCommand = new MySqlCommand(insertPedidoQuery, connection);
                    insertPedidoCommand.Parameters.AddWithValue("@IdCliente", idCliente);
                    insertPedidoCommand.Parameters.AddWithValue("@FechaCreacion", DateTime.Now);
                    insertPedidoCommand.Parameters.AddWithValue("@TotalPedido", ListaDeseos.Sum(p => p.Precio));

                    insertPedidoCommand.ExecuteNonQuery();

                    // Obtener el Id del pedido recién insertado
                    long idPedido = insertPedidoCommand.LastInsertedId;

                    // Insertar los productos del pedido en la tabla detalle_pedido
                    foreach (var producto in ListaDeseos)
                    {
                        string insertDetalleQuery = "INSERT INTO detalle_pedido (Id_Pedido, Id_Producto, Cantidad, Precio) VALUES (@IdPedido, @IdProducto, @Cantidad, @Precio)";
                        var insertDetalleCommand = new MySqlCommand(insertDetalleQuery, connection);
                        insertDetalleCommand.Parameters.AddWithValue("@IdPedido", idPedido);
                        insertDetalleCommand.Parameters.AddWithValue("@IdProducto", producto.Id_Producto);
                        insertDetalleCommand.Parameters.AddWithValue("@Cantidad", 1); // Asumiendo cantidad 1 por producto
                        insertDetalleCommand.Parameters.AddWithValue("@Precio", producto.Precio);

                        insertDetalleCommand.ExecuteNonQuery();
                    }

                    MessageBox.Show("Pedido generado exitosamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el pedido: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}