using System;
using System.Windows;
using System.Windows.Controls;

namespace MuebleriaPIS.Vistas.Ingreso
{
    public partial class RecuperarContrasena : Page
    {
        public RecuperarContrasena()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new IngresoPage());
        }

        private void btnRecuperar_Click(object sender, RoutedEventArgs e)
        {
            // Aquí puedes agregar la lógica para recuperar la contraseña
            MessageBox.Show("Se ha enviado un correo para recuperar la contraseña.");
        }
    }
}
