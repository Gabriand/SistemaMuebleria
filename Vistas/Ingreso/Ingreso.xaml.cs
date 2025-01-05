using System.Windows;
using System.Windows.Controls;
using MuebleriaPIS.VistaModelo;
using MuebleriaPIS.Vistas.Ingreso;

namespace MuebleriaPIS.Vistas
{
    public partial class IngresoPage : Page
    {
        private BarraNavegacionVistaModelo _viewModel;

        public IngresoPage()
        {
            InitializeComponent();

            // Barra de Navegación
            _viewModel = new BarraNavegacionVistaModelo
            {
                MostrarControlesUsuario = false, // Oculta los controles de usuario en la página de ingreso
            };
            barraNavegacion.DataContext = _viewModel;

            // Configurar el DataContext para IngresoVistaModelo
            DataContext = new IngresoVistaModelo();
        }

        private void IngresoBtn_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (IngresoVistaModelo)DataContext;
            viewModel.Identificador = txtUsuario.Text;
            viewModel.Contrasena = txtContrasena.Password;
            viewModel.IngresarCommand.Execute(NavigationService);
        }

        private void btnRegistrarse_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistroCliente());
        }

        private void OlvidasteContrasena_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RecuperarContrasena());
        }
    }
}
