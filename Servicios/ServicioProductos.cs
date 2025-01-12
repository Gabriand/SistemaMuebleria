using MuebleriaPIS.Modelos;
using System.Collections.Generic;

namespace MuebleriaPIS.Servicios
{
    internal class ServicioProductos
    {
        private List<Producto> _productos;

        public ServicioProductos()
        {
            // Inicializar la lista de productos
            var categoria1 = new Categoria { Id = 1, Nombre = "Muebles" };
            var categoria2 = new Categoria { Id = 2, Nombre = "Electrodomésticos" };

            _productos = new List<Producto>
            {
                new Producto { Id = 1, Nombre = "Mueble", Precio = 350.99m, Imagen = "/Recursos/Imagenes/Sofá/sofa.jpg", Descripcion = "Un cómodo sofá de tres plazas.", Categoria = categoria1 },
                new Producto { Id = 2, Nombre = "Comedor", Precio = 450.50m, Imagen = "/Recursos/Imagenes/MesaComedor/mesa.jpg", Descripcion = "Una elegante mesa de comedor para seis personas.", Categoria = categoria2 },
                new Producto { Id = 3, Nombre = "Silla", Precio = 120.00m, Imagen = "/Recursos/Imagenes/Sillas/silla.jpg", Descripcion = "Una silla ergonómica para oficina.", Categoria = categoria1 },
                new Producto { Id = 4, Nombre = "Mueble bonito", Precio = 350.99m, Imagen = "/Recursos/Imagenes/Sofá/sofa1.jpg", Descripcion = "Un bonito sofá de dos plazas.", Categoria = categoria1 },
                // Más productos de prueba
                new Producto { Id = 5, Nombre = "Mueble", Precio = 350.99m, Imagen = "/Recursos/Imagenes/Sofá/sofa.jpg", Descripcion = "Un cómodo sofá de tres plazas.", Categoria = categoria1 },
                new Producto { Id = 6, Nombre = "Comedor", Precio = 450.50m, Imagen = "/Recursos/Imagenes/MesaComedor/mesa.jpg", Descripcion = "Una elegante mesa de comedor para seis personas.", Categoria = categoria2 },
                new Producto { Id = 7, Nombre = "Silla", Precio = 120.00m, Imagen = "/Recursos/Imagenes/Sillas/silla.jpg", Descripcion = "Una silla ergonómica para oficina.", Categoria = categoria1 },
            };
        }

        public List<Producto> ObtenerProductos()
        {
            return _productos;
        }

        public Producto ObtenerProductoPorId(int id)
        {
            return _productos.Find(p => p.Id == id);
        }

        public void AgregarProducto(Producto producto)
        {
            _productos.Add(producto);
        }

        public void EliminarProducto(int id)
        {
            var producto = _productos.Find(p => p.Id == id);
            if (producto != null)
            {
                _productos.Remove(producto);
            }
        }

        public void ActualizarProducto(Producto productoActualizado)
        {
            var producto = _productos.Find(p => p.Id == productoActualizado.Id);
            if (producto != null)
            {
                producto.Nombre = productoActualizado.Nombre;
                producto.Descripcion = productoActualizado.Descripcion;
                producto.Precio = productoActualizado.Precio;
                producto.Stock = productoActualizado.Stock;
                producto.Categoria = productoActualizado.Categoria;
                producto.Imagen = productoActualizado.Imagen;
                producto.Detalle = productoActualizado.Detalle;
                producto.Cantidad = productoActualizado.Cantidad;
                producto.EstadoInventario = productoActualizado.EstadoInventario;
            }
        }
    }
}
