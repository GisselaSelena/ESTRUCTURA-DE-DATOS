using System;

namespace semana11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var diccionario = new Diccionario();
            var traductor = new Traductor(diccionario);

            while (true)
            {
                Console.WriteLine("==================== MENÚ ====================");
                Console.WriteLine("1. Traducir una frase");
                Console.WriteLine("2. Agregar palabras al diccionario");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                var opcion = Console.ReadLine();
                Console.WriteLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Frase ingresada: ");
                        var frase = Console.ReadLine() ?? "";
                        var traduccion = traductor.TraducirFrase(frase);
                        Console.WriteLine("Traducción (parcial): " + traduccion);
                        Console.WriteLine();
                        break;

                    case "2":
                        Console.Write("Ingrese la palabra en español: ");
                        var esp = Console.ReadLine() ?? "";
                        Console.Write("Ingrese la palabra en inglés: ");
                        var eng = Console.ReadLine() ?? "";

                        if (diccionario.AgregarPalabra(esp, eng))
                            Console.WriteLine("Palabra agregada correctamente.\n");
                        else
                            Console.WriteLine("No se pudo agregar la palabra (ya existe o entrada inválida).\n");
                        break;

                    case "0":
                        Console.WriteLine("Saliendo del programa...");
                        return;

                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.\n");
                        break;
                }
            }
        }
    }
}
