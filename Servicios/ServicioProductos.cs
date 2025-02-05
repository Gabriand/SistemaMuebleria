using MuebleriaPIS.Modelos;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace MuebleriaPIS.Servicios
{
    internal class ServicioProductos
    {
        private const string connectionString = "Server=127.0.0.1;Port=3306;Database=muebleria_jpatinio;Uid=root;Pwd=root;";

        public List<Producto> ObtenerProductos()
        {
            var productos = new List<Producto>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT 
                        p.Id_Producto, 
                        p.Nombre, 
                        p.Descripcion, 
                        p.Precio, 
                        p.Stock, 
                        p.Ultima_Actualizacion, 
                        c.Id_Categoria, 
                        c.Nombre_Categoria
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
                        var producto = new Producto
                        {
                            Id_Producto = reader.GetInt32("Id_Producto"),
                            Nombre = reader.GetString("Nombre"),
                            Descripcion = reader.IsDBNull(reader.GetOrdinal("Descripcion")) ? string.Empty : reader.GetString("Descripcion"),
                            Precio = reader.GetDecimal("Precio"),
                            Stock = reader.GetInt32("Stock"),
                            Ultima_Actualizacion = reader.GetDateTime("Ultima_Actualizacion"),
                            Categoria = new Categoria
                            {
                                Id_Categoria = reader.GetInt32("Id_Categoria"),
                                Nombre_Categoria = reader.GetString("Nombre_Categoria")
                            }
                        };

                        productos.Add(producto);
                    }
                }
            }

            return productos;
        }

        public Producto ObtenerProductoPorId(int id)
        {
            Producto producto = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT 
                        p.Id_Producto, 
                        p.Nombre, 
                        p.Descripcion, 
                        p.Precio, 
                        p.Stock, 
                        p.Ultima_Actualizacion, 
                        c.Id_Categoria, 
                        c.Nombre_Categoria
                    FROM 
                        producto p
                    INNER JOIN 
                        categorias c 
                    ON 
                        p.Id_Categoria = c.Id_Categoria
                    WHERE 
                        p.Id_Producto = @IdProducto";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdProducto", id);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            producto = new Producto
                            {
                                Id_Producto = reader.GetInt32("Id_Producto"),
                                Nombre = reader.GetString("Nombre"),
                                Descripcion = reader.IsDBNull(reader.GetOrdinal("Descripcion")) ? string.Empty : reader.GetString("Descripcion"),
                                Precio = reader.GetDecimal("Precio"),
                                Stock = reader.GetInt32("Stock"),
                                Ultima_Actualizacion = reader.GetDateTime("Ultima_Actualizacion"),
                                Categoria = new Categoria
                                {
                                    Id_Categoria = reader.GetInt32("Id_Categoria"),
                                    Nombre_Categoria = reader.GetString("Nombre_Categoria")
                                }
                            };
                        }
                    }
                }
            }

            return producto;
        }

        public Producto ObtenerDetallesProducto(int idProducto)
        {
            Producto detallesProducto = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT 
                        p.Id_Producto, 
                        p.Nombre, 
                        p.Descripcion, 
                        p.Precio, 
                        p.Stock, 
                        p.Ultima_Actualizacion, 
                        c.Id_Categoria, 
                        c.Nombre_Categoria
                    FROM 
                        producto p
                    INNER JOIN 
                        categorias c 
                    ON 
                        p.Id_Categoria = c.Id_Categoria
                    WHERE 
                        p.Id_Producto = @IdProducto";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdProducto", idProducto);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            detallesProducto = new Producto
                            {
                                Id_Producto = reader.GetInt32("Id_Producto"),
                                Nombre = reader.GetString("Nombre"),
                                Descripcion = reader.IsDBNull(reader.GetOrdinal("Descripcion")) ? string.Empty : reader.GetString("Descripcion"),
                                Precio = reader.GetDecimal("Precio"),
                                Stock = reader.GetInt32("Stock"),
                                Ultima_Actualizacion = reader.GetDateTime("Ultima_Actualizacion"),
                                Categoria = new Categoria
                                {
                                    Id_Categoria = reader.GetInt32("Id_Categoria"),
                                    Nombre_Categoria = reader.GetString("Nombre_Categoria")
                                }
                            };
                        }
                    }
                }
            }

            return detallesProducto;
        }
    }
}
