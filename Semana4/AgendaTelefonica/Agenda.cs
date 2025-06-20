using System;
using System.Collections.Generic;
using System.Linq;

public class Agenda
{
    // Atributos - Estructuras de datos
    private List<Contacto> contactos;
    private string[] categorias;
    private int[,] estadisticas; // Matriz para estadísticas
    private int[] contadores; // Vector para contadores
    private int contadorId;

    // Constructor
    public Agenda()
    {
        contactos = new List<Contacto>();
        categorias = new string[] { "Familia", "Trabajo", "Amigos", "Servicios", "Otros" };
        estadisticas = new int[5, 2]; // 5 categorías x 2 columnas
        contadores = new int[5];
        contadorId = 1;
        InicializarEstadisticas();
    }

    // Métodos privados
    private void InicializarEstadisticas()
    {
        for (int i = 0; i < categorias.Length; i++)
        {
            estadisticas[i, 0] = i; // Índice de categoría
            estadisticas[i, 1] = 0; // Cantidad inicial
            contadores[i] = 0;
        }
    }

    private void ActualizarEstadisticas(string categoria, int cambio)
    {
        for (int i = 0; i < categorias.Length; i++)
        {
            if (categorias[i] == categoria)
            {
                contadores[i] += cambio;
                estadisticas[i, 1] = contadores[i];
                break;
            }
        }
    }

    private bool ExisteTelefono(string telefono)
    {
        foreach (var contacto in contactos)
        {
            if (contacto.Telefono == telefono)
                return true;
        }
        return false;
    }

    // Métodos públicos CRUD
    public bool AgregarContacto(string nombre, string apellido, string telefono, string email, string direccion, string categoria)
    {
        if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(telefono))
            return false;

        if (ExisteTelefono(telefono))
            return false;

        if (!categorias.Contains(categoria))
            categoria = "Otros";

        Contacto nuevoContacto = new Contacto(contadorId++, nombre, apellido, telefono, email, direccion, categoria);
        contactos.Add(nuevoContacto);
        ActualizarEstadisticas(categoria, 1);
        return true;
    }

    public List<Contacto> BuscarPorNombre(string nombre)
    {
        List<Contacto> resultados = new List<Contacto>();
        foreach (var contacto in contactos)
        {
            if (contacto.Nombre.ToLower().Contains(nombre.ToLower()) || 
                contacto.Apellido.ToLower().Contains(nombre.ToLower()))
            {
                resultados.Add(contacto);
            }
        }
        return resultados;
    }

    public Contacto BuscarPorTelefono(string telefono)
    {
        foreach (var contacto in contactos)
        {
            if (contacto.Telefono == telefono)
                return contacto;
        }
        return null;
    }

    public List<Contacto> BuscarPorCategoria(string categoria)
    {
        List<Contacto> resultados = new List<Contacto>();
        foreach (var contacto in contactos)
        {
            if (contacto.Categoria == categoria)
                resultados.Add(contacto);
        }
        return resultados;
    }

    public bool ModificarContacto(string telefono, string nuevoNombre, string nuevoApellido, string nuevoEmail, string nuevaDireccion, string nuevaCategoria)
    {
        for (int i = 0; i < contactos.Count; i++)
        {
            if (contactos[i].Telefono == telefono)
            {
                var contacto = contactos[i];
                string categoriaAnterior = contacto.Categoria;

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
                    contacto.Categoria = nuevaCategoria;
                    ActualizarEstadisticas(categoriaAnterior, -1);
                    ActualizarEstadisticas(nuevaCategoria, 1);
                }

                return true;
            }
        }
        return false;
    }

    public bool EliminarContacto(string telefono)
    {
        for (int i = 0; i < contactos.Count; i++)
        {
            if (contactos[i].Telefono == telefono)
            {
                ActualizarEstadisticas(contactos[i].Categoria, -1);
                contactos.RemoveAt(i);
                return true;
            }
        }
        return false;
    }

    // Métodos de consulta
    public void MostrarTodosLosContactos()
    {
        if (contactos.Count == 0)
        {
            Console.WriteLine("La agenda está vacía.");
            return;
        }

        Console.WriteLine($"\n=== AGENDA TELEFÓNICA ({contactos.Count} contactos) ===");
        foreach (var contacto in contactos.OrderBy(c => c.Apellido))
        {
            contacto.MostrarInformacion();
            Console.WriteLine(new string('-', 50));
        }
    }

    public void MostrarEstadisticas()
    {
        Console.WriteLine("\n=== ESTADÍSTICAS DE LA AGENDA ===");
        Console.WriteLine($"Total de contactos: {contactos.Count}");
        Console.WriteLine("\nContactos por categoría:");
        
        for (int i = 0; i < categorias.Length; i++)
        {
            Console.WriteLine($"{categorias[i]}: {estadisticas[i, 1]} contactos");
        }

        if (contactos.Count > 0)
        {
            var ultimoContacto = contactos.OrderByDescending(c => c.FechaRegistro).First();
            Console.WriteLine($"\nÚltimo contacto agregado: {ultimoContacto.NombreCompleto()}");
        }
    }

    public string[] ObtenerCategorias()
    {
        return categorias;
    }

    public int TotalContactos()
    {
        return contactos.Count;
    }

    public void CargarDatosPrueba()
    {
        AgregarContacto("Juan", "Pérez", "0987654321", "juan.perez@hotmail.com", "Av. Principal 123", "Trabajo");
        AgregarContacto("María", "González", "0912345678", "maria.gonzalez@outlook.com", "Calle Secundaria 456", "Familia");
        AgregarContacto("Carlos", "Rodríguez", "0923456789", "carlos.rodriguez@gmail.com", "Barrio Centro 789", "Amigos");
        AgregarContacto("Ana", "Quishpe", "0934567890", "ana.quishpe@gmail.com", "Urbanización Norte 321", "Servicios");
        AgregarContacto("Pedro", "Martínez", "0945678901", "pedro.martinez@live.com", "Sector Sur 654", "Otros");
    }
}