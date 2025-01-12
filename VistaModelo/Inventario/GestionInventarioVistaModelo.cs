using MuebleriaPIS.Modelos;
using MuebleriaPIS.Servicios;
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
        private Producto _productoSeleccionado;

        public ObservableCollection<Producto> Inventario { get; set; }
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
                    StockProducto = _productoSeleccionado.Stock;
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

        private int _stockProducto;
        public int StockProducto
        {
            get => _stockProducto;
            set
            {
                _stockProducto = value;
                OnPropertyChanged(nameof(StockProducto));
            }
        }

        public ICommand ActualizarProductoCommand { get; }

        public GestionInventarioVistaModelo()
        {
            _servicioProductos = new ServicioProductos();
            Inventario = new ObservableCollection<Producto>(_servicioProductos.ObtenerProductos());
            ActualizarProductoCommand = new RelayCommand(ActualizarProducto);
        }

        private void ActualizarProducto()
        {
            if (ProductoSeleccionado != null)
            {
                ProductoSeleccionado.Nombre = NombreProducto;
                ProductoSeleccionado.Precio = PrecioProducto;
                ProductoSeleccionado.Stock = StockProducto;

                _servicioProductos.ActualizarProducto(ProductoSeleccionado);
                OnPropertyChanged(nameof(Inventario));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}

