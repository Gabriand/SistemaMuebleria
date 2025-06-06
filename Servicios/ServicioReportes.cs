using System;
using System.Collections.Generic;
using System.Windows;

namespace MuebleriaPIS.Servicios
{
    internal class ServicioReportes
    {
        // Simulación de datos en memoria
        private static List<object> clientes = new List<object> { new object(), new object() };
        private static List<object> productos = new List<object> { new object(), new object(), new object() };
        private static int stockTotal = 100;

        public int ObtenerCantidadClientes()
        {
            return clientes.Count;
        }

        public int ObtenerCantidadProductos()
        {
            return productos.Count;
        }

        public int ObtenerCantidadStock()
        {
            return stockTotal;
        }
    }
}
