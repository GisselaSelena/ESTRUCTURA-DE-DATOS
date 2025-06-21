using System;

class Program
{
    // Método principal que se ejecuta al iniciar el programa
    static void Main(string[] args)
    {
        // Muestra el encabezado del programa
        Console.WriteLine("2025 - ESTRUCTURA DE DATOS - UEA / AGENDA TELEFÓNICA");
        Console.WriteLine(); // Línea en blanco para separar el encabezado del resto de la salida

        try
        {
            // Crea una instancia de la clase Menu
            Menu menu = new Menu();
            // Llama al método para iniciar el programa de la agenda
            menu.IniciarPrograma();
        }
        catch (Exception ex)
        {
            // Captura cualquier excepción que ocurra y muestra un mensaje de error
            Console.WriteLine($"Error: {ex.Message}");
        }

        // Mensaje para indicar al usuario que puede salir del programa
        Console.WriteLine("\nPresione cualquier tecla para salir...");
        Console.ReadKey(); // Espera a que el usuario presione una tecla antes de cerrar
    }
}

