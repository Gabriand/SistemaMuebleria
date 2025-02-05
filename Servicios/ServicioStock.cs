using MuebleriaPIS.Modelos;
using MySql.Data.MySqlClient;
using System;

namespace MuebleriaPIS.Servicios
{
    public class ServicioStock
    {
        private readonly string _connectionString = "Server=localhost;Port=3306;Database=muebleria_jpatinio;User Id=root;Password=root;SslMode=Required;";

        public void AgregarStock(ProductoStock stock)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                var command = new MySqlCommand("INSERT INTO stock_producto (Id_Producto, Nombre, Fecha_ingreso, Cantidad_disponible) VALUES (@IdProducto, @Nombre, @FechaIngreso, @CantidadDisponible)", connection);
                command.Parameters.AddWithValue("@IdProducto", stock.Id_Producto);
                command.Parameters.AddWithValue("@Nombre", stock.Nombre);
                command.Parameters.AddWithValue("@FechaIngreso", stock.FechaIngreso);
                command.Parameters.AddWithValue("@CantidadDisponible", stock.CantidadDisponible);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void ActualizarStock(int productoId, int nuevaCantidad)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                var command = new MySqlCommand("UPDATE stock_producto SET Cantidad_disponible = @NuevaCantidad WHERE Id_Producto = @ProductoId", connection);
                command.Parameters.AddWithValue("@NuevaCantidad", nuevaCantidad);
                command.Parameters.AddWithValue("@ProductoId", productoId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public ProductoStock ObtenerStockPorProducto(int productoId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                var command = new MySqlCommand("SELECT * FROM stock_producto WHERE Id_Producto = @ProductoId", connection);
                command.Parameters.AddWithValue("@ProductoId", productoId);

                connection.Open();
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new ProductoStock
                    {
                        Id_Producto = (int)reader["Id_Producto"],
                        Nombre = reader["Nombre"].ToString(),
                        FechaIngreso = (DateTime)reader["Fecha_ingreso"],
                        CantidadDisponible = (int)reader["Cantidad_disponible"]
                    };
                }
                return null;
            }
        }
    }
}
