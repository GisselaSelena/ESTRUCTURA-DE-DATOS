using System;
using System.Collections.Generic;

namespace NumerosInversos
{
    // Clase que representa un Gestor de Números
    public class GestorNumeros
    {
        // Lista para almacenar los números
        private List<int> numeros;

        // Constructor que inicializa la lista y la llena con números del 1 al 10
        public GestorNumeros()
        {
            numeros = new List<int>();
            LlenarNumeros();
        }

        // Método para llenar la lista con números del 1 al 10
        private void LlenarNumeros()
        {
            for (int i = 1; i <= 10; i++)
            {
                numeros.Add(i);
            }
        }

        // Método para mostrar los números en orden inverso
        public void MostrarNumerosInversos()
        {
            Console.WriteLine("Números del 1 al 10 en orden inverso:");
            Console.WriteLine(string.Join(", ", numeros.AsReadOnly().Reverse()));
        }
    }
}