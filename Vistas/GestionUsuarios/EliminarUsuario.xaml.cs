using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MuebleriaPIS.Vistas.GestionUsuarios
{
    public partial class EliminarUsuario : Page
    {
        // Simulación de usuarios en memoria
        private static List<Usuario> usuarios = new List<Usuario>
        {
            new Usuario { Id = 1, NomUsuario = "admin" },
            new Usuario { Id = 2, NomUsuario = "cliente" }
        };

        public EliminarUsuario()
        {
            InitializeComponent();
        }

        private void EliminarUsuario_Click(object sender, RoutedEventArgs e)
        {
            int idUsuario;
            if (!int.TryParse(txtIdUsuario.Text, out idUsuario))
            {
                lblEstado.Text = "Por favor, ingrese un ID de usuario válido.";
                lblEstado.Foreground = new SolidColorBrush(Colors.Red);
                return;
            }

            var usuario = usuarios.Find(u => u.Id == idUsuario);
            if (usuario == null)
            {
                lblEstado.Text = "El usuario no existe.";
                lblEstado.Foreground = new SolidColorBrush(Colors.Red);
                return;
            }

            usuarios.Remove(usuario);
            lblEstado.Text = "Usuario eliminado correctamente.";
            lblEstado.Foreground = new SolidColorBrush(Colors.Green);
        }
    }

    public class Usuario
    {
        public int Id { get; set; }
        public string NomUsuario { get; set; }
    }
}
