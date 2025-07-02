class Program
{
    static void Main(string[] args)
    {
        // Crear dos listas enlazadas: una para números primos y otra para números Armstrong
        LinkedList primeList = new LinkedList();
        LinkedList armstrongList = new LinkedList();

        // Agregar números primos a la lista de números primos
        primeList.Add(2);
        primeList.Add(3);
        primeList.Add(5);
        primeList.Add(7);
        primeList.Add(11);

        // Agregar números Armstrong a la lista de números Armstrong
        armstrongList.AddAtStart(153);
        armstrongList.AddAtStart(370);
        armstrongList.AddAtStart(371);
        armstrongList.AddAtStart(407);

        // Mostrar el número de datos en cada lista
        Console.WriteLine($"Números primos: {primeList.Count}");
        Console.WriteLine($"Números Armstrong: {armstrongList.Count}");

        // Comparar y mostrar cuál lista tiene más elementos
        if (primeList.Count > armstrongList.Count)
        {
            Console.WriteLine("La lista de números primos contiene más elementos.");
        }
        else if (armstrongList.Count > primeList.Count)
        {
            Console.WriteLine("La lista de números Armstrong contiene más elementos.");
        }
        else
        {
            Console.WriteLine("Ambas listas contienen la misma cantidad de elementos.");
        }

        // Mostrar todos los datos insertados en las listas
        Console.WriteLine("Números primos:");
        primeList.Display();

        Console.WriteLine("Números Armstrong:");
        armstrongList.Display();
    }
}

