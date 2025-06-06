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

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new IngresoPage());
        }
    }
}
