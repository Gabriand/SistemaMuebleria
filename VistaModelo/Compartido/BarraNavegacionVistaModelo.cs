using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuebleriaPIS.VistaModelo
{
    public class BarraNavegacionVistaModelo : INotifyPropertyChanged
    {
        private bool _mostrarControlesUsuario;

        public bool MostrarControlesUsuario
        {
            get => _mostrarControlesUsuario;
            set
            {
                _mostrarControlesUsuario = value;
                OnPropertyChanged(nameof(MostrarControlesUsuario));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}