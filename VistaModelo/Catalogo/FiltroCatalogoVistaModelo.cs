using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using MuebleriaPIS.Utilidades;

namespace MuebleriaPIS.VistaModelo
{
    public class FiltroCatalogoVistaModelo : INotifyPropertyChanged
    {
        private string _categoriaSeleccionada;
        private decimal? _precioMinimo;
        private decimal? _precioMaximo;

        public string CategoriaSeleccionada
        {
            get => _categoriaSeleccionada;
            set
            {
                _categoriaSeleccionada = value;
                OnPropertyChanged(nameof(CategoriaSeleccionada));
            }
        }

        public decimal? PrecioMinimo
        {
            get => _precioMinimo;
            set
            {
                _precioMinimo = value;
                OnPropertyChanged(nameof(PrecioMinimo));
            }
        }

        public decimal? PrecioMaximo
        {
            get => _precioMaximo;
            set
            {
                _precioMaximo = value;
                OnPropertyChanged(nameof(PrecioMaximo));
            }
        }

        public ICommand AplicarFiltroCommand { get; }

        public FiltroCatalogoVistaModelo()
        {
            AplicarFiltroCommand = new RelayCommand(AplicarFiltro);
        }

        private void AplicarFiltro()
        {
            // Lógica para aplicar el filtro
            // Aquí puedes acceder a las propiedades CategoriaSeleccionada, PrecioMinimo y PrecioMaximo
            // y aplicar los filtros correspondientes en el ViewModel de productos
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
