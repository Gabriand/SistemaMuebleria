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
            _productos = new List<Producto>
            {
                new Producto { Nombre = "Mueble", Precio = 350.99m, Imagen = "/Recursos/Imagenes/Sofá/sofa.jpg", Descripcion = "Un cómodo sofá de tres plazas." },
                new Producto { Nombre = "Comedor", Precio = 450.50m, Imagen = "/Recursos/Imagenes/MesaComedor/mesa.jpg", Descripcion = "Una elegante mesa de comedor para seis personas." },
                new Producto { Nombre = "Silla", Precio = 120.00m, Imagen = "/Recursos/Imagenes/Sillas/silla.jpg", Descripcion = "Una silla ergonómica para oficina." },
                new Producto { Nombre = "Mueble bonito", Precio = 350.99m, Imagen = "/Recursos/Imagenes/Sofá/sofa1.jpg", Descripcion = "Un bonito sofá de dos plazas." },
                // Más productos de prueba
                new Producto { Nombre = "Mueble", Precio = 350.99m, Imagen = "/Recursos/Imagenes/Sofá/sofa.jpg", Descripcion = "Un cómodo sofá de tres plazas." },
                new Producto { Nombre = "Comedor", Precio = 450.50m, Imagen = "/Recursos/Imagenes/MesaComedor/mesa.jpg", Descripcion = "Una elegante mesa de comedor para seis personas." },
                new Producto { Nombre = "Silla", Precio = 120.00m, Imagen = "/Recursos/Imagenes/Sillas/silla.jpg", Descripcion = "Una silla ergonómica para oficina." },
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
                producto.CategoriaId = productoActualizado.CategoriaId;
                producto.Imagen = productoActualizado.Imagen;
                producto.Detalle = productoActualizado.Detalle;
                producto.Cantidad = productoActualizado.Cantidad;
                producto.EstadoInventario = productoActualizado.EstadoInventario;
            }
        }
    }
}
