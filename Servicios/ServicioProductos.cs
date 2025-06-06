using MuebleriaPIS.Modelos;
using System.Collections.Generic;

namespace MuebleriaPIS.Servicios
{
    internal class ServicioProductos
    {
        // Lista simulada de productos en memoria
        private readonly List<Producto> productos = new List<Producto>
        {
            new Producto
            {
                Id_Producto = 1,
                Nombre = "Silla Moderna",
                Descripcion = "Silla de madera con diseño moderno",
                Precio = 1200.50m,
                Stock = 10,
                Ultima_Actualizacion = System.DateTime.Now,
                Categoria = new Categoria { Id_Categoria = 1, Nombre_Categoria = "Sillas" }
            },
            new Producto
            {
                Id_Producto = 2,
                Nombre = "Mesa Clásica",
                Descripcion = "Mesa de comedor para 6 personas",
                Precio = 3500.00m,
                Stock = 5,
                Ultima_Actualizacion = System.DateTime.Now,
                Categoria = new Categoria { Id_Categoria = 2, Nombre_Categoria = "Mesas" }
            }
            // Puedes agregar más productos aquí
        };

        public List<Producto> ObtenerProductos()
        {
            return new List<Producto>(productos);
        }

        public Producto ObtenerProductoPorId(int id)
        {
            return productos.Find(p => p.Id_Producto == id);
        }

        public Producto ObtenerDetallesProducto(int idProducto)
        {
            return productos.Find(p => p.Id_Producto == idProducto);
        }
    }
}
