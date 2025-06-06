using MuebleriaPIS.Servicios;
using System;
using System.IO;
using System.Windows;

namespace MuebleriaPIS.VistaModelo
{
    internal class ReporteInventarioVistaModelo
    {
        private readonly ServicioReportes _servicioReportes;
        private readonly ServicioPDF _servicioPDF;

        public ReporteInventarioVistaModelo()
        {
            _servicioReportes = new ServicioReportes();
            _servicioPDF = new ServicioPDF();
        }

        public void GenerarReportePDF(string ruta)
        {
            try
            {
                // Validar ruta y permisos
                if (string.IsNullOrEmpty(ruta) || !Directory.Exists(Path.GetDirectoryName(ruta)))
                {
                    MessageBox.Show("La ruta especificada no es válida o no existe.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Obtener datos del servicio
                int cantidadClientes = _servicioReportes.ObtenerCantidadClientes();
                int cantidadProductos = _servicioReportes.ObtenerCantidadProductos();
                int cantidadStock = _servicioReportes.ObtenerCantidadStock();

                // Generar PDF
                _servicioPDF.GenerarReporteInventario(ruta, cantidadClientes, cantidadProductos, cantidadStock);

                MessageBox.Show("Reporte generado exitosamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
