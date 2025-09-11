using System;
using System.Collections.Generic;

namespace CatalogoRevistasApp
{
    // Clase que representa el catálogo de revistas
    public class CatalogoRevistas
    {
        // Lista que almacena los títulos de las revistas
        private List<string> titulos;

        // Constructor que inicializa la lista con algunos títulos
        public CatalogoRevistas()
        {
            titulos = new List<string>()
            {
                "National Geographic",
                "Time",
                "Forbes",
                "Vogue",
                "Scientific American",
                "The Economist",
                "Wired",
                "Popular Science",
                "Reader's Digest",
                "Harper's Bazaar"
            };
        }

        // Método público para buscar un título usando búsqueda recursiva
        public bool BuscarTitulo(string titulo)
        {
            return BuscarRecursivo(titulo, 0);
        }

        // Método privado recursivo que busca el título en la lista
        private bool BuscarRecursivo(string titulo, int indice)
        {
            if (indice >= titulos.Count)
                return false;

            if (string.Equals(titulos[indice], titulo, StringComparison.OrdinalIgnoreCase))
                return true;

            return BuscarRecursivo(titulo, indice + 1);
        }

        // Método para mostrar todos los títulos del catálogo
        public void MostrarCatalogo()
        {
            Console.WriteLine("Catálogo de revistas:");
            foreach (var titulo in titulos)
            {
                Console.WriteLine("- " + titulo);
            }
        }
    }
}

