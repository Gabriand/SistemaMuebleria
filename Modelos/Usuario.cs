using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuebleriaPIS.Modelos
{
    internal class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; } //Puede ser Admin, Trabajador o Cliente
        public string Correo { get; set; }
        public string Direccion { get; set; } //Puede ser null
        public int? Telefono { get; set; } //Puede ser null
        public string Contrasena { get; set; }
    }
}
