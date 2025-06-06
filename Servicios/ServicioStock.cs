using MuebleriaPIS.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MuebleriaPIS.Servicios
{
    public class ServicioStock
    {
        // Lista en memoria para simular el stock
        private static List<ProductoStock> _stocks = new List<ProductoStock>();

        public void AgregarStock(ProductoStock stock)
        {
            _stocks.Add(stock);
        }

        public void ActualizarStock(int productoId, int nuevaCantidad)
        {
            var stock = _stocks.FirstOrDefault(s => s.Id_Producto == productoId);
            if (stock != null)
            {
                stock.CantidadDisponible = nuevaCantidad;
            }
        }

        public ProductoStock ObtenerStockPorProducto(int productoId)
        {
            return _stocks.FirstOrDefault(s => s.Id_Producto == productoId);
        }
    }
}
