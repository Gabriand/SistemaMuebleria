using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuebleriaPIS.Modelos
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public Categoria Categoria { get; set; } // Asegúrate de que esta propiedad sea pública y tenga el nombre correcto
        public string Imagen { get; set; }
        public string Detalle { get; set; }
        public int Cantidad { get; set; }
        public string EstadoInventario { get; set; }
    }
}
