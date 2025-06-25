using System;
using System.Collections.Generic;
using System.Linq;

// Clase que representa un gestor de lotería
public class GestorLoteria
{
    private List<int> numerosGanadores;

    // Constructor
    public GestorLoteria()
    {
        numerosGanadores = new List<int>();
    }

    // Método para solicitar los números al usuario
    public void SolicitarNumeros()
    {
        Console.WriteLine("Introduce los 6 números ganadores de la Primitiva (entre 1 y 49):");
        
        for (int i = 1; i <= 6; i++)
        {
            while (true)
            {
                Console.Write($"Número {i}: ");
                string input = Console.ReadLine();
                
                if (int.TryParse(input, out int numero) && numero >= 1 && numero <= 49)
                {
                    if (!numerosGanadores.Contains(numero))
                    {
                        numerosGanadores.Add(numero);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("¡Este número ya fue introducido! Introduce uno diferente.");
                    }
                }
                else
                {
                    Console.WriteLine("¡Número inválido! Debe ser un entero entre 1 y 49.");
                }
            }
        }
    }

    // Método para ordenar los números
    public void OrdenarNumeros()
    {
        numerosGanadores.Sort();
    }

    // Método para mostrar los números ordenados
    public void MostrarNumeros()
    {
        Console.WriteLine("\nNúmeros ganadores ordenados:");
        Console.WriteLine($"{string.Join(", ", numerosGanadores)}");
    }
}