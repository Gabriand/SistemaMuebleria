using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using MuebleriaPIS.Modelos;
using MuebleriaPIS.Utilidades;

namespace MuebleriaPIS.VistaModelo
{
    public class DetallePedidoVistaModelo : INotifyPropertyChanged
    {
        private static Dictionary<string, ObservableCollection<Producto>> _listasDeseosPorUsuario = new Dictionary<string, ObservableCollection<Producto>>();
        private string _usuarioActual;

        public ObservableCollection<Producto> ListaDeseos
        {
            get
            {
                if (_usuarioActual != null && _listasDeseosPorUsuario.ContainsKey(_usuarioActual))
                {
                    return _listasDeseosPorUsuario[_usuarioActual];
                }
                return new ObservableCollection<Producto>();
            }
        }

        public ICommand EliminarProductoCommand { get; }
        public ICommand GenerarPedidoCommand { get; }

        public DetallePedidoVistaModelo(string usuarioActual)
        {
            _usuarioActual = usuarioActual;
            if (!_listasDeseosPorUsuario.ContainsKey(_usuarioActual))
            {
                _listasDeseosPorUsuario[_usuarioActual] = new ObservableCollection<Producto>();
            }

            EliminarProductoCommand = new RelayCommand<Producto>(EliminarProducto);
            GenerarPedidoCommand = new RelayCommand(GenerarPedido);
        }

        public void AgregarProductoALista(Producto producto)
        {
            if (producto != null && !_listasDeseosPorUsuario[_usuarioActual].Contains(producto))
            {
                _listasDeseosPorUsuario[_usuarioActual].Add(producto);
                OnPropertyChanged(nameof(ListaDeseos));
            }
        }

        private void EliminarProducto(Producto producto)
        {
            if (producto != null && _listasDeseosPorUsuario[_usuarioActual].Contains(producto))
            {
                _listasDeseosPorUsuario[_usuarioActual].Remove(producto);
                OnPropertyChanged(nameof(ListaDeseos));
            }
        }

        private void GenerarPedido()
        {
            // Aquí puedes implementar la lógica alternativa para generar un pedido sin MySQL.
            // Por ejemplo, podrías guardar los datos en memoria, en un archivo, o simplemente mostrar un mensaje.
            if (ListaDeseos.Count == 0)
            {
                MessageBox.Show("No hay productos en la lista de deseos.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            // Simulación de generación de pedido
            MessageBox.Show("Pedido generado exitosamente (sin base de datos).", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

            // Opcional: limpiar la lista de deseos después de generar el pedido
            _listasDeseosPorUsuario[_usuarioActual].Clear();
            OnPropertyChanged(nameof(ListaDeseos));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}