using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.IO;
using System.Windows.Controls;

namespace MuebleriaPIS.Vistas
{
    public partial class InicioTrabajador : Page
    {
        public InicioTrabajador()
        {
            InitializeComponent();
        }

        public void GenerarReportePDF(string ruta)
        {
            using (PdfWriter writer = new PdfWriter(ruta))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document document = new Document(pdf);
                    document.Add(new Paragraph("Reporte de Vista General"));
                    document.Add(new Paragraph($"Cantidad de Clientes: {ClientCount}"));
                    document.Add(new Paragraph($"Cantidad de Pedidos: {OrderCount}"));
                    document.Add(new Paragraph($"Cantidad de Productos: {ProductCount}"));
                }
            }
        }

        public int ClientCount { get; set; } = 100; // Ejemplo de datos
        public int OrderCount { get; set; } = 50;  // Ejemplo de datos
        public int ProductCount { get; set; } = 200; // Ejemplo de datos
    }
}
