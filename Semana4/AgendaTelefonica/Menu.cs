using System;
using System.Collections.Generic;

public class Menu
{
    // Atributos
    private Agenda agenda; // Instancia de la clase Agenda para gestionar los contactos

    // Constructor
    public Menu()
    {
        agenda = new Agenda(); // Inicializa la agenda al crear un nuevo menú
    }

    // Métodos
    public void IniciarPrograma()
    {
        // Muestra la cabecera del programa
        Console.WriteLine("=== SISTEMA DE AGENDA TELEFÓNICA ===");
        Console.WriteLine("Universidad Estatal Amazónica");
        Console.WriteLine("Estructura de Datos - Práctica #01");
        Console.WriteLine(new string('=', 40));

        // Carga datos de prueba en la agenda
        agenda.CargarDatosPrueba();
        Console.WriteLine("✅ 5 contactos de ejemplo cargados");

        bool continuar = true; // Variable para controlar el bucle del menú
        while (continuar)
        {
            MostrarMenuPrincipal(); // Muestra el menú principal
            string opcion = Console.ReadLine(); // Lee la opción seleccionada por el usuario

            // Procesa la opción seleccionada
            switch (opcion)
            {
                case "1":
                    AgregarContacto(); // Llama al método para agregar un contacto
                    break;
                case "2":
                    BuscarContacto(); // Llama al método para buscar un contacto
                    break;
                case "3":
                    ModificarContacto(); // Llama al método para modificar un contacto
                    break;
                case "4":
                    EliminarContacto(); // Llama al método para eliminar un contacto
                    break;
                case "5":
                    agenda.MostrarTodosLosContactos(); // Muestra todos los contactos
                    break;
                case "6":
                    agenda.MostrarEstadisticas(); // Muestra estadísticas de la agenda
                    break;
                case "7":
                    MostrarContactosPorCategoria(); // Muestra contactos por categoría
                    break;
                case "8":
                    continuar = false; // Termina el bucle y sale del programa
                    Console.WriteLine("¡Gracias por usar la Agenda Telefónica!");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Seleccione del 1 al 8."); // Mensaje de error para opción no válida
                    break;
            }

            // Espera a que el usuario presione una tecla antes de continuar
            if (continuar)
            {
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear(); // Limpia la consola
            }
        }
    }

    private void MostrarMenuPrincipal()
    {
        // Muestra las opciones del menú principal
        Console.WriteLine("\n=== MENÚ PRINCIPAL ===");
        Console.WriteLine("1. Agregar contacto");
        Console.WriteLine("2. Buscar contacto");
        Console.WriteLine("3. Modificar contacto");
        Console.WriteLine("4. Eliminar contacto");
        Console.WriteLine("5. Mostrar todos los contactos");
        Console.WriteLine("6. Ver estadísticas");
        Console.WriteLine("7. Ver contactos por categoría");
        Console.WriteLine("8. Salir");
        Console.Write("Seleccione una opción: "); // Solicita al usuario que seleccione una opción
    }

    private void AgregarContacto()
    {
        // Muestra la sección para agregar un nuevo contacto
        Console.WriteLine("\n=== AGREGAR CONTACTO ===");
        
        // Solicita los datos del nuevo contacto
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        
        Console.Write("Apellido: ");
        string apellido = Console.ReadLine();
        
        Console.Write("Teléfono: ");
        string telefono = Console.ReadLine();
        
        Console.Write("Email: ");
        string email = Console.ReadLine();
        
        Console.Write("Dirección: ");
        string direccion = Console.ReadLine();
        
        string categoria = SeleccionarCategoria(); // Llama al método para seleccionar la categoría

        // Intenta agregar el contacto a la agenda
        bool resultado = agenda.AgregarContacto(nombre, apellido, telefono, email, direccion, categoria);

        // Muestra el resultado de la operación
        if (resultado)
        {
            Console.WriteLine($"✅ Contacto {nombre} {apellido} agregado exitosamente.");
        }
        else
        {
            Console.WriteLine("❌ Error al agregar contacto. Verifique los datos o si el teléfono ya existe.");
        }
    }

    private void BuscarContacto()
    {
        // Muestra la sección para buscar un contacto
        Console.WriteLine("\n=== BUSCAR CONTACTO ===");
        Console.WriteLine("1. Buscar por nombre");
        Console.WriteLine("2. Buscar por teléfono");
        Console.Write("Seleccione opción: ");
        
        string opcion = Console.ReadLine(); // Lee la opción seleccionada
        
        // Busca por nombre
        if (opcion == "1")
        {
            Console.Write("Ingrese nombre a buscar: ");
            string nombre = Console.ReadLine();
            var resultados = agenda.BuscarPorNombre(nombre); // Llama al método para buscar por nombre
            
            // Muestra los resultados de la búsqueda
            if (resultados.Count == 0)
            {
                Console.WriteLine("No se encontraron contactos con ese nombre.");
            }
            else
            {
                Console.WriteLine($"Se encontraron {resultados.Count} contacto(s):");
                foreach (var contacto in resultados)
                {
                    contacto.MostrarInformacion(); // Muestra la información de cada contacto encontrado
                    Console.WriteLine(new string('-', 30)); // Línea separadora
                }
            }
        }
        // Busca por teléfono
        else if (opcion == "2")
        {
            Console.Write("Ingrese teléfono a buscar: ");
            string telefono = Console.ReadLine();
            var resultado = agenda.BuscarPorTelefono(telefono); // Llama al método para buscar por teléfono
            
            // Muestra el resultado de la búsqueda
            if (resultado == null)
            {
                Console.WriteLine("No se encontró un contacto con ese teléfono.");
            }
            else
            {
                Console.WriteLine("Contacto encontrado:");
                resultado.MostrarInformacion(); // Muestra la información del contacto encontrado
            }
        }
    }

    private void ModificarContacto()
    {
        // Muestra la sección para modificar un contacto
        Console.WriteLine("\n=== MODIFICAR CONTACTO ===");
        Console.Write("Ingrese el teléfono del contacto a modificar: ");
        string telefono = Console.ReadLine();
        
        var contacto = agenda.BuscarPorTelefono(telefono); // Busca el contacto por teléfono
        if (contacto == null)
        {
            Console.WriteLine("❌ No se encontró un contacto con ese teléfono.");
            return; // Sale del método si no se encuentra el contacto
        }
        
        Console.WriteLine("Contacto actual:");
        contacto.MostrarInformacion(); // Muestra la información del contacto actual
        Console.WriteLine("\nIngrese los nuevos datos (presione Enter para mantener el valor actual):");
        
        // Solicita los nuevos datos del contacto
        Console.Write($"Nombre ({contacto.Nombre}): ");
        string nuevoNombre = Console.ReadLine();
        
        Console.Write($"Apellido ({contacto.Apellido}): ");
        string nuevoApellido = Console.ReadLine();
        
        Console.Write($"Email ({contacto.Email}): ");
        string nuevoEmail = Console.ReadLine();
        
        Console.Write($"Dirección ({contacto.Direccion}): ");
        string nuevaDireccion = Console.ReadLine();
        
        Console.WriteLine($"Categoría actual: {contacto.Categoria}");
        Console.Write("¿Desea cambiar la categoría? (s/n): ");
        string cambiar = Console.ReadLine();
        
        string nuevaCategoria = null;
        if (cambiar?.ToLower() == "s") // Si el usuario desea cambiar la categoría
        {
            nuevaCategoria = SeleccionarCategoria(); // Llama al método para seleccionar la nueva categoría
        }

        // Intenta modificar el contacto en la agenda
        bool resultado = agenda.ModificarContacto(telefono, nuevoNombre, nuevoApellido, nuevoEmail, nuevaDireccion, nuevaCategoria);

        // Muestra el resultado de la operación
        if (resultado)
        {
            Console.WriteLine("✅ Contacto modificado exitosamente.");
        }
        else
        {
            Console.WriteLine("❌ Error al modificar el contacto.");
        }
    }

    private void EliminarContacto()
    {
        // Muestra la sección para eliminar un contacto
        Console.WriteLine("\n=== ELIMINAR CONTACTO ===");
        Console.Write("Ingrese el teléfono del contacto a eliminar: ");
        string telefono = Console.ReadLine();
        
        var contacto = agenda.BuscarPorTelefono(telefono); // Busca el contacto por teléfono
        if (contacto == null)
        {
            Console.WriteLine("❌ No se encontró un contacto con ese teléfono.");
            return; // Sale del método si no se encuentra el contacto
        }
        
        Console.WriteLine("Contacto a eliminar:");
        contacto.MostrarInformacion(); // Muestra la información del contacto a eliminar
        Console.Write("¿Está seguro de eliminarlo? (s/n): ");
        string confirmacion = Console.ReadLine();
        
        if (confirmacion?.ToLower() == "s") // Si el usuario confirma la eliminación
        {
            bool resultado = agenda.EliminarContacto(telefono); // Intenta eliminar el contacto
            if (resultado)
            {
                Console.WriteLine("✅ Contacto eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("❌ Error al eliminar el contacto.");
            }
        }
        else
        {
            Console.WriteLine("Eliminación cancelada."); // Mensaje si se cancela la eliminación
        }
    }

    private void MostrarContactosPorCategoria()
    {
        // Muestra la sección para ver contactos por categoría
        Console.WriteLine("\n=== CONTACTOS POR CATEGORÍA ===");
        string categoria = SeleccionarCategoria(); // Llama al método para seleccionar la categoría
        var contactos = agenda.BuscarPorCategoria(categoria); // Busca contactos en la categoría seleccionada
        
        // Muestra los resultados de la búsqueda
        if (contactos.Count == 0)
        {
            Console.WriteLine($"No hay contactos en la categoría '{categoria}'.");
        }
        else
        {
            Console.WriteLine($"\nContactos en la categoría '{categoria}' ({contactos.Count}):");
            foreach (var contacto in contactos)
            {
                contacto.MostrarInformacion(); // Muestra la información de cada contacto encontrado
                Console.WriteLine(new string('-', 30)); // Línea separadora
            }
        }
    }

    private string SeleccionarCategoria()
    {
        // Muestra las categorías disponibles y permite al usuario seleccionar una
        Console.WriteLine("Categorías disponibles:");
        string[] categorias = agenda.ObtenerCategorias(); // Obtiene las categorías de la agenda
        
        for (int i = 0; i < categorias.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {categorias[i]}"); // Muestra cada categoría con su índice
        }
        
        Console.Write("Seleccione categoría (1-5): ");
        string opcion = Console.ReadLine(); // Lee la opción seleccionada
        
        // Verifica si la opción es válida y retorna la categoría seleccionada
        if (int.TryParse(opcion, out int indice) && indice >= 1 && indice <= 5)
        {
            return categorias[indice - 1];
        }
        
        return "Otros"; // Retorna "Otros" si la opción no es válida
    }
}
