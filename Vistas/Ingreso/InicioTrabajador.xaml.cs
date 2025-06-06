using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using MuebleriaPIS.Vistas.Inventario;
using System.Collections.Generic;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using MuebleriaPIS.Vistas.Reportes;

namespace MuebleriaPIS.Vistas
{
    public partial class InicioTrabajador : Page
    {
        public InicioTrabajador()
        {
            InitializeComponent();
            CargarDatosInventario();
            CargarCantidadClientes();
            CargarCantidadProductos();
        }

        private void GenerarReporte_Click(object sender, RoutedEventArgs e)
        {
            ReporteInventario reporteInventario = new ReporteInventario();
            NavigationService.Navigate(reporteInventario);
        }

        private void CargarDatosInventario()
        {
            try
            {
                var datosInventario = new List<ProductoInventario>
                {
                    new ProductoInventario { IdProducto = 1, Nombre = "Silla", Precio = 500, Categoria = "Silla", FechaIngreso = DateTime.Now, CantidadDisponible = 10 },
                    new ProductoInventario { IdProducto = 2, Nombre = "Mesa", Precio = 1500, Categoria = "Comedor", FechaIngreso = DateTime.Now, CantidadDisponible = 5 }
                };

                vgInventario.ItemsSource = datosInventario;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del inventario: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CargarCantidadClientes()
        {
            try
            {
                ClientCount = 2; // Simulado
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la cantidad de clientes: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CargarCantidadProductos()
        {
            try
            {
                ProductCount = 15; // Simulado
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la cantidad de productos: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public int ClientCount { get; set; } = 0;
        public int OrderCount { get; set; } = 0;
        public int ProductCount { get; set; } = 0;
    }

    public class ProductoInventario
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Categoria { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int CantidadDisponible { get; set; }
    }
}
