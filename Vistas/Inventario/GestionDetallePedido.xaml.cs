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

    public partial class GestionDetallePedido : Page
    {
        private string connectionString = "server=localhost;database=muebleria_jpatinio;user=root;password=root;";
        private List<Producto> productos = new List<Producto>();
        public GestionDetallePedido()
        {
            InitializeComponent();
        }

        private void CargarProductos()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT Id_Producto, Nombre, Precio FROM producto";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Producto producto = new Producto
                        {
                            Id_Producto = reader.GetInt32("Id_Producto"),
                            Nombre = reader.GetString("Nombre"),
                            Precio = reader.GetDecimal("Precio")
                        };
                        productos.Add(producto);
                        cbProductos.Items.Add(producto);
                    }
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

        private void AgregarDetalle_Click(object sender, RoutedEventArgs e)
        {
            if (cbProductos.SelectedItem != null && !string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                Producto productoSeleccionado = (Producto)cbProductos.SelectedItem;
                int cantidad = int.Parse(txtCantidad.Text);
                decimal precioUnitario = productoSeleccionado.Precio;

                // Guardar el detalle del pedido en la base de datos
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();

                        string queryDetalles = "INSERT INTO detalles_pedido (Id_Pedido, Id_Producto, Cantidad, Precio_Unitario) " +
                                               "VALUES (@IdPedido, @IdProducto, @Cantidad, @PrecioUnitario)";
                        MySqlCommand cmdDetalles = new MySqlCommand(queryDetalles, conn);
                        cmdDetalles.Parameters.AddWithValue("@IdPedido", 1); // Reemplaza con el ID del pedido real
                        cmdDetalles.Parameters.AddWithValue("@IdProducto", productoSeleccionado.Id_Producto);
                        cmdDetalles.Parameters.AddWithValue("@Cantidad", cantidad);
                        cmdDetalles.Parameters.AddWithValue("@PrecioUnitario", precioUnitario);
                        cmdDetalles.ExecuteNonQuery();

                        MessageBox.Show("Detalle del pedido guardado con éxito.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
