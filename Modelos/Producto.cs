using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuebleriaPIS.Modelos
{
    public class Producto
    {
        public int Id_Producto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; } 
        public decimal Precio { get; set; }
        public int Stock { get; set; } 
        public DateTime Ultima_Actualizacion { get; set; }
        public Categoria Categoria { get; set; }
        public string Imagen { get; set; }
        public DetallesProducto Detalles { get; set; }
        public string ImagenRuta
        {
            get
            {
                switch (Categoria.Nombre_Categoria.ToLower())
                {
                    case "silla":
                        return "/Recursos/Imagenes/Sillas/silla.jpg";
                    case "comedor":
                        return "/Recursos/Imagenes/Comedores/comedor.jpg";
                    case "mueble":
                        return "/Recursos/Imagenes/Muebles/mueble.jpg";
                    default:
                        return "/Recursos/Imagenes/default.jpg";
                }
            }
        }
    }

    public class Categoria
    {
        public int Id_Categoria { get; set; }
        public string Nombre_Categoria { get; set; }
    }

    public class DetallesProducto
    {
        public int Id_Detalles_Producto { get; set; }
        public int Id_Producto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
    }
}

