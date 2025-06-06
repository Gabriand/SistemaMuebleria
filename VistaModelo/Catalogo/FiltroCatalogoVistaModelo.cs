using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MuebleriaPIS.Utilidades;

namespace MuebleriaPIS.VistaModelo
{
    public class FiltroCatalogoVistaModelo : INotifyPropertyChanged
    {
        private string _precioMinimo;
        private string _precioMaximo;

        public string PrecioMinimo
        {
            get { return _precioMinimo; }
            set
            {
                _precioMinimo = value;
                OnPropertyChanged(nameof(PrecioMinimo));
            }
        }

        public string PrecioMaximo
        {
            get { return _precioMaximo; }
            set
            {
                _precioMaximo = value;
                OnPropertyChanged(nameof(PrecioMaximo));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
