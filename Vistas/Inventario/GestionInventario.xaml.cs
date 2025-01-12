using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace MuebleriaPIS.Vistas.Inventario
{
    public partial class GestionInventario : Page
    {
        public GestionInventario()
        {
            InitializeComponent();
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            var image = sender as Image;
            if (image != null)
            {
                image.Cursor = Cursors.Hand;
                image.Opacity = 0.7;
            }
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            var image = sender as Image;
            if (image != null)
            {
                image.Cursor = Cursors.Arrow;
                image.Opacity = 1.0;
            }
        }

        private void Regreso_Click(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new InicioTrabajador());
        }
    }
}

