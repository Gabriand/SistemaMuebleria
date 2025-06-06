using MuebleriaPIS.VistaModelo;
using MuebleriaPIS.Vistas.Compartido;
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

namespace MuebleriaPIS.Vistas.Catalogo
{
    public partial class FiltroCatalogo : UserControl
    {
        private CatalogoProductosVistaModelo _productosViewModel;

        public FiltroCatalogo()
        {
            InitializeComponent();
        }

        public void BuscarProducto_Click(object sender, RoutedEventArgs e)
        {
            _productosViewModel = (CatalogoProductosVistaModelo)this.DataContext;

            if (string.IsNullOrWhiteSpace(_productosViewModel.PrecioMinimo.ToString()) || string.IsNullOrWhiteSpace(_productosViewModel.PrecioMaximo.ToString()))
            {
                MessageBox.Show("Por favor, complete ambos campos de precio.", "Campos incompletos", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!decimal.TryParse(_productosViewModel.PrecioMinimo.ToString(), out decimal precioMinimo) || !decimal.TryParse(_productosViewModel.PrecioMaximo.ToString(), out decimal precioMaximo))
            {
                MessageBox.Show("Por favor, ingrese valores numéricos válidos para los precios.", "Valores inválidos", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (precioMinimo > precioMaximo)
            {
                MessageBox.Show("El precio mínimo no puede ser mayor que el precio máximo.", "Rango de precios inválido", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Asignar los valores al ViewModel de productos y aplicar el filtro
            _productosViewModel.PrecioMinimo = precioMinimo;
            _productosViewModel.PrecioMaximo = precioMaximo;
            _productosViewModel.AplicarFiltro();
        }

        public void ReiniciarBusqueda_Click(object sender, RoutedEventArgs e)
        {
            _productosViewModel = (CatalogoProductosVistaModelo)this.DataContext;
            _productosViewModel.PrecioMinimo = null;
            _productosViewModel.PrecioMaximo = null;
            _productosViewModel.CategoriaSeleccionada = null;
            _productosViewModel.AplicarFiltro();
        }
    }
}
