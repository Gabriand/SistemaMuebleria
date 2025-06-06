using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MuebleriaPIS.Vistas.Inventario
{
    public partial class GestionInventario : Page
    {
        // Simulación de inventario en memoria
        private static List<ProductoInventario> datosInventario = new List<ProductoInventario>
        {
            new ProductoInventario { IdProducto = 1, Nombre = "Silla", Precio = 500, Categoria = "Silla", FechaIngreso = DateTime.Now, CantidadDisponible = 10 },
            new ProductoInventario { IdProducto = 2, Nombre = "Mesa", Precio = 1500, Categoria = "Comedor", FechaIngreso = DateTime.Now, CantidadDisponible = 5 }
        };

        public GestionInventario()
        {
            InitializeComponent();
            CargarDatosInventario();
        }

        private void CargarDatosInventario()
        {
            try
            {
                dgInventario.ItemsSource = null;
                dgInventario.ItemsSource = datosInventario;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del inventario: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AgregarOActualizarProducto_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarEntradas()) return;

            int idProducto = int.Parse(txtIdProducto.Text);
            var producto = datosInventario.Find(p => p.IdProducto == idProducto);

            if (producto == null)
            {
                producto = new ProductoInventario
                {
                    IdProducto = idProducto,
                    Nombre = txtNombreProducto.Text,
                    Precio = decimal.Parse(txtPrecioProducto.Text),
                    Categoria = txtCategoriaProducto.Text,
                    FechaIngreso = DateTime.Now,
                    CantidadDisponible = int.Parse(txtStockProducto.Text)
                };
                datosInventario.Add(producto);
            }
            else
            {
                producto.Nombre = txtNombreProducto.Text;
                producto.Precio = decimal.Parse(txtPrecioProducto.Text);
                producto.Categoria = txtCategoriaProducto.Text;
                producto.FechaIngreso = DateTime.Now;
                producto.CantidadDisponible = int.Parse(txtStockProducto.Text);
            }

            MessageBox.Show("Operación realizada correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            CargarDatosInventario();
        }

        private bool ValidarEntradas()
        {
            if (string.IsNullOrWhiteSpace(txtIdProducto.Text) ||
                string.IsNullOrWhiteSpace(txtNombreProducto.Text) ||
                string.IsNullOrWhiteSpace(txtPrecioProducto.Text) ||
                string.IsNullOrWhiteSpace(txtCategoriaProducto.Text) ||
                string.IsNullOrWhiteSpace(txtStockProducto.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!decimal.TryParse(txtPrecioProducto.Text, out _) || !int.TryParse(txtStockProducto.Text, out _))
            {
                MessageBox.Show("Por favor, ingresa valores numéricos válidos para el precio y la cantidad.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            var image = sender as Image;
            if (image != null)
            {
                image.Cursor = Cursors.Hand;
                image.Opacity = 0.7;
            }
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            var image = sender as Image;
            if (image != null)
            {
                image.Cursor = Cursors.Arrow;
                image.Opacity = 1.0;
            }
        }

        private void RegresarBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new InicioTrabajador());
        }
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
