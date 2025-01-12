﻿using MuebleriaPIS.Vistas.GestionUsuarios;
using MuebleriaPIS.Vistas.Inventario;
using MuebleriaPIS.Vistas.ListaDeseo;
using MuebleriaPIS.Vistas.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MuebleriaPIS.Vistas.Compartido
{
    public partial class BarraTrabajador : UserControl
    {
        public BarraTrabajador()
        {
            InitializeComponent();
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            var image = sender as Image;
            if (image != null)
            {
                image.Cursor = Cursors.Hand;
                image.Opacity = 0.7; // Cambia la opacidad para dar un efecto visual
            }
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            var image = sender as Image;
            if (image != null)
            {
                image.Cursor = Cursors.Arrow;
                image.Opacity = 1.0; // Restaura la opacidad original
            }
        }

        private void Inventario_Click(object sender, RoutedEventArgs e)
        {
            var gestionInventarioPage = new GestionInventario();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            if (navigationService != null)
            {
                navigationService.Navigate(gestionInventarioPage);
            }
        }

        private void UsuariosPedidos_Click(object sender, RoutedEventArgs e)
        {
            var pedidosPage = new Pedidos();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            if (navigationService != null)
            {
                navigationService.Navigate(pedidosPage);
            }
        }

        private void Reportes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var inicioTrabajador = (InicioTrabajador)Application.Current.MainWindow.Content;
                string ruta = "C:\\Users\\gabri\\Downloads\\reporte.pdf";
                inicioTrabajador.GenerarReportePDF(ruta);

                ReporteInventario ventanaEmergente = new ReporteInventario();
                ventanaEmergente.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al generar el reporte: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            var salirPage = new IngresoPage();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            if (navigationService != null)
            {
                navigationService.Navigate(salirPage);
            }
        }
    }
}