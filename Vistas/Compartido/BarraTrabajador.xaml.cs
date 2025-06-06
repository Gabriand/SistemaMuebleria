using MuebleriaPIS.VistaModelo;
using MuebleriaPIS.Vistas.GestionUsuarios;
using MuebleriaPIS.Vistas.Inventario;
using MuebleriaPIS.Vistas.ListaDeseo;
using MuebleriaPIS.Vistas.Reportes;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace MuebleriaPIS.Vistas.Compartido
{
    public partial class BarraTrabajador : UserControl
    {
        public BarraTrabajador()
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

        private void Inventario_Click(object sender, RoutedEventArgs e)
        {
            var gestionInventarioPage = new GestionInventario();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            if (navigationService != null)
            {
                navigationService.Navigate(gestionInventarioPage);
            }
        }

        private void UsuariosPedidos_Click(object sender, RoutedEventArgs e)
        {
            var pedidosPage = new Pedidos();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            if (navigationService != null)
            {
                navigationService.Navigate(pedidosPage);
            }
        }

        private void Reportes_Click(object sender, RoutedEventArgs e)
        {
            var reportesInventarioPage = new ReporteInventario();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            if (navigationService != null)
            {
                navigationService.Navigate(reportesInventarioPage);
            }
        }

        private void Salir_Click(object sender, RoutedEventArgs e)
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
