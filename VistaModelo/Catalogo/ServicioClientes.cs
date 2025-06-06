using System;

internal class ServicioClientes
{
    public ServicioClientes()
    {
        // Constructor
    }

    public Cliente ObtenerClienteActual()
    {
        // Implementa la lógica para obtener el cliente actual
        // Esto es solo un ejemplo, ajusta según tu lógica de negocio
        return new Cliente { Usuario = "usuarioActual" };
    }
}

public class Cliente
{
    public int Id_Cliente { get; set; }
    public string Usuario { get; set; }
    public string Contrasena { get; set; }
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public string Correo_Electronico { get; set; }
    public DateTime Fecha_registro { get; set; }
}
