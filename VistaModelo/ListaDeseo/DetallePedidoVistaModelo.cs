using System.Collections.ObjectModel;
using System.ComponentModel;
using MuebleriaPIS.Modelos;

namespace MuebleriaPIS.VistaModelo
{
    public class DetallePedidoVistaModelo : INotifyPropertyChanged
    {
        public ObservableCollection<Producto> ListaDeseos { get; set; }

        public DetallePedidoVistaModelo()
        {
            ListaDeseos = new ObservableCollection<Producto>();
        }

        public void AñadirALista(Producto producto)
        {
            ListaDeseos.Add(producto);
            OnPropertyChanged(nameof(ListaDeseos));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
