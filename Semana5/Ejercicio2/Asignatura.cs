 using System;
using System.Collections.Generic;

// Clase que representa una Asignatura con su nota
public class Asignatura
{
    public string Nombre { get; set; }
    public double Nota { get; set; }

    public Asignatura(string nombre)
    {
        Nombre = nombre;
        Nota = 0.0; // Inicializar nota en 0
    }

    // Método para determinar si está aprobada (nota >= 5)
    public bool EstaAprobada()
    {
        return Nota >= 5.0;
    }

    public override string ToString()
    {
        return $"{Nombre} (Nota: {Nota})";
    }
}