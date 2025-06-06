using MuebleriaPIS.Modelos;
using MuebleriaPIS.Servicios;
using MuebleriaPIS.Utilidades;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows;

internal class DetalleUsuarioVistaModelo : INotifyPropertyChanged
{
    private Usuario _usuarioAutenticado;

    public DetalleUsuarioVistaModelo()
    {
        _usuarioAutenticado = EstadoAutenticacion.Instancia.UsuarioAutenticado;
        GuardarCommand = new RelayCommand(Guardar);
    }

    public Usuario UsuarioAutenticado
    {
        get => _usuarioAutenticado;
        set
        {
            _usuarioAutenticado = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(NombreCompleto));
        }
    }

    public string NombreCompleto
    {
        get => $"{_usuarioAutenticado.Nombre} {_usuarioAutenticado.Apellido}";
        set
        {
            var nombres = value.Split(' ');
            if (nombres.Length >= 2)
            {
                _usuarioAutenticado.Nombre = nombres[0];
                _usuarioAutenticado.Apellido = string.Join(" ", nombres.Skip(1));
            }
            else
            {
                _usuarioAutenticado.Nombre = nombres[0];
                _usuarioAutenticado.Apellido = string.Empty;
            }
            OnPropertyChanged();
        }
    }

    public ICommand GuardarCommand { get; }

    private void Guardar()
    {
        // Validar los datos
        if (string.IsNullOrWhiteSpace(_usuarioAutenticado.Nombre) ||
            string.IsNullOrWhiteSpace(_usuarioAutenticado.Apellido) ||
            string.IsNullOrWhiteSpace(_usuarioAutenticado.Correo))
        {
            MessageBox.Show("Todos los campos son obligatorios.");
            return;
        }

        if (!Validador.EsCorreoValido(_usuarioAutenticado.Correo))
        {
            MessageBox.Show("El correo no es válido.");
            return;
        }

        // Aquí puedes agregar la lógica para guardar los cambios del usuario
        EstadoAutenticacion.Instancia.UsuarioAutenticado = _usuarioAutenticado;
        // También puedes agregar lógica para persistir los cambios en una base de datos o servicio

        // Mostrar mensaje de confirmación
        MessageBox.Show("Se han actualizado los datos.");
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
