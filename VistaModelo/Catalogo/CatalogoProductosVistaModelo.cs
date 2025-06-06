using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using MuebleriaPIS.Modelos;
using MuebleriaPIS.Servicios;
using MuebleriaPIS.Utilidades;
using System.Windows.Navigation;
using MuebleriaPIS.Vistas.Catalogo;
using System.Windows.Controls;

namespace MuebleriaPIS.VistaModelo
{
    public class CatalogoProductosVistaModelo : INotifyPropertyChanged
    {
        private readonly ServicioProductos _servicioProductos;
        private readonly ServicioClientes _servicioClientes;
        public ObservableCollection<Producto> Productos { get; set; }
        public ObservableCollection<Producto> ProductosFiltrados { get; set; }
        public ICommand NavegarADetalleCommand { get; }
        public ICommand AplicarFiltroCommand { get; }

        public event Action<Page> NavegarEvent;

        private string _categoriaSeleccionada;
        public string CategoriaSeleccionada
        {
            get => _categoriaSeleccionada;
            set
            {
                _categoriaSeleccionada = value;
                OnPropertyChanged(nameof(CategoriaSeleccionada));
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
            }
        }

        public CatalogoProductosVistaModelo()
        {
            _servicioProductos = new ServicioProductos();
            _servicioClientes = new ServicioClientes();
            var productos = _servicioProductos.ObtenerProductos();

            Productos = new ObservableCollection<Producto>(productos);
            ProductosFiltrados = new ObservableCollection<Producto>(Productos);
            NavegarADetalleCommand = new RelayCommand<Producto>(NavegarADetalle);
            AplicarFiltroCommand = new RelayCommand<string>(AplicarFiltro);
        }

        public void AplicarFiltro(string categoria = null)
        {
            var productosFiltrados = Productos.AsEnumerable();

            if (!string.IsNullOrEmpty(categoria))
            {
                CategoriaSeleccionada = categoria;
            }

            if (!string.IsNullOrEmpty(CategoriaSeleccionada))
            {
                productosFiltrados = productosFiltrados.Where(p => p.Categoria.Nombre_Categoria == CategoriaSeleccionada);
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

        private void NavegarADetalle(Producto producto)
        {
            if (producto != null)
            {
                // Obtener el usuario actual desde la tabla Cliente
                string usuarioActual = ObtenerUsuarioActual();
                var detalleProductoPage = new DetalleProductos(producto, this, usuarioActual);
                NavegarEvent?.Invoke(detalleProductoPage);
            }
        }

        private string ObtenerUsuarioActual()
        {
            // Implementa la lógica para obtener el usuario actual desde la tabla Cliente
            var clienteActual = _servicioClientes.ObtenerClienteActual();
            return clienteActual?.Usuario;
        }

        public void AgregarProductoALista(Producto producto)
        {
            if (producto != null && !Productos.Contains(producto))
            {
                Productos.Add(producto);
                AplicarFiltro(); // Actualizar la lista filtrada
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
