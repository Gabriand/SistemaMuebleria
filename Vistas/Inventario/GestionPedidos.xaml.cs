using MuebleriaPIS.Modelos;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MuebleriaPIS.Vistas.Inventario
{
    public partial class GestionPedidos : Page
    {
        // Simulación de pedidos en memoria
        private static List<PedidoSimulado> pedidos = new List<PedidoSimulado>();
        private List<Producto> productosSeleccionados = new List<Producto>();

        public GestionPedidos()
        {
            InitializeComponent();
        }

        private void GuardarPedido_Click(object sender, RoutedEventArgs e)
        {
            // Validación básica de campos
            if (string.IsNullOrWhiteSpace(txtIdCliente.Text) ||
                string.IsNullOrWhiteSpace(txtIdPersonal.Text) ||
                !dpFechaCreacion.SelectedDate.HasValue ||
                string.IsNullOrWhiteSpace(txtTotalPedido.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            // Simulación de verificación de cliente y personal (en un sistema real, aquí se verificaría en la base de datos)
            // Aquí simplemente aceptamos cualquier valor ingresado

            // Simulación de guardado del pedido
            pedidos.Add(new PedidoSimulado
            {
                IdCliente = txtIdCliente.Text,
                IdPersonal = txtIdPersonal.Text,
                FechaCreacion = dpFechaCreacion.SelectedDate.Value,
                TotalPedido = txtTotalPedido.Text
            });

            MessageBox.Show("Pedido guardado con éxito (simulado).");
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

        private void AbrirDetallesPedido_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new GestionDetallePedido());
        }

        private void IrADetalles_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new GestionDetallePedido());
        }

        // Clase interna para simular pedidos
        private class PedidoSimulado
        {
            public string IdCliente { get; set; }
            public string IdPersonal { get; set; }
            public DateTime FechaCreacion { get; set; }
            public string TotalPedido { get; set; }
        }
    }
}
