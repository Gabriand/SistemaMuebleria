using MuebleriaPIS.Modelos;
using MuebleriaPIS.VistaModelo;
using System.Windows;
using System.Windows.Controls;

namespace MuebleriaPIS.Vistas.Catalogo
{
    public partial class DetalleProductos : Page
    {
        public DetalleProductos(Producto producto, CatalogoProductosVistaModelo catalogoProductosVistaModelo, string usuarioActual)
        {
            InitializeComponent();
            DataContext = new DetalleProductosVistaModelo(producto, catalogoProductosVistaModelo, usuarioActual);
        }
    }
}
