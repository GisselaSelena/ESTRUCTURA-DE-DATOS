using System;

namespace CatalogoRevistasApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CatalogoRevistas catalogo = new CatalogoRevistas();
            bool salir = false;

            Console.WriteLine("=== Gestión de Catálogo de Revistas ===");

            while (!salir)
            {
                Console.WriteLine("\nMenú:");
                Console.WriteLine("1. Mostrar catálogo");
                Console.WriteLine("2. Buscar título");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción (1-3): ");

                string? opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        catalogo.MostrarCatalogo();
                        break;

                    case "2":
                        Console.Write("Ingrese el título a buscar: ");
                        string? tituloBuscado = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(tituloBuscado))
                        {
                            Console.WriteLine("Debe ingresar un título válido.");
                            break;
                        }

                        bool encontrado = catalogo.BuscarTitulo(tituloBuscado);

                        if (encontrado)
                            Console.WriteLine("✅ Encontrado");
                        else
                            Console.WriteLine("❌ No encontrado");
                        break;

                    case "3":
                        salir = true;
                        Console.WriteLine("Saliendo de la aplicación...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }
            }
        }
    }
}
