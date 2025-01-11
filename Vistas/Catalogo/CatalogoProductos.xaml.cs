using System.Windows.Controls;
using MuebleriaPIS.VistaModelo;

namespace MuebleriaPIS.Vistas.Catalogo
{
    public partial class CatalogoProductos : Page
    {
        public CatalogoProductos()
        {
            InitializeComponent();
            var viewModel = new CatalogoProductosVistaModelo();
            this.DataContext = viewModel;
            barraNavegacion.VentanasGrid.Visibility = System.Windows.Visibility.Visible;
        }
    }
}

