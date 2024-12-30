using MuebleriaPIS.Vistas;
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

namespace MuebleriaPIS
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Ingreso ingreso = new Ingreso();
            Window window = new Window
            {
                Content = ingreso,
                Width = 800,
                Height = 600
            };
            window.Closed += (s, e) => this.Close(); // Cierra la ventana principal cuando se cierra la ventana de ingreso
            window.ShowDialog();
        }
    }
}
