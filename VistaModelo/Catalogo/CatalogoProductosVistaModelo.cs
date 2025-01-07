using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MuebleriaPIS.Modelos;
using MuebleriaPIS.Vistas.Catalogo;
using MuebleriaPIS.Vistas.Compartido;
using MuebleriaPIS.Vistas.ListaDeseo;
using MuebleriaPIS.Vistas;
using MuebleriaPIS.VistaModelo;
using MuebleriaPIS.Utilidades;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows;
using System.Windows.Controls;

namespace MuebleriaPIS.VistaModelo
{
    public class CatalogoProductosVistaModelo : INotifyPropertyChanged
    {
        public ObservableCollection<Producto> Productos { get; set; }
        public ICommand NavegarADetalleCommand { get; }

        public CatalogoProductosVistaModelo()
        {
            Productos = new ObservableCollection<Producto>
            {
                new Producto { Nombre = "Sofá", Precio = 350.99m, Imagen = "/Recursos/Imagenes/Sofá/sofa.jpg" },
                new Producto { Nombre = "Mesa de comedor", Precio = 450.50m, Imagen = "/Recursos/Imagenes/MesaComedor/mesa.jpg" },
                new Producto { Nombre = "Silla", Precio = 120.00m, Imagen = "/Recursos/Imagenes/Sillas/silla.jpg" },
                //Aqui se agregan mas ventanitas de productos
                new Producto { Nombre = "Sofá bonito", Precio = 350.99m, Imagen = "/Recursos/Imagenes/Sofá/sofa1.jpg" },
                new Producto { Nombre = "Sofá", Precio = 350.99m, Imagen = "/Recursos/Imagenes/Sofá/sofa.jpg" },
                new Producto { Nombre = "Mesa de comedor", Precio = 450.50m, Imagen = "/Recursos/Imagenes/MesaComedor/mesa.jpg" },
                new Producto { Nombre = "Silla", Precio = 120.00m, Imagen = "/Recursos/Imagenes/Sillas/silla.jpg" },
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

