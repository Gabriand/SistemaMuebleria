using System.ComponentModel;
using MuebleriaPIS.Modelos;

namespace MuebleriaPIS.VistaModelo
{
    public class DetalleProductosVistaModelo : INotifyPropertyChanged
    {
        private Producto _producto;

        public Producto Producto
        {
            get => _producto;
            set
            {
                _producto = value;
                OnPropertyChanged(nameof(Producto));
            }
        }

        public DetalleProductosVistaModelo(Producto producto)
        {
            Producto = producto;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
