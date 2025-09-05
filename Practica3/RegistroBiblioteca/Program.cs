using System;
using System.Diagnostics;

namespace RegistroBiblioteca
{
    class Program
    {
        static void Main(string[] args)
        {
            var biblioteca = new Biblioteca();
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            string? opcion;
            do
            {
                // Menú de opciones para el usuario
                Console.WriteLine("\nSeleccione una opción:");
                Console.WriteLine("1 - Agregar libro");
                Console.WriteLine("2 - Mostrar todos los libros");
                Console.WriteLine("3 - Buscar libro por título");
                Console.WriteLine("4 - Buscar libro por autor");
                Console.WriteLine("5 - Buscar libro por ISBN"); // Búsqueda directa con mapa
                Console.WriteLine("6 - Salir");
                Console.Write("Opción: ");
                opcion = Console.ReadLine()?.Trim();

                switch (opcion)
                {
                    case "1":
                        // Solicita datos para crear un nuevo libro
                        Console.WriteLine("\nIngrese los datos del libro:");

                        Console.Write("Título: ");
                        string? titulo = Console.ReadLine();

                        Console.Write("Autor: ");
                        string? autor = Console.ReadLine();

                        Console.Write("ISBN (sin guiones si es posible): ");
                        string? isbn = Console.ReadLine();

                        Console.Write("Año de publicación: ");
                        int anio;
                        while (!int.TryParse(Console.ReadLine(), out anio))
                            Console.Write("Por favor ingrese un número válido para el año: ");

                        var nuevoLibro = new Libro(titulo ?? "", autor ?? "", isbn ?? "", anio);

                        // Intenta agregar el libro y muestra resultado
                        Console.WriteLine(biblioteca.AgregarLibro(nuevoLibro)
                            ? "Libro agregado correctamente."
                            : "No se pudo agregar: ISBN duplicado/ inválido o año fuera de rango.");
                        break;

                    case "2":
                        // Muestra todos los libros registrados
                        biblioteca.MostrarLibros();
                        break;

                    case "3":
                        // Busca libros por título
                        Console.Write("Ingrese título a buscar: ");
                        biblioteca.BuscarPorTitulo(Console.ReadLine());
                        break;

                    case "4":
                        // Busca libros por autor
                        Console.Write("Ingrese autor a buscar: ");
                        biblioteca.BuscarPorAutor(Console.ReadLine());
                        break;

                    case "5":
                        // Busca libro por ISBN usando el diccionario
                        Console.Write("Ingrese ISBN a buscar: ");
                        var libro = biblioteca.BuscarPorISBN(Console.ReadLine());
                        Console.WriteLine(libro != null ? libro.ToString() : "No se encontró un libro con ese ISBN.");
                        break;

                    case "6":
                        Console.WriteLine("Saliendo...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

            } while (opcion != "6");

            stopwatch.Stop();
            Console.WriteLine($"\nTiempo de ejecución: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}




