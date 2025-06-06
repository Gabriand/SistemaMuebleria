using System.Windows.Controls;
using MuebleriaPIS.VistaModelo;
using System.Windows.Navigation;
using System;
using MuebleriaPIS.Vistas.ListaDeseo;

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
            _viewModel.NavegarEvent += OnNavegar;
            this.DataContext = _viewModel;
            filtroCatalogo.DataContext = _viewModel; // Asegurarse de que el DataContext esté configurado correctamente
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

        private void OnNavegar(Page page)
        {
            NavigationService.Navigate(page);
        }

        private void SeleccionarProductos_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new SeleccionarProductos());
        }
    }
}

