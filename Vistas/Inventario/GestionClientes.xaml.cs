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
    public partial class GestionClientes : Page
    {
        private string connectionString = "Server=127.0.0.1;Port=3306;Database=muebleria_jpatinio;Uid=root;Pwd=root;";

        public GestionClientes()
        {
            InitializeComponent();
            CargarClientes();
        }

        private void CargarClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Id_Cliente, Usuario, Contrasena, Nombres, Apellidos, Direccion, Telefono, Correo_Electronico, Fecha_registro FROM cliente";
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cliente cliente = new Cliente
                            {
                                Id_Cliente = reader.GetInt32("Id_Cliente"),
                                Usuario = reader.GetString("Usuario"),
                                Contrasena = reader.GetString("Contrasena"),
                                Nombres = reader.GetString("Nombres"),
                                Apellidos = reader.GetString("Apellidos"),
                                Direccion = reader.GetString("Direccion"),
                                Telefono = reader.GetString("Telefono"),
                                Correo_Electronico = reader.GetString("Correo_Electronico"),
                                Fecha_registro = reader.GetDateTime("Fecha_registro")
                            };
                            clientes.Add(cliente);
                        }
                    }
                }

                // Asignar la lista de clientes al DataGrid
                ClientesDataGrid.ItemsSource = clientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }

        // Evento para eliminar un cliente
        private void EliminarBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ClientesDataGrid.SelectedItem != null)
            {
                var clienteSeleccionado = (Cliente)ClientesDataGrid.SelectedItem;
                int idCliente = clienteSeleccionado.Id_Cliente;

                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "DELETE FROM cliente WHERE Id_Cliente = @Id_Cliente";
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@Id_Cliente", idCliente);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Cliente eliminado exitosamente.");
                            CargarClientes(); // Recargar la lista después de eliminar
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el cliente.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el cliente: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente para eliminar.");
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
            this.NavigationService.Navigate(new InicioAdmin());
        }
    }

    public class Cliente
    {
        public int Id_Cliente { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo_Electronico { get; set; }
        public DateTime Fecha_registro { get; set; }
    }
}
