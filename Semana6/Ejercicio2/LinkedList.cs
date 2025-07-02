using System;

class LinkedList
{
    private Node? head; // Cabeza de la lista, ahora es anulable
    public int Count { get; private set; } // Contador de elementos en la lista

    public LinkedList()
    {
        head = null; // Inicializar la cabeza como nula
        Count = 0; // Inicializar el contador en cero
    }

    // Método para agregar un elemento al final de la lista
    public void Add(int data)
    {
        Node newNode = new Node(data); // Crear un nuevo nodo
        if (head == null) // Si la lista está vacía
        {
            head = newNode; // El nuevo nodo se convierte en la cabeza
        }
        else
        {
            Node current = head; // Comenzar desde la cabeza
            while (current.Next != null) // Recorrer hasta el final de la lista
            {
                current = current.Next;
            }
            current.Next = newNode; // Agregar el nuevo nodo al final
        }
        Count++; // Incrementar el contador
    }

    // Método para agregar un elemento al inicio de la lista
    public void AddAtStart(int data)
    {
        Node newNode = new Node(data); // Crear un nuevo nodo
        newNode.Next = head; // El nuevo nodo apunta a la cabeza actual
        head = newNode; // La cabeza ahora es el nuevo nodo
        Count++; // Incrementar el contador
    }

    // Método para mostrar todos los elementos de la lista
    public void Display()
    {
        Node? current = head; // Comenzar desde la cabeza
        while (current != null) // Recorrer la lista
        {
            Console.Write(current.Data + " "); // Mostrar el dato del nodo
            current = current.Next; // Avanzar al siguiente nodo
        }
        Console.WriteLine(); // Nueva línea al final
    }
}
