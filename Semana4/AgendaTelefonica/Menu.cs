using System;
using System.Collections.Generic;

public class Menu
{
    // Atributos
    private Agenda agenda;

    // Constructor
    public Menu()
    {
        agenda = new Agenda();
    }

    // Métodos
    public void IniciarPrograma()
    {
        Console.WriteLine("=== SISTEMA DE AGENDA TELEFÓNICA ===");
        Console.WriteLine("Universidad Estatal Amazónica");
        Console.WriteLine("Estructura de Datos - Práctica #01");
        Console.WriteLine(new string('=', 40));

        agenda.CargarDatosPrueba();
        Console.WriteLine("✅ 5 contactos de ejemplo cargados");

        bool continuar = true;
        while (continuar)
        {
            MostrarMenuPrincipal();
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarContacto();
                    break;
                case "2":
                    BuscarContacto();
                    break;
                case "3":
                    ModificarContacto();
                    break;
                case "4":
                    EliminarContacto();
                    break;
                case "5":
                    agenda.MostrarTodosLosContactos();
                    break;
                case "6":
                    agenda.MostrarEstadisticas();
                    break;
                case "7":
                    MostrarContactosPorCategoria();
                    break;
                case "8":
                    continuar = false;
                    Console.WriteLine("¡Gracias por usar la Agenda Telefónica!");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Seleccione del 1 al 8.");
                    break;
            }

            if (continuar)
            {
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    private void MostrarMenuPrincipal()
    {
        Console.WriteLine("\n=== MENÚ PRINCIPAL ===");
        Console.WriteLine("1. Agregar contacto");
        Console.WriteLine("2. Buscar contacto");
        Console.WriteLine("3. Modificar contacto");
        Console.WriteLine("4. Eliminar contacto");
        Console.WriteLine("5. Mostrar todos los contactos");
        Console.WriteLine("6. Ver estadísticas");
        Console.WriteLine("7. Ver contactos por categoría");
        Console.WriteLine("8. Salir");
        Console.Write("Seleccione una opción: ");
    }

    private void AgregarContacto()
    {
        Console.WriteLine("\n=== AGREGAR CONTACTO ===");
        
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
        
        string categoria = SeleccionarCategoria();

        bool resultado = agenda.AgregarContacto(nombre, apellido, telefono, email, direccion, categoria);

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
        Console.WriteLine("\n=== BUSCAR CONTACTO ===");
        Console.WriteLine("1. Buscar por nombre");
        Console.WriteLine("2. Buscar por teléfono");
        Console.Write("Seleccione opción: ");
        
        string opcion = Console.ReadLine();
        
        if (opcion == "1")
        {
            Console.Write("Ingrese nombre a buscar: ");
            string nombre = Console.ReadLine();
            var resultados = agenda.BuscarPorNombre(nombre);
            
            if (resultados.Count == 0)
            {
                Console.WriteLine("No se encontraron contactos con ese nombre.");
            }
            else
            {
                Console.WriteLine($"Se encontraron {resultados.Count} contacto(s):");
                foreach (var contacto in resultados)
                {
                    contacto.MostrarInformacion();
                    Console.WriteLine(new string('-', 30));
                }
            }
        }
        else if (opcion == "2")
        {
            Console.Write("Ingrese teléfono a buscar: ");
            string telefono = Console.ReadLine();
            var resultado = agenda.BuscarPorTelefono(telefono);
            
            if (resultado == null)
            {
                Console.WriteLine("No se encontró un contacto con ese teléfono.");
            }
            else
            {
                Console.WriteLine("Contacto encontrado:");
                resultado.MostrarInformacion();
            }
        }
    }

    private void ModificarContacto()
    {
        Console.WriteLine("\n=== MODIFICAR CONTACTO ===");
        Console.Write("Ingrese el teléfono del contacto a modificar: ");
        string telefono = Console.ReadLine();
        
        var contacto = agenda.BuscarPorTelefono(telefono);
        if (contacto == null)
        {
            Console.WriteLine("❌ No se encontró un contacto con ese teléfono.");
            return;
        }
        
        Console.WriteLine("Contacto actual:");
        contacto.MostrarInformacion();
        Console.WriteLine("\nIngrese los nuevos datos (presione Enter para mantener el valor actual):");
        
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
        if (cambiar?.ToLower() == "s")
        {
            nuevaCategoria = SeleccionarCategoria();
        }

        bool resultado = agenda.ModificarContacto(telefono, nuevoNombre, nuevoApellido, nuevoEmail, nuevaDireccion, nuevaCategoria);

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
        Console.WriteLine("\n=== ELIMINAR CONTACTO ===");
        Console.Write("Ingrese el teléfono del contacto a eliminar: ");
        string telefono = Console.ReadLine();
        
        var contacto = agenda.BuscarPorTelefono(telefono);
        if (contacto == null)
        {
            Console.WriteLine("❌ No se encontró un contacto con ese teléfono.");
            return;
        }
        
        Console.WriteLine("Contacto a eliminar:");
        contacto.MostrarInformacion();
        Console.Write("¿Está seguro de eliminarlo? (s/n): ");
        string confirmacion = Console.ReadLine();
        
        if (confirmacion?.ToLower() == "s")
        {
            bool resultado = agenda.EliminarContacto(telefono);
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
            Console.WriteLine("Eliminación cancelada.");
        }
    }

    private void MostrarContactosPorCategoria()
    {
        Console.WriteLine("\n=== CONTACTOS POR CATEGORÍA ===");
        string categoria = SeleccionarCategoria();
        var contactos = agenda.BuscarPorCategoria(categoria);
        
        if (contactos.Count == 0)
        {
            Console.WriteLine($"No hay contactos en la categoría '{categoria}'.");
        }
        else
        {
            Console.WriteLine($"\nContactos en la categoría '{categoria}' ({contactos.Count}):");
            foreach (var contacto in contactos)
            {
                contacto.MostrarInformacion();
                Console.WriteLine(new string('-', 30));
            }
        }
    }

    private string SeleccionarCategoria()
    {
        Console.WriteLine("Categorías disponibles:");
        string[] categorias = agenda.ObtenerCategorias();
        
        for (int i = 0; i < categorias.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {categorias[i]}");
        }
        
        Console.Write("Seleccione categoría (1-5): ");
        string opcion = Console.ReadLine();
        
        if (int.TryParse(opcion, out int indice) && indice >= 1 && indice <= 5)
        {
            return categorias[indice - 1];
        }
        
        return "Otros";
    }
} 