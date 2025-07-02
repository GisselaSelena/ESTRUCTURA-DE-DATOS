
class Program
{
    static void Main(string[] args)
    {
        Random random = new Random(); // Generador de números aleatorios
        ListaEnlazada lista = new ListaEnlazada(); // Crear una nueva lista enlazada

        // Generar 50 números aleatorios entre 1 y 999
        for (int i = 0; i < 50; i++)
        {
            int numeroAleatorio = random.Next(1, 1000); // Generar un número aleatorio
            lista.Agregar(numeroAleatorio); // Agregar el número a la lista
        }

        Console.WriteLine("Lista original:");
        lista.Mostrar(); // Mostrar la lista original

        // Leer el rango de valores desde el teclado
        Console.Write("Ingrese el valor mínimo del rango: ");
        string? inputMin = Console.ReadLine(); // Leer el valor mínimo
        int min = int.TryParse(inputMin, out int minValue) ? minValue : int.MinValue; // Convertir a entero o usar valor mínimo

        Console.Write("Ingrese el valor máximo del rango: ");
        string? inputMax = Console.ReadLine(); // Leer el valor máximo
        int max = int.TryParse(inputMax, out int maxValue) ? maxValue : int.MaxValue; // Convertir a entero o usar valor máximo

        // Eliminar nodos fuera del rango
        lista.EliminarFueraDeRango(min, max);

        Console.WriteLine("Lista después de eliminar nodos fuera del rango:");
        lista.Mostrar(); // Mostrar la lista después de eliminar nodos
    }
}
