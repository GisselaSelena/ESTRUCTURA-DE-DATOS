using System;

public class Contacto
{
    // Atributos
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public string Direccion { get; set; }
    public DateTime FechaRegistro { get; set; }
    public string Categoria { get; set; }

    // Constructor
    public Contacto(int id, string nombre, string apellido, string telefono, string email, string direccion, string categoria)
    {
        this.Id = id;
        this.Nombre = nombre;
        this.Apellido = apellido;
        this.Telefono = telefono;
        this.Email = email;
        this.Direccion = direccion;
        this.FechaRegistro = DateTime.Now;
        this.Categoria = categoria;
    }

    // Métodos
    public void MostrarInformacion()
    {
        Console.WriteLine("=== Información del Contacto ===");
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Nombre Completo: {Nombre} {Apellido}");
        Console.WriteLine($"Teléfono: {Telefono}");
        Console.WriteLine($"Email: {Email}");
        Console.WriteLine($"Dirección: {Direccion}");
        Console.WriteLine($"Categoría: {Categoria}");
        Console.WriteLine($"Fecha de Registro: {FechaRegistro:dd/MM/yyyy HH:mm}");
    }

    public string NombreCompleto()
    {
        return $"{Nombre} {Apellido}";
    }
}