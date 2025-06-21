using System;

public class Contacto
{
    // Atributos de la clase Contacto
    public int Id { get; set; } // Identificador único del contacto
    public string Nombre { get; set; } // Nombre del contacto
    public string Apellido { get; set; } // Apellido del contacto
    public string Telefono { get; set; } // Número de teléfono del contacto
    public string Email { get; set; } // Dirección de correo electrónico del contacto
    public string Direccion { get; set; } // Dirección física del contacto
    public DateTime FechaRegistro { get; set; } // Fecha y hora en que se registró el contacto
    public string Categoria { get; set; } // Categoría del contacto (por ejemplo, amigo, familiar, trabajo, etc.)

    // Constructor de la clase Contacto
    public Contacto(int id, string nombre, string apellido, string telefono, string email, string direccion, string categoria)
    {
        // Inicializa los atributos del contacto con los valores proporcionados
        this.Id = id; // Asigna el ID del contacto
        this.Nombre = nombre; // Asigna el nombre del contacto
        this.Apellido = apellido; // Asigna el apellido del contacto
        this.Telefono = telefono; // Asigna el teléfono del contacto
        this.Email = email; // Asigna el email del contacto
        this.Direccion = direccion; // Asigna la dirección del contacto
        this.FechaRegistro = DateTime.Now; // Asigna la fecha y hora actual como fecha de registro
        this.Categoria = categoria; // Asigna la categoría del contacto
    }

    // Método para mostrar la información del contacto
    public void MostrarInformacion()
    {
        Console.WriteLine("=== Información del Contacto ==="); // Encabezado
        Console.WriteLine($"ID: {Id}"); // Muestra el ID del contacto
        Console.WriteLine($"Nombre Completo: {Nombre} {Apellido}"); // Muestra el nombre completo del contacto
        Console.WriteLine($"Teléfono: {Telefono}"); // Muestra el teléfono del contacto
        Console.WriteLine($"Email: {Email}"); // Muestra el email del contacto
        Console.WriteLine($"Dirección: {Direccion}"); // Muestra la dirección del contacto
        Console.WriteLine($"Categoría: {Categoria}"); // Muestra la categoría del contacto
        Console.WriteLine($"Fecha de Registro: {FechaRegistro:dd/MM/yyyy HH:mm}"); // Muestra la fecha de registro en formato específico
    }

    // Método para obtener el nombre completo del contacto
    public string NombreCompleto()
    {
        return $"{Nombre} {Apellido}"; // Retorna el nombre completo concatenando nombre y apellido
    }
}
