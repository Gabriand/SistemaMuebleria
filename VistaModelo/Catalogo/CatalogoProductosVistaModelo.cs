using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MuebleriaPIS.Modelos;
using MuebleriaPIS.Servicios;
using System.ComponentModel;
using System.Windows.Input;
using MuebleriaPIS.Utilidades;

namespace MuebleriaPIS.VistaModelo
{
    public class CatalogoProductosVistaModelo : INotifyPropertyChanged
    {
        private readonly ServicioProductos _servicioProductos;

        public ObservableCollection<Producto> Productos { get; set; }
        public ObservableCollection<Producto> ProductosFiltrados { get; set; }
        public ICommand NavegarADetalleCommand { get; }
        public ICommand AplicarFiltroCommand { get; }

        private string _categoriaSeleccionada;
        public string CategoriaSeleccionada
        {
            get => _categoriaSeleccionada;
            set
            {
                _categoriaSeleccionada = value;
                OnPropertyChanged(nameof(CategoriaSeleccionada));
                AplicarFiltro();
            }
        }

        private decimal? _precioMinimo;
        public decimal? PrecioMinimo
        {
            get => _precioMinimo;
            set
            {
                _precioMinimo = value;
                OnPropertyChanged(nameof(PrecioMinimo));
                AplicarFiltro();
            }
        }

        private decimal? _precioMaximo;
        public decimal? PrecioMaximo
        {
            get => _precioMaximo;
            set
            {
                _precioMaximo = value;
                OnPropertyChanged(nameof(PrecioMaximo));
                AplicarFiltro();
            }
        }

        public CatalogoProductosVistaModelo()
        {
            _servicioProductos = new ServicioProductos();
            var productos = _servicioProductos.ObtenerProductos();

            Productos = new ObservableCollection<Producto>(productos);
            ProductosFiltrados = new ObservableCollection<Producto>(Productos);
            NavegarADetalleCommand = new RelayCommand<object>(NavegarADetalle);
            AplicarFiltroCommand = new RelayCommand(AplicarFiltro);
        }

        private void AplicarFiltro()
        {
            var productosFiltrados = Productos.AsEnumerable();

            if (!string.IsNullOrEmpty(CategoriaSeleccionada))
            {
                productosFiltrados = productosFiltrados.Where(p => p.Categoria.Id.ToString() == CategoriaSeleccionada);
            }

            if (PrecioMinimo.HasValue)
            {
                productosFiltrados = productosFiltrados.Where(p => p.Precio >= PrecioMinimo.Value);
            }

            if (PrecioMaximo.HasValue)
            {
                productosFiltrados = productosFiltrados.Where(p => p.Precio <= PrecioMaximo.Value);
            }

            ProductosFiltrados = new ObservableCollection<Producto>(productosFiltrados);
            OnPropertyChanged(nameof(ProductosFiltrados));
        }

        private void NavegarADetalle(object parameter)
        {
            // Lógica para navegar a la vista de detalles del producto
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
