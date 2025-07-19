// Clase principal que contiene el método Main
class Program
{
    static void Main(string[] args)
    {
        Atraccion atraccion = new Atraccion(30); // Crear una nueva atracción con capacidad para 30 personas
        bool running = true; // Variable para controlar el bucle del menú

        // Bucle principal del menú
        while (running)
        {
            Console.WriteLine("==== SISTEMA DE GESTIÓN DE ATRACCIÓN ====");
            Console.WriteLine("1. Agregar persona a la cola");
            Console.WriteLine("2. Subir persona a la atracción");
            Console.WriteLine("3. Ver estado actual");
            Console.WriteLine("4. Ver cola de espera");
            Console.WriteLine("5. Ver historial de atención");
            Console.WriteLine("6. Reiniciar atracción");
            Console.WriteLine("7. Salir");
            Console.Write("Seleccione una opción: ");

            // Leer la opción seleccionada por el usuario
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Ingrese nombre de la persona: ");
                    string? nombre = Console.ReadLine(); // Permitir que nombre sea nullable
                    atraccion.AgregarPersona(nombre); // Agregar persona a la cola
                    break;
                case "2":
                    atraccion.SubirPersona(); // Subir persona a la atracción
                    break;
                case "3":
                    atraccion.MostrarEstado(); // Mostrar estado actual de la atracción
                    break;
                case "4":
                    atraccion.MostrarColaEspera(); // Mostrar cola de espera
                    break;
                case "5":
                    atraccion.MostrarHistorial(); // Mostrar historial de atención
                    break;
                case "6":
                    atraccion.ReiniciarAtraccion(); // Reiniciar la atracción
                    break;
                case "7":
                    running = false; // Salir del bucle
                    break;
                default:
                    Console.WriteLine("Opción no válida."); // Mensaje de error para opción no válida
                    break;
            }

            Console.WriteLine("Presione cualquier tecla para continuar..."); // Mensaje para continuar
            Console.ReadKey(); // Esperar a que el usuario presione una tecla
            Console.Clear(); // Limpiar la consola
        }
    }
}