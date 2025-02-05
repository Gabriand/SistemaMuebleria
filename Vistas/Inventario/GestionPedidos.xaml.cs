using MuebleriaPIS.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MuebleriaPIS.Vistas.Inventario
{
    public partial class GestionPedidos : Page
    {
        private string connectionString = "server=localhost;database=muebleria_jpatinio;user=root;password=root;";
        private List<Producto> productosSeleccionados = new List<Producto>();

        public GestionPedidos()
        {
            InitializeComponent();
        }

        private void GuardarPedido_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Verificar que el Id_Cliente existe en la tabla 'cliente'
                    string queryVerificarCliente = "SELECT COUNT(*) FROM cliente WHERE Id_Cliente = @IdCliente";
                    MySqlCommand cmdVerificarCliente = new MySqlCommand(queryVerificarCliente, conn);
                    cmdVerificarCliente.Parameters.AddWithValue("@IdCliente", txtIdCliente.Text);
                    int clienteExiste = Convert.ToInt32(cmdVerificarCliente.ExecuteScalar());

                    if (clienteExiste == 0)
                    {
                        MessageBox.Show("El ID del cliente no existe. Por favor, ingrese un ID de cliente válido.");
                        return;
                    }

                    // Verificar que el Id_Personal existe en la tabla 'personal'
                    string queryVerificarPersonal = "SELECT COUNT(*) FROM personal WHERE Id_Personal = @IdPersonal";
                    MySqlCommand cmdVerificarPersonal = new MySqlCommand(queryVerificarPersonal, conn);
                    cmdVerificarPersonal.Parameters.AddWithValue("@IdPersonal", txtIdPersonal.Text);
                    int personalExiste = Convert.ToInt32(cmdVerificarPersonal.ExecuteScalar());

                    if (personalExiste == 0)
                    {
                        MessageBox.Show("El ID del personal no existe. Por favor, ingrese un ID de personal válido.");
                        return;
                    }

                    // Guardar el pedido en la tabla 'pedidos'
                    string queryPedido = "INSERT INTO pedidos (Id_Cliente, Id_Personal, Fecha_creacion, Total_pedido) " +
                                         "VALUES (@IdCliente, @IdPersonal, @FechaCreacion, @TotalPedido)";
                    MySqlCommand cmdPedido = new MySqlCommand(queryPedido, conn);
                    cmdPedido.Parameters.AddWithValue("@IdCliente", txtIdCliente.Text);
                    cmdPedido.Parameters.AddWithValue("@IdPersonal", txtIdPersonal.Text);
                    cmdPedido.Parameters.AddWithValue("@FechaCreacion", dpFechaCreacion.SelectedDate.Value);
                    cmdPedido.Parameters.AddWithValue("@TotalPedido", txtTotalPedido.Text);
                    cmdPedido.ExecuteNonQuery();

                    MessageBox.Show("Pedido guardado con éxito.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            var image = sender as Image;
            if (image != null)
            {
                image.Cursor = Cursors.Hand;
                image.Opacity = 0.7; // Cambia la opacidad para dar un efecto visual
            }
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            var image = sender as Image;
            if (image != null)
            {
                image.Cursor = Cursors.Arrow;
                image.Opacity = 1.0; // Restaura la opacidad original
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
    }
}
