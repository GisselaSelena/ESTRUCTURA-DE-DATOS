using System;
using PalindromoChecker;// Clase principal
class Program
{
    static void Main(string[] args)
    {
        // Crear una instancia del verificador de palíndromos
        VerificadorPalindromo verificador = new VerificadorPalindromo();

        // Solicitar al usuario una palabra
        Console.Write("Introduce una palabra: ");
        string palabra = Console.ReadLine();

        // Verificar si es un palíndromo
        if (verificador.EsPalindromo(palabra))
        {
            Console.WriteLine($"La palabra '{palabra}' es un palíndromo.");
        }
        else
        {
            Console.WriteLine($"La palabra '{palabra}' no es un palíndromo.");
        }
    }
}