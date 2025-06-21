using System;
using System.Collections.Generic;
using System.Linq;

public class Agenda
{
    // Atributos - Estructuras de datos
    private List<Contacto> contactos; // Lista para almacenar los contactos
    private string[] categorias; // Array de categorías predefinidas
    private int[,] estadisticas; // Matriz para almacenar estadísticas de contactos por categoría
    private int[] contadores; // Vector para contar la cantidad de contactos por categoría
    private int contadorId; // Contador para asignar IDs únicos a los contactos

    // Constructor de la clase Agenda
    public Agenda()
    {
        contactos = new List<Contacto>(); // Inicializa la lista de contactos
        categorias = new string[] { "Familia", "Trabajo", "Amigos", "Servicios", "Otros" }; // Define las categorías
        estadisticas = new int[5, 2]; // Inicializa la matriz de estadísticas (5 categorías x 2 columnas)
        contadores = new int[5]; // Inicializa el vector de contadores
        contadorId = 1; // Inicializa el contador de IDs
        InicializarEstadisticas(); // Llama al método para inicializar las estadísticas
    }

    // Métodos privados
    private void InicializarEstadisticas()
    {
        // Inicializa las estadísticas y contadores para cada categoría
        for (int i = 0; i < categorias.Length; i++)
        {
            estadisticas[i, 0] = i; // Asigna el índice de la categoría
            estadisticas[i, 1] = 0; // Inicializa la cantidad de contactos en 0
            contadores[i] = 0; // Inicializa el contador de contactos en 0
        }
    }

    private void ActualizarEstadisticas(string categoria, int cambio)
    {
        // Actualiza las estadísticas de la categoría especificada
        for (int i = 0; i < categorias.Length; i++)
        {
            if (categorias[i] == categoria)
            {
                contadores[i] += cambio; // Incrementa o decrementa el contador
                estadisticas[i, 1] = contadores[i]; // Actualiza la matriz de estadísticas
                break; // Sale del bucle una vez que se encuentra la categoría
            }
        }
    }

    private bool ExisteTelefono(string telefono)
    {
        // Verifica si ya existe un contacto con el mismo número de teléfono
        foreach (var contacto in contactos)
        {
            if (contacto.Telefono == telefono)
                return true; // Retorna true si se encuentra un contacto con el mismo teléfono
        }
        return false; // Retorna false si no se encuentra
    }

    // Métodos públicos CRUD (Crear, Leer, Actualizar, Eliminar)
    public bool AgregarContacto(string nombre, string apellido, string telefono, string email, string direccion, string categoria)
    {
        // Verifica que el nombre y el teléfono no estén vacíos
        if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(telefono))
            return false; // Retorna false si faltan datos

        // Verifica si el teléfono ya existe
        if (ExisteTelefono(telefono))
            return false; // Retorna false si el teléfono ya está en uso

        // Si la categoría no es válida, se asigna "Otros"
        if (!categorias.Contains(categoria))
            categoria = "Otros";

        // Crea un nuevo contacto y lo agrega a la lista
        Contacto nuevoContacto = new Contacto(contadorId++, nombre, apellido, telefono, email, direccion, categoria);
        contactos.Add(nuevoContacto);
        ActualizarEstadisticas(categoria, 1); // Actualiza las estadísticas de la categoría
        return true; // Retorna true si se agrega el contacto exitosamente
    }

    public List<Contacto> BuscarPorNombre(string nombre)
    {
        // Busca contactos que contengan el nombre o apellido especificado
        List<Contacto> resultados = new List<Contacto>();
        foreach (var contacto in contactos)
        {
            if (contacto.Nombre.ToLower().Contains(nombre.ToLower()) || 
                contacto.Apellido.ToLower().Contains(nombre.ToLower()))
            {
                resultados.Add(contacto); // Agrega el contacto a los resultados si coincide
            }
        }
        return resultados; // Retorna la lista de contactos encontrados
    }

    public Contacto BuscarPorTelefono(string telefono)
    {
        // Busca un contacto por su número de teléfono
        foreach (var contacto in contactos)
        {
            if (contacto.Telefono == telefono)
                return contacto; // Retorna el contacto si se encuentra
        }
        return null; // Retorna null si no se encuentra
    }

    public List<Contacto> BuscarPorCategoria(string categoria)
    {
        // Busca contactos que pertenecen a una categoría específica
        List<Contacto> resultados = new List<Contacto>();
        foreach (var contacto in contactos)
        {
            if (contacto.Categoria == categoria)
                resultados.Add(contacto); // Agrega el contacto a los resultados si coincide
        }
        return resultados; // Retorna la lista de contactos encontrados
    }

    public bool ModificarContacto(string telefono, string nuevoNombre, string nuevoApellido, string nuevoEmail, string nuevaDireccion, string nuevaCategoria)
    {
        // Modifica los datos de un contacto existente
        for (int i = 0; i < contactos.Count; i++)
        {
            if (contactos[i].Telefono == telefono)
            {
                var contacto = contactos[i]; // Obtiene el contacto a modificar
                string categoriaAnterior = contacto.Categoria; // Guarda la categoría anterior

                // Actualiza los datos del contacto si se proporcionan nuevos valores
                if (!string.IsNullOrEmpty(nuevoNombre))
                    contacto.Nombre = nuevoNombre;
                if (!string.IsNullOrEmpty(nuevoApellido))
                    contacto.Apellido = nuevoApellido;
                if (!string.IsNullOrEmpty(nuevoEmail))
                    contacto.Email = nuevoEmail;
                if (!string.IsNullOrEmpty(nuevaDireccion))
                    contacto.Direccion = nuevaDireccion;
                if (!string.IsNullOrEmpty(nuevaCategoria))
                {
                    contacto.Categoria = nuevaCategoria; // Actualiza la categoría
                    ActualizarEstadisticas(categoriaAnterior, -1); // Decrementa el contador de la categoría anterior
                    ActualizarEstadisticas(nuevaCategoria, 1); // Incrementa el contador de la nueva categoría
                }

                return true; // Retorna true si se modifica el contacto exitosamente
            }
        }
        return false; // Retorna false si no se encuentra el contacto
    }

    public bool EliminarContacto(string telefono)
    {
        // Elimina un contacto por su número de teléfono
        for (int i = 0; i < contactos.Count; i++)
        {
            if (contactos[i].Telefono == telefono)
            {
                ActualizarEstadisticas(contactos[i].Categoria, -1); // Decrementa el contador de la categoría
                contactos.RemoveAt(i); // Elimina el contacto de la lista
                return true; // Retorna true si se elimina el contacto exitosamente
            }
        }
        return false; // Retorna false si no se encuentra el contacto
    }

    // Métodos de consulta
    public void MostrarTodosLosContactos()
    {
        // Muestra todos los contactos en la agenda
        if (contactos.Count == 0)
        {
            Console.WriteLine("La agenda está vacía."); // Mensaje si no hay contactos
            return;
        }

        Console.WriteLine($"\n=== AGENDA TELEFÓNICA ({contactos.Count} contactos) ===");
        foreach (var contacto in contactos.OrderBy(c => c.Apellido))
        {
            contacto.MostrarInformacion(); // Muestra la información de cada contacto
            Console.WriteLine(new string('-', 50)); // Línea separadora
        }
    }

    public void MostrarEstadisticas()
    {
        // Muestra estadísticas de la agenda
        Console.WriteLine("\n=== ESTADÍSTICAS DE LA AGENDA ===");
        Console.WriteLine($"Total de contactos: {contactos.Count}"); // Muestra el total de contactos
        Console.WriteLine("\nContactos por categoría:");
        
        for (int i = 0; i < categorias.Length; i++)
        {
            Console.WriteLine($"{categorias[i]}: {estadisticas[i, 1]} contactos"); // Muestra la cantidad de contactos por categoría
        }

        if (contactos.Count > 0)
        {
            var ultimoContacto = contactos.OrderByDescending(c => c.FechaRegistro).First(); // Obtiene el último contacto agregado
            Console.WriteLine($"\nÚltimo contacto agregado: {ultimoContacto.NombreCompleto()}"); // Muestra el nombre completo del último contacto
        }
    }

    public string[] ObtenerCategorias()
    {
        // Retorna las categorías disponibles
        return categorias;
    }

    public int TotalContactos()
    {
        // Retorna el total de contactos en la agenda
        return contactos.Count;
    }

    public void CargarDatosPrueba()
    {
        // Carga datos de prueba en la agenda
        AgregarContacto("Juan", "Pérez", "0987654321", "juan.perez@hotmail.com", "Av. Principal 123", "Trabajo");
        AgregarContacto("María", "González", "0912345678", "maria.gonzalez@outlook.com", "Calle Secundaria 456", "Familia");
        AgregarContacto("Carlos", "Rodríguez", "0923456789", "carlos.rodriguez@gmail.com", "Barrio Centro 789", "Amigos");
        AgregarContacto("Ana", "Quishpe", "0934567890", "ana.quishpe@gmail.com", "Urbanización Norte 321", "Servicios");
        AgregarContacto("Pedro", "Martínez", "0945678901", "pedro.martinez@live.com", "Sector Sur 654", "Otros");
    }
}
