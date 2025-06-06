using MuebleriaPIS.Vistas.Inventario;
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

namespace MuebleriaPIS.Vistas.Compartido
{
    public partial class BarraAdministrador : UserControl
    {
        public BarraAdministrador()
        {
            InitializeComponent();
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

        public void GPedidosBtn_Click(object sender, RoutedEventArgs e)
        {
            var gestionPedidosPage = new GestionPedidos();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            if (navigationService != null)
            {
                navigationService.Navigate(gestionPedidosPage);
            }
        }

        public void GestionClienBtn_Click(object sender, RoutedEventArgs e)
        {
            var gestionClientesPage = new GestionClientes();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            if (navigationService != null)
            {
                navigationService.Navigate(gestionClientesPage);
            }
        }

        public void InventarioBtn_Click(object sender, RoutedEventArgs e)
        {
            var inventarioAdminPage = new InventarioAdmin();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            if (navigationService != null)
            {
                navigationService.Navigate(inventarioAdminPage);
            }
        }

        public void Salir_Click(object sender, RoutedEventArgs e)
        {
            var salirPage = new IngresoPage();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            if (navigationService != null)
            {
                navigationService.Navigate(salirPage);
            }
        }
    }
}
