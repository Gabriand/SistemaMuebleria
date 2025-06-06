using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MuebleriaPIS.Modelos;

namespace MuebleriaPIS.Vistas.Inventario
{
    public partial class GestionDetallePedido : Page
    {
        private List<Producto> productos = new List<Producto>
        {
            new Producto { Id_Producto = 1, Nombre = "Silla", Precio = 500 },
            new Producto { Id_Producto = 2, Nombre = "Mesa", Precio = 1500 }
        };

        public GestionDetallePedido()
        {
            InitializeComponent();
            CargarProductos();
        }

        private void CargarProductos()
        {
            try
            {
                cbProductos.Items.Clear();
                foreach (var producto in productos)
                {
                    cbProductos.Items.Add(producto);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }

        private void cbProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbProductos.SelectedItem != null)
            {
                Producto productoSeleccionado = (Producto)cbProductos.SelectedItem;
                txtPrecioUnitario.Text = productoSeleccionado.Precio.ToString("F2");
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

        private void RegresarBtn_Click(object sender, MouseEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void AgregarDetalle_Click(object sender, RoutedEventArgs e)
        {
            if (cbProductos.SelectedItem != null && !string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                Producto productoSeleccionado = (Producto)cbProductos.SelectedItem;
                int cantidad = int.Parse(txtCantidad.Text);
                decimal precioUnitario = productoSeleccionado.Precio;

                // Simulación de guardado del detalle del pedido
                MessageBox.Show("Detalle del pedido guardado con éxito (simulado).");
            }
        }
    }
}
