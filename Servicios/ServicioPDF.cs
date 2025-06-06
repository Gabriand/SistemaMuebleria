using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;

namespace MuebleriaPIS.Servicios
{
    public class ServicioPDF
    {
        public void GenerarReporteInventario(string rutaArchivo, int cantidadClientes, int cantidadProductos, int cantidadStock)
        {
            // Crear documento
            Document documento = new Document(PageSize.A4);

            try
            {
                // Crear escritor para guardar el PDF
                PdfWriter.GetInstance(documento, new FileStream(rutaArchivo, FileMode.Create));
                documento.Open();

                // Agregar título al PDF
                var titulo = new Paragraph("Reporte de Inventario", new Font(Font.FontFamily.HELVETICA, 18, Font.BOLD))
                {
                    Alignment = Element.ALIGN_CENTER
                };
                documento.Add(titulo);

                // Agregar fecha
                var fecha = new Paragraph($"Fecha: {DateTime.Now:dd/MM/yyyy}", new Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL))
                {
                    Alignment = Element.ALIGN_RIGHT
                };
                documento.Add(fecha);

                documento.Add(new Paragraph("\n"));

                // Agregar información general
                var infoGeneral = new Paragraph("Información General", new Font(Font.FontFamily.HELVETICA, 14, Font.BOLD))
                {
                    Alignment = Element.ALIGN_LEFT
                };
                documento.Add(infoGeneral);

                documento.Add(new Paragraph($"Cantidad de Clientes: {cantidadClientes}", new Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL)));
                documento.Add(new Paragraph($"Cantidad de Productos: {cantidadProductos}", new Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL)));
                documento.Add(new Paragraph($"Cantidad de Stock: {cantidadStock}", new Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL)));

                documento.Add(new Paragraph("\n"));

                // Agregar tabla de resumen
                var tabla = new PdfPTable(2)
                {
                    WidthPercentage = 100
                };
                tabla.SetWidths(new float[] { 1, 2 });

                // Encabezados de la tabla
                var celdaEncabezado1 = new PdfPCell(new Phrase("Descripción", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)))
                {
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    BackgroundColor = BaseColor.LIGHT_GRAY
                };
                tabla.AddCell(celdaEncabezado1);

                var celdaEncabezado2 = new PdfPCell(new Phrase("Cantidad", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)))
                {
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    BackgroundColor = BaseColor.LIGHT_GRAY
                };
                tabla.AddCell(celdaEncabezado2);

                // Filas de la tabla
                tabla.AddCell(new PdfPCell(new Phrase("Clientes", new Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL)))
                {
                    HorizontalAlignment = Element.ALIGN_LEFT
                });
                tabla.AddCell(new PdfPCell(new Phrase(cantidadClientes.ToString(), new Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL)))
                {
                    HorizontalAlignment = Element.ALIGN_RIGHT
                });

                tabla.AddCell(new PdfPCell(new Phrase("Productos", new Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL)))
                {
                    HorizontalAlignment = Element.ALIGN_LEFT
                });
                tabla.AddCell(new PdfPCell(new Phrase(cantidadProductos.ToString(), new Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL)))
                {
                    HorizontalAlignment = Element.ALIGN_RIGHT
                });

                tabla.AddCell(new PdfPCell(new Phrase("Stock", new Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL)))
                {
                    HorizontalAlignment = Element.ALIGN_LEFT
                });
                tabla.AddCell(new PdfPCell(new Phrase(cantidadStock.ToString(), new Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL)))
                {
                    HorizontalAlignment = Element.ALIGN_RIGHT
                });

                documento.Add(tabla);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar el PDF: " + ex.Message);
            }
            finally
            {
                documento.Close();
            }
        }
    }
}
