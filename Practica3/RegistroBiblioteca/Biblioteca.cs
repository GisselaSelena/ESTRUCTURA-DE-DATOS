using System;
using System.Collections.Generic;
using System.Linq;

namespace RegistroBiblioteca
{
    public class Biblioteca
    {
        // Conjunto para almacenar libros sin duplicados (según ISBN)
        private readonly HashSet<Libro> libros = new(new ComparadorLibro());

        // Diccionario para acceso rápido a libros por ISBN (clave → valor)
        private readonly Dictionary<string, Libro> indiceISBN = new();

        // Agrega un libro si es válido y no existe duplicado
        public bool AgregarLibro(Libro? libro)
        {
            if (libro == null) return false;

            var key = Libro.NormalizarISBN(libro.ISBN);
            if (string.IsNullOrEmpty(key)) return false; // ISBN inválido

            // Validación del año (desde invención de la imprenta hasta próximo año)
            if (libro.Anio < 1450 || libro.Anio > DateTime.Now.Year + 1) return false;

            // Evita duplicados usando el diccionario
            if (indiceISBN.ContainsKey(key)) return false;

            // Agrega al conjunto y al diccionario
            var agregado = libros.Add(libro);
            if (agregado) indiceISBN[key] = libro;

            return agregado;
        }

        // Muestra todos los libros ordenados por título (sin distinguir mayúsculas)
        public void MostrarLibros()
        {
            if (libros.Count == 0)
            {
                Console.WriteLine("No hay libros registrados.");
                return;
            }

            Console.WriteLine("\n--- Libros registrados (ordenados por título) ---");
            foreach (var libro in libros.OrderBy(l => l.Titulo, StringComparer.OrdinalIgnoreCase))
                Console.WriteLine(libro);
        }

        // Busca libros cuyo título contenga el texto dado (insensible a mayúsculas)
        public void BuscarPorTitulo(string? titulo)
        {
            titulo = (titulo ?? "").Trim();

            var resultados = libros
                .Where(l => l.Titulo?.IndexOf(titulo, StringComparison.OrdinalIgnoreCase) >= 0)
                .OrderBy(l => l.Titulo, StringComparer.OrdinalIgnoreCase)
                .ToList();

            if (resultados.Count == 0)
            {
                Console.WriteLine($"No se encontraron libros con título que contenga \"{titulo}\".");
                return;
            }

            Console.WriteLine($"Libros encontrados ({resultados.Count}):");
            resultados.ForEach(l => Console.WriteLine(l));
        }

        // Busca libros cuyo autor contenga el texto dado (insensible a mayúsculas)
        public void BuscarPorAutor(string? autor)
        {
            autor = (autor ?? "").Trim();

            var resultados = libros
                .Where(l => l.Autor?.IndexOf(autor, StringComparison.OrdinalIgnoreCase) >= 0)
                .OrderBy(l => l.Autor, StringComparer.OrdinalIgnoreCase)
                .ThenBy(l => l.Titulo, StringComparer.OrdinalIgnoreCase)
                .ToList();

            if (resultados.Count == 0)
            {
                Console.WriteLine($"No se encontraron libros con autor que contenga \"{autor}\".");
                return;
            }

            Console.WriteLine($"Libros encontrados ({resultados.Count}):");
            resultados.ForEach(l => Console.WriteLine(l));
        }

        // Consulta directa por ISBN usando el diccionario (mapa)
        public Libro? BuscarPorISBN(string? isbn)
        {
            var key = Libro.NormalizarISBN(isbn);
            return indiceISBN.TryGetValue(key, out var libro) ? libro : null;
        }
    }
}


