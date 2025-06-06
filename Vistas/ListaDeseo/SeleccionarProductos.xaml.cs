using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using MuebleriaPIS.Modelos;
using MuebleriaPIS.Vistas.Catalogo;

namespace MuebleriaPIS.Vistas.ListaDeseo
{
    public partial class SeleccionarProductos : Page
    {
        // Simulación de productos en memoria
        public ObservableCollection<Producto> Productos { get; set; }

        public SeleccionarProductos()
        {
            InitializeComponent();
            Productos = new ObservableCollection<Producto>
            {
                new Producto { Id_Producto = 1, Nombre = "Silla", Descripcion = "Silla de madera", Precio = 500, Stock = 10, Ultima_Actualizacion = DateTime.Now, Categoria = new Categoria { Id_Categoria = 2 } },
                new Producto { Id_Producto = 2, Nombre = "Mesa", Descripcion = "Mesa de comedor", Precio = 1500, Stock = 5, Ultima_Actualizacion = DateTime.Now, Categoria = new Categoria { Id_Categoria = 3 } }
            };
            dataGridProductos.ItemsSource = Productos;
        }

        private void AgregarProducto_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridProductos.SelectedItem is Producto producto)
            {
                // Aquí puedes agregar el producto a una lista de deseos en memoria
                MessageBox.Show("Producto agregado a la lista de deseos (simulado).", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void RegresarCatalogo_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CatalogoProductos());
        }
    }
}

