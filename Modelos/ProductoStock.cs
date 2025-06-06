using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuebleriaPIS.Modelos
{
    public class ProductoStock
    {
        public int Id_Producto { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int CantidadDisponible { get; set; }
    }
}
