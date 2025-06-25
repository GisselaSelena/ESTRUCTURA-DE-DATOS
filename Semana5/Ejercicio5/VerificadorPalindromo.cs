using System;

namespace PalindromoChecker;
    // Clase que representa un verificador de palíndromos
    public class VerificadorPalindromo
    {
        // Método para verificar si una palabra es un palíndromo
        public bool EsPalindromo(string palabra)
        {
            // Normalizar la palabra: quitar espacios y convertir a minúsculas
            string palabraNormalizada = palabra.Replace(" ", "").ToLower();
            // Invertir la palabra
            char[] arrayPalabra = palabraNormalizada.ToCharArray();
            Array.Reverse(arrayPalabra);
            string palabraInvertida = new string(arrayPalabra);

            // Comparar la palabra normalizada con la invertida
            return palabraNormalizada == palabraInvertida;
        }
    }

    
