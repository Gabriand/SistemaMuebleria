using MuebleriaPIS.Modelos;
using MuebleriaPIS.Servicios;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MuebleriaPIS.VistaModelo
{
    internal class DetalleUsuarioVistaModelo : INotifyPropertyChanged
    {
        private Usuario _usuarioAutenticado;

        public DetalleUsuarioVistaModelo()
        {
            _usuarioAutenticado = EstadoAutenticacion.Instancia.UsuarioAutenticado;
        }

        public Usuario UsuarioAutenticado
        {
            get => _usuarioAutenticado;
            set
            {
                _usuarioAutenticado = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
