using MuebleriaPIS.VistaModelo;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using System.Windows.Input;

namespace MuebleriaPIS.Vistas.Reportes
{
    public partial class ReporteInventario : Page
    {
        private readonly ReporteInventarioVistaModelo _viewModel;

        public ReporteInventario()
        {
            InitializeComponent();
            _viewModel = new ReporteInventarioVistaModelo();
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            var image = sender as Image;
            if (image != null)
            {
                image.Cursor = Cursors.Hand;
                image.Opacity = 0.7; // Cambia la opacidad para dar un efecto visual
            }
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            var image = sender as Image;
            if (image != null)
            {
                image.Cursor = Cursors.Arrow;
                image.Opacity = 1.0; // Restaura la opacidad original
            }
        }

        private void RegresoBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new InicioTrabajador());
        }

        private void SeleccionarRuta_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf",
                DefaultExt = ".pdf"
            };

            if (dialog.ShowDialog() == true)
            {
                RutaTextBox.Text = dialog.FileName;
            }
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(RutaTextBox.Text))
            {
                MessageBox.Show("Por favor, seleccione una ruta para guardar el archivo.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Generar el reporte PDF
            _viewModel.GenerarReportePDF(RutaTextBox.Text);
        }
    }
}
