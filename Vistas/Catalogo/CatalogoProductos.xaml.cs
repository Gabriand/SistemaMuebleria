using System.Windows.Controls;
using MuebleriaPIS.VistaModelo;
using System.Windows.Navigation;
using System;

namespace MuebleriaPIS.Vistas.Catalogo
{
    public partial class CatalogoProductos : Page
    {
        private CatalogoProductosVistaModelo _viewModel;

        public CatalogoProductos()
        {
            InitializeComponent();
            this.Loaded += CatalogoProductos_Loaded;
            barraNavegacion.BusquedaClicked += BarraNavegacion_BusquedaClicked;
        }

        private void CatalogoProductos_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            _viewModel = new CatalogoProductosVistaModelo();
            this.DataContext = _viewModel;
            filtroCatalogo.DataContext = _viewModel;
            barraNavegacion.VentanasGrid.Visibility = System.Windows.Visibility.Visible;
        }

        private void BarraNavegacion_BusquedaClicked(object sender, EventArgs e)
        {
            if (filtroCatalogo.Visibility == System.Windows.Visibility.Collapsed)
            {
                filtroCatalogo.Visibility = System.Windows.Visibility.Visible;
                gridSplitter.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                filtroCatalogo.Visibility = System.Windows.Visibility.Collapsed;
                gridSplitter.Visibility = System.Windows.Visibility.Collapsed;
            }
        }
    }
}
