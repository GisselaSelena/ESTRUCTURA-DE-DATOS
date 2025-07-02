using System;

// Clase que representa un nodo de la lista enlazada
class Nodo
{
    public int Valor; // Valor del nodo
    public Nodo? Siguiente; // Referencia al siguiente nodo, ahora es anulable

    // Constructor que inicializa el valor del nodo
    public Nodo(int valor)
    {
        Valor = valor;
        Siguiente = null; // Inicialmente, el siguiente nodo es nulo
    }
}


