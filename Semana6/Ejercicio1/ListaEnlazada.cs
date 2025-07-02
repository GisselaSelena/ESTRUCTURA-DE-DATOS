// Clase que representa la lista enlazada
class ListaEnlazada
{
    private Nodo? cabeza = null; // Referencia al primer nodo de la lista, ahora es anulable

    // Método para agregar un nuevo nodo con un valor específico
    public void Agregar(int valor)
    {
        Nodo nuevoNodo = new Nodo(valor); // Crear un nuevo nodo
        if (cabeza == null) // Si la lista está vacía
        {
            cabeza = nuevoNodo; // El nuevo nodo se convierte en la cabeza
        }
        else
        {
            Nodo actual = cabeza; // Comenzar desde la cabeza
            // Recorrer la lista hasta el último nodo
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevoNodo; // Agregar el nuevo nodo al final
        }
    }

    // Método para eliminar nodos cuyo valor esté fuera del rango especificado
    public void EliminarFueraDeRango(int min, int max)
    {
        // Eliminar nodos desde la cabeza que estén fuera del rango
        while (cabeza != null && (cabeza.Valor < min || cabeza.Valor > max))
        {
            cabeza = cabeza.Siguiente; // Mover la cabeza al siguiente nodo
        }

        if (cabeza == null) return; // Si la lista quedó vacía, salir

        Nodo actual = cabeza; // Comenzar desde la cabeza
        // Recorrer la lista y eliminar nodos fuera del rango
        while (actual.Siguiente != null)
        {
            if (actual.Siguiente.Valor < min || actual.Siguiente.Valor > max)
            {
                actual.Siguiente = actual.Siguiente.Siguiente; // Eliminar el nodo
            }
            else
            {
                actual = actual.Siguiente; // Mover al siguiente nodo
            }
        }
    }

    // Método para mostrar todos los valores de la lista enlazada
    public void Mostrar()
    {
        Nodo? actual = cabeza; // Comenzar desde la cabeza
        // Recorrer la lista y mostrar los valores
        while (actual != null)
        {
            Console.Write(actual.Valor + " "); // Mostrar el valor del nodo
            actual = actual.Siguiente; // Mover al siguiente nodo
        }
        Console.WriteLine(); // Nueva línea al final
    }
}


/* Crear una lista enlazada con 50 números enteros, del 1 al 999 generados aleatoriamente. Una
vez creada la lista, vez creada la lista, se deben eliminar los nodos qu se deben eliminar los nodos que estén fuera de un r e estén fuera de un rango de valores leídos ango de valores leídos
desde el teclado. */