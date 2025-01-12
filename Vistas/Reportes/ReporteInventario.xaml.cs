// File: Vistas/Reportes/ReporteInventario.xaml.cs
using System.Windows;

namespace MuebleriaPIS.Vistas.Reportes
{
    public partial class ReporteInventario : Window
    {
        public ReporteInventario()
        {
            InitializeComponent();
        }

        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
