// Clase que representa la atracción
class Atraccion
{
    private Queue<Persona> colaEspera; // Cola que almacena las personas en espera
    private List<Persona> historial; // Lista que almacena el historial de personas atendidas
    private int capacidad; // Capacidad total de asientos de la atracción
    private int asientosDisponibles; // Asientos disponibles en la atracción
    private int contadorPersonas; // Contador para asignar el orden de llegada

    // Constructor que inicializa la atracción con una capacidad específica
    public Atraccion(int capacidad)
    {
        this.capacidad = capacidad; // Se asigna la capacidad
        asientosDisponibles = capacidad; // Inicialmente, todos los asientos están disponibles
        colaEspera = new Queue<Persona>(); // Se inicializa la cola de espera
        historial = new List<Persona>(); // Se inicializa el historial
        contadorPersonas = 0; // Se inicializa el contador de personas
    }

    // Método para agregar una persona a la cola
    public void AgregarPersona(string? nombre) // Permitir que nombre sea nullable
    {
        // Verificar que el nombre no sea nulo o vacío
        if (string.IsNullOrWhiteSpace(nombre))
        {
            Console.WriteLine("El nombre no puede estar vacío."); // Mensaje de error
            return; // Salir del método
        }

        // Verificar si hay asientos disponibles
        if (asientosDisponibles > 0)
        {
            contadorPersonas++; // Incrementar el contador de personas
            var persona = new Persona(nombre, contadorPersonas); // Crear una nueva persona
            colaEspera.Enqueue(persona); // Agregar la persona a la cola
            Console.WriteLine($"{persona.Nombre} (#{persona.OrdenLlegada}) se ha unido a la cola."); // Mensaje de confirmación
        }
        else
        {
            Console.WriteLine("¡ATENCIÓN! Todos los asientos están ocupados. No se puede agregar más personas."); // Mensaje de error
        }
    }

    // Método para que una persona suba a la atracción
    public void SubirPersona()
    {
        // Verificar si hay personas en la cola
        if (colaEspera.Count > 0)
        {
            var persona = colaEspera.Dequeue(); // Desencolar a la primera persona
            historial.Add(persona); // Agregar a la persona al historial
            asientosDisponibles--; // Reducir el número de asientos disponibles
            Console.WriteLine($"{persona.Nombre} (#{persona.OrdenLlegada}) ha subido a la atracción."); // Mensaje de confirmación
        }
        else
        {
            Console.WriteLine("No hay personas esperando actualmente."); // Mensaje de error
        }
    }

    // Método para mostrar el estado actual de la atracción
    public void MostrarEstado()
    {
        Console.WriteLine("\n=== REPORTE DE ESTADO ===");
        Console.WriteLine($"Asientos totales: {capacidad}"); // Mostrar capacidad total
        Console.WriteLine($"Asientos disponibles: {asientosDisponibles}"); // Mostrar asientos disponibles
        Console.WriteLine($"Personas en espera: {colaEspera.Count}"); // Mostrar número de personas en espera
        Console.WriteLine($"Personas atendidas: {historial.Count}\n"); // Mostrar número de personas atendidas
    }

    // Método para mostrar las personas en la cola de espera
    public void MostrarColaEspera()
    {
        Console.WriteLine("\n=== PERSONAS EN ESPERA ===");
        // Verificar si hay personas en la cola
        if (colaEspera.Any())
        {
            foreach (var persona in colaEspera) // Iterar sobre la cola
            {
                Console.WriteLine($"- {persona.Nombre} (Orden: #{persona.OrdenLlegada})"); // Mostrar cada persona
            }
        }
        else
        {
            Console.WriteLine("No hay personas en espera."); // Mensaje si no hay personas
        }
        Console.WriteLine();
    }

    // Método para mostrar el historial de atención
    public void MostrarHistorial()
    {
        Console.WriteLine("\n=== HISTORIAL DE ATENCIÓN ===");
        // Verificar si hay personas en el historial
        if (historial.Any())
        {
            foreach (var persona in historial) // Iterar sobre el historial
            {
                Console.WriteLine($"- {persona.Nombre} (Orden: #{persona.OrdenLlegada})"); // Mostrar cada persona atendida
            }
        }
        else
        {
            Console.WriteLine("No hay registro de personas atendidas aún."); // Mensaje si no hay historial
        }
        Console.WriteLine();
    }

    // Método para reiniciar la atracción
    public void ReiniciarAtraccion()
    {
        asientosDisponibles = capacidad; // Restablecer asientos disponibles
        colaEspera.Clear(); // Limpiar la cola de espera
        historial.Clear(); // Limpiar el historial
        contadorPersonas = 0; // Reiniciar el contador de personas
        Console.WriteLine("\n¡Atracción reiniciada! Todos los asientos están disponibles.\n"); // Mensaje de confirmación
    }
}


