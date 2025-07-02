// Clase que representa un nodo en la lista enlazada
class Node
{
    public int Data; // Dato del nodo
    public Node? Next; // Referencia al siguiente nodo, ahora es anulable
    public Node(int data)
    {
        Data = data; // Inicializar el dato
        Next = null; // Inicializar la referencia al siguiente nodo como nula
    }
}