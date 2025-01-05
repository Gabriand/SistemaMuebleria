using MuebleriaPIS.Modelos;
using MuebleriaPIS.Vistas.Catalogo;
using MuebleriaPIS.Vistas.GestionUsuarios;
using MuebleriaPIS.Vistas.Ingreso;
using MuebleriaPIS.Vistas.ListaDeseo;
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
    public partial class BarraNavegacion : UserControl
    {
        public static readonly DependencyProperty MostrarBotonRegresoProperty =
            DependencyProperty.Register("MostrarBotonRegreso", typeof(bool), typeof(BarraNavegacion), new PropertyMetadata(true));

        public bool MostrarBotonRegreso
        {
            get { return (bool)GetValue(MostrarBotonRegresoProperty); }
            set { SetValue(MostrarBotonRegresoProperty, value); }
        }

        public static readonly DependencyProperty MostrarBotonBusquedaProperty =
            DependencyProperty.Register("MostrarBotonBusqueda", typeof(bool), typeof(BarraNavegacion), new PropertyMetadata(true));

        public bool MostrarBotonBusqueda
        {
            get { return (bool)GetValue(MostrarBotonBusquedaProperty); }
            set { SetValue(MostrarBotonBusquedaProperty, value); }
        }

        public BarraNavegacion()
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

        private void ListaDeseos_Click(object sender, MouseButtonEventArgs e)
        {
            var detallePedidoPage = new DetallePedido();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            if (navigationService != null)
            {
                navigationService.Navigate(detallePedidoPage);
            }
        }

        private void PerfilUsuario_Click(object sender, MouseButtonEventArgs e)
        {
            var detalleUsuarioPage = new DetalleUsuario();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            if (navigationService != null)
            {
                navigationService.Navigate(detalleUsuarioPage);
            }
        }

        private void Regreso_Click(object sender, MouseButtonEventArgs e)
        {
            var catalogoProductosPage = new CatalogoProductos();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            if (navigationService != null)
            {
                navigationService.Navigate(catalogoProductosPage);
            }
        }

        private void Busqueda_Click(object sender, MouseButtonEventArgs e)
        {
            // Lanzar el evento BusquedaClicked
        }
    }
}
