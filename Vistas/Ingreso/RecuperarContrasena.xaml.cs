﻿using System;
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

namespace MuebleriaPIS.Vistas.Ingreso
{
    /// <summary>
    /// Lógica de interacción para RecuperarContrasena.xaml
    /// </summary>
    public partial class RecuperarContrasena : Page
    {
        public RecuperarContrasena()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new IngresoPage());
        }
    }
}