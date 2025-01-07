using System.Windows.Controls;
using MuebleriaPIS.VistaModelo;
using System.Windows.Navigation;
using System;

namespace MuebleriaPIS.Vistas.Catalogo
{
    public partial class CatalogoProductos : Page
    {
        public CatalogoProductos()
        {
            InitializeComponent();
            this.Loaded += CatalogoProductos_Loaded;
        }

        private void CatalogoProductos_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var viewModel = new CatalogoProductosVistaModelo();
            this.DataContext = viewModel;
            barraNavegacion.VentanasGrid.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
