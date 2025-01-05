using MuebleriaPIS.VistaModelo;
using MuebleriaPIS.Vistas.Compartido;
using MuebleriaPIS.Vistas.Ingreso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MuebleriaPIS.Vistas.Ingreso
{
    public partial class RegistroCliente : Page
    {
        public RegistroCliente()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new IngresoPage());
        }
    }
}
