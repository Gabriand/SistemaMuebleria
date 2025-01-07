using MuebleriaPIS.VistaModelo;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace MuebleriaPIS.Vistas.Catalogo
{
    public partial class DetalleProductos : Page
    {
        public DetalleProductos()
        {
            InitializeComponent();
        }

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CatalogoProductos());
        }
    }
}
