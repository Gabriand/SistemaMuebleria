using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MuebleriaPIS.Modelos;

namespace MuebleriaPIS.Vistas.Inventario
{
    public partial class InventarioAdmin : Page
    {
        // Lista en memoria para simular el inventario
        private static List<Producto> datosInventario = new List<Producto>
        {
            new Producto { Id_Producto = 1, Nombre = "Silla", Descripcion = "Silla de madera", Precio = 500, Categoria = new Categoria { Id_Categoria = 2, Nombre_Categoria = "Silla" }, Ultima_Actualizacion = DateTime.Now, Stock = 10 },
            new Producto { Id_Producto = 2, Nombre = "Mesa", Descripcion = "Mesa de comedor", Precio = 1500, Categoria = new Categoria { Id_Categoria = 3, Nombre_Categoria = "Comedor" }, Ultima_Actualizacion = DateTime.Now, Stock = 5 }
        };

        public InventarioAdmin()
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
            var producto = datosInventario.Find(p => p.Id_Producto == idProducto);

            if (producto == null)
            {
                // Agregar nuevo producto
                producto = new Producto
                {
                    Id_Producto = idProducto,
                    Nombre = txtNombreProducto.Text,
                    Descripcion = txtDescripcionProducto.Text,
                    Precio = decimal.Parse(txtPrecioProducto.Text),
                    Stock = int.Parse(txtStockProducto.Text),
                    Ultima_Actualizacion = DateTime.Now,
                    Categoria = new Categoria { Nombre_Categoria = txtCategoriaProducto.Text }
                };
                datosInventario.Add(producto);
            }
            else
            {
                // Actualizar producto existente
                producto.Nombre = txtNombreProducto.Text;
                producto.Descripcion = txtDescripcionProducto.Text;
                producto.Precio = decimal.Parse(txtPrecioProducto.Text);
                producto.Stock = int.Parse(txtStockProducto.Text);
                producto.Ultima_Actualizacion = DateTime.Now;
                producto.Categoria = new Categoria { Nombre_Categoria = txtCategoriaProducto.Text };
            }

            MessageBox.Show("Operación realizada correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            CargarDatosInventario();
        }

        private bool ValidarEntradas()
        {
            if (string.IsNullOrWhiteSpace(txtIdProducto.Text) ||
                string.IsNullOrWhiteSpace(txtNombreProducto.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcionProducto.Text) ||
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

        private void EliminarProducto_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdProducto.Text))
            {
                MessageBox.Show("Por favor, ingresa el ID del producto a eliminar.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int idProducto = int.Parse(txtIdProducto.Text);
            var producto = datosInventario.Find(p => p.Id_Producto == idProducto);

            if (producto != null)
            {
                datosInventario.Remove(producto);
                MessageBox.Show("Producto eliminado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                CargarDatosInventario();
            }
            else
            {
                MessageBox.Show("No se encontró un producto con el ID especificado.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
            this.NavigationService.Navigate(new InicioAdmin());
        }
    }
}
