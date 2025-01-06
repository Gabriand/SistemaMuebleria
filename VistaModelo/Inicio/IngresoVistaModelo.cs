using MuebleriaPIS.Modelos;
using MuebleriaPIS.Servicios;
using MuebleriaPIS.Utilidades;
using MuebleriaPIS.Vistas;
using MuebleriaPIS.Vistas.Catalogo;
using MuebleriaPIS.Vistas.Ingreso;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace MuebleriaPIS.VistaModelo
{
    internal class IngresoVistaModelo
    {
        private readonly ServicioAutenticacion _servicioAutenticacion;

        public string Identificador { get; set; }
        public string Contrasena { get; set; }
        public ICommand IngresarCommand { get; }

        public IngresoVistaModelo()
        {
            _servicioAutenticacion = new ServicioAutenticacion();
            IngresarCommand = new RelayCommand<NavigationService>(Ingresar);
        }

        private void Ingresar(NavigationService navigationService)
        {
            var usuario = _servicioAutenticacion.Autenticar(Identificador, Contrasena);
            if (usuario != null)
            {
                NavegarSegunRol(usuario, navigationService);
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas.");
            }
        }

        private void NavegarSegunRol(Usuario usuario, NavigationService navigationService)
        {
            if (usuario == null)
            {
                MessageBox.Show("Credenciales inválidas.");
                return;
            }

            switch (usuario.Rol)
            {
                case "Cliente":
                    navigationService.Navigate(new CatalogoProductos());
                    break;

                case "Trabajador":
                    MessageBox.Show("Próximamente disponible: Funcionalidades para Trabajadores.");
                    navigationService.Navigate(new InicioTrabajador());
                    break;

                case "Admin":
                    MessageBox.Show("Próximamente disponible: Funcionalidades para Administradores.");
                    navigationService.Navigate(new InicioAdmin());
                    break;

                default:
                    MessageBox.Show("Rol desconocido. Comuníquese con el soporte.");
                    break;
            }
        }

        public Usuario ObtenerUsuarioAutenticado()
        {
            return EstadoAutenticacion.Instancia.UsuarioAutenticado;
        }
    }
}
