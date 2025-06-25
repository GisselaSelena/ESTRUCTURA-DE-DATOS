using System;
using System.Collections.Generic;

// Clase que representa una Asignatura
public class Asignatura
{
    // Propiedad para el nombre de la asignatura
    public string Nombre { get; set; }

    // Constructor
    public Asignatura(string nombre)
    {
        Nombre = nombre;
    }

    // Método para mostrar la asignatura
    public override string ToString()
    {
        return Nombre;
    }
}
