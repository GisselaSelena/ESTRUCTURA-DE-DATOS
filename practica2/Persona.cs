using System;
using System.Collections.Generic;
using System.Linq;
// Clase que representa a una persona en la cola
class Persona
{
    public string Nombre { get; set; } // Nombre de la persona
    public int OrdenLlegada { get; set; } // Orden de llegada de la persona
    // Constructor que inicializa el nombre y el orden de llegada
    public Persona(string nombre, int orden)
    {
        // Se lanza una excepción si el nombre es nulo
        Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre), "El nombre no puede ser nulo.");
        OrdenLlegada = orden; // Se asigna el orden de llegada
    }
}