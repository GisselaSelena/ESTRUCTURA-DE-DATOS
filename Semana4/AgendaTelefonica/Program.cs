using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("2025 - ESTRUCTURA DE DATOS - UEA / AGENDA TELEFÓNICA");
        Console.WriteLine();

        try
        {
            Menu menu = new Menu();
            menu.IniciarPrograma();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("\nPresione cualquier tecla para salir...");
        Console.ReadKey();
    }
}
