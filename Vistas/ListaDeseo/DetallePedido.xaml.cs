using MuebleriaPIS.Modelos;
using MuebleriaPIS.VistaModelo;
using System.Windows;
using System.Windows.Controls;

namespace MuebleriaPIS.Vistas.ListaDeseo
{
    public partial class DetallePedido : Page
    {
        public DetallePedido(string usuarioActual)
        {
            InitializeComponent();
            DataContext = new DetallePedidoVistaModelo(usuarioActual);
        }
    }
}