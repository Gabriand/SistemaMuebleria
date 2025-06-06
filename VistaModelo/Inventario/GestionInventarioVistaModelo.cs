using MuebleriaPIS.Modelos;
using MuebleriaPIS.Servicios;
using MuebleriaPIS.Utilidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MuebleriaPIS.VistaModelo
{
    public class GestionInventarioVistaModelo : INotifyPropertyChanged
    {
        private readonly ServicioProductos _servicioProductos;
        private readonly ServicioStock _servicioStock;

        public ObservableCollection<Producto> Inventario { get; set; }

        private Producto _productoSeleccionado;
        public Producto ProductoSeleccionado
        {
            get => _productoSeleccionado;
            set
            {
                _productoSeleccionado = value;
                OnPropertyChanged(nameof(ProductoSeleccionado));
                if (_productoSeleccionado != null)
                {
                    NombreProducto = _productoSeleccionado.Nombre;
                    PrecioProducto = _productoSeleccionado.Precio;
                    var stock = _servicioStock.ObtenerStockPorProducto(_productoSeleccionado.Id_Producto);
                    CantidadDisponible = stock?.CantidadDisponible ?? 0;
                }
            }
        }

        private string _nombreProducto;
        public string NombreProducto
        {
            get => _nombreProducto;
            set
            {
                _nombreProducto = value;
                OnPropertyChanged(nameof(NombreProducto));
            }
        }

        private decimal _precioProducto;
        public decimal PrecioProducto
        {
            get => _precioProducto;
            set
            {
                _precioProducto = value;
                OnPropertyChanged(nameof(PrecioProducto));
            }
        }

        private int _cantidadDisponible;
        public int CantidadDisponible
        {
            get => _cantidadDisponible;
            set
            {
                _cantidadDisponible = value;
                OnPropertyChanged(nameof(CantidadDisponible));
            }
        }

        public ICommand ActualizarStockCommand { get; }

        public GestionInventarioVistaModelo()
        {
            _servicioProductos = new ServicioProductos();
            _servicioStock = new ServicioStock();
            Inventario = new ObservableCollection<Producto>(_servicioProductos.ObtenerProductos());
            ActualizarStockCommand = new RelayCommand(ActualizarStock);
        }

        private void ActualizarStock()
        {
            if (ProductoSeleccionado != null)
            {
                _servicioStock.ActualizarStock(ProductoSeleccionado.Id_Producto, CantidadDisponible);
                // Actualizar la lista de productos después de la actualización del stock
                Inventario = new ObservableCollection<Producto>(_servicioProductos.ObtenerProductos());
                OnPropertyChanged(nameof(Inventario));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

