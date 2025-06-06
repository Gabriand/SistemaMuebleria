using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MuebleriaPIS.Vistas.Inventario
{
    public partial class GestionClientes : Page
    {
        // Lista en memoria para simular los clientes
        private static List<Cliente> clientes = new List<Cliente>
        {
            new Cliente { Id_Cliente = 1, Usuario = "cliente1", Contrasena = "1234", Nombres = "Juan", Apellidos = "Pérez", Direccion = "Calle 1", Telefono = "123456789", Correo_Electronico = "cliente1@correo.com", Fecha_registro = DateTime.Now },
            new Cliente { Id_Cliente = 2, Usuario = "cliente2", Contrasena = "abcd", Nombres = "Ana", Apellidos = "García", Direccion = "Calle 2", Telefono = "987654321", Correo_Electronico = "cliente2@correo.com", Fecha_registro = DateTime.Now }
        };

        public GestionClientes()
        {
            InitializeComponent();
            CargarClientes();
        }

        private void CargarClientes()
        {
            try
            {
                ClientesDataGrid.ItemsSource = null;
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
                clientes.Remove(clienteSeleccionado);
                MessageBox.Show("Cliente eliminado exitosamente.");
                CargarClientes();
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
