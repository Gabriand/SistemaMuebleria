using MuebleriaPIS.VistaModelo;
using MuebleriaPIS.Vistas;
using MuebleriaPIS.Vistas.Catalogo;
using MuebleriaPIS.Vistas.Compartido;
using MuebleriaPIS.Vistas.ListaDeseo;
using MuebleriaPIS.Vistas.GestionUsuarios;
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
            DataContext = new IngresoVistaModelo();
            MainFrame.Navigate(new IngresoPage());
            //MainFrame.Navigate(new InicioTrabajador());
            //MainFrame.Navigate(new DetalleProductos());
            //MainFrame.Navigate(new CatalogoProductos());
            //MainFrame.Navigate(new InicioAdmin());

        }
    }
}
