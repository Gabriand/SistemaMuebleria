using MuebleriaPIS.Modelos;
using MuebleriaPIS.Servicios;
using System.ComponentModel;
using System.Windows.Input;
using MuebleriaPIS.Utilidades;
using System.Windows;

namespace MuebleriaPIS.VistaModelo
{
    public class DetalleProductosVistaModelo : INotifyPropertyChanged
    {
        private Producto _productoSeleccionado;
        private CatalogoProductosVistaModelo _catalogoProductosVistaModelo;
        private string _usuarioActual;

        public Producto ProductoSeleccionado
        {
            get => _productoSeleccionado;
            set
            {
                _productoSeleccionado = value;
                OnPropertyChanged(nameof(ProductoSeleccionado));
                OnPropertyChanged(nameof(ImagenRuta));
            }
        }

        public string ImagenRuta => ProductoSeleccionado?.ImagenRuta;

        public ICommand AñadirAListaCommand { get; }

        public DetalleProductosVistaModelo(Producto producto, CatalogoProductosVistaModelo catalogoProductosVistaModelo, string usuarioActual)
        {
            ProductoSeleccionado = producto;
            _catalogoProductosVistaModelo = catalogoProductosVistaModelo;
            _usuarioActual = usuarioActual;
            AñadirAListaCommand = new RelayCommand(AñadirALista);
            CargarDetallesProducto();
        }

        private void CargarDetallesProducto()
        {
            var servicioProductos = new ServicioProductos();
            ProductoSeleccionado = servicioProductos.ObtenerDetallesProducto(ProductoSeleccionado.Id_Producto);
        }

        private void AñadirALista()
        {
            // Lógica para agregar el producto a la lista de deseos del usuario actual
            var detallePedidoVistaModelo = new DetallePedidoVistaModelo(_usuarioActual);
            detallePedidoVistaModelo.AgregarProductoALista(ProductoSeleccionado);

            MessageBox.Show("Producto agregado a la lista de deseos.", "Confirmación", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
