using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuebleriaPIS.Modelos;

namespace MuebleriaPIS.Servicios
{
    internal class EstadoAutenticacion
    {
        private static EstadoAutenticacion _instancia;
        public static EstadoAutenticacion Instancia => _instancia ?? (_instancia = new EstadoAutenticacion());

        private EstadoAutenticacion() { }

        public Usuario UsuarioAutenticado { get; set; }
    }
}
