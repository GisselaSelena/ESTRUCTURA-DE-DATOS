using System;

namespace RegistroEstudiantes
{
    // Clase que representa un estudiante
    public class Estudiante
    {
        public int Id { get; set; } // Identificador único del estudiante
        public string Nombres { get; set; } // Nombres del estudiante
        public string Apellidos { get; set; } // Apellidos del estudiante
        public string Direccion { get; set; } // Dirección del estudiante
        public string[] Telefonos { get; set; } // Array para almacenar los teléfonos

        // Constructor de la clase Estudiante
        public Estudiante(int id, string nombres, string apellidos, string direccion, string[] telefonos)
        {
            Id = id;
            Nombres = nombres;
            Apellidos = apellidos;
            Direccion = direccion;
            Telefonos = telefonos;
        }

        // Método para mostrar la información del estudiante
        public void MostrarInformacion()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nombres: {Nombres}");
            Console.WriteLine($"Apellidos: {Apellidos}");
            Console.WriteLine($"Dirección: {Direccion}");
            Console.WriteLine("Teléfonos: ");
            foreach (var telefono in Telefonos)
            {
                Console.WriteLine($"- {telefono}");
            }
            Console.WriteLine(new string('-', 40));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Crear un array para almacenar tres estudiantes
            Estudiante[] estudiantes = new Estudiante[3];

            // Inicializar los estudiantes con datos de ejemplo usando arrays de teléfonos
            estudiantes[0] = new Estudiante(
                1,
                "Jean Pool",
                "Quishpe Mendoza",
                "Calle S29B",
                new string[] { "123-456-7890", "098-765-4321", "555-555-5555" });

            estudiantes[1] = new Estudiante(
                2,
                "Flor Marina",
                "Cuenca Leon",
                "Avenida Totoracocha 27",
                new string[] { "111-222-3333", "444-555-6666", "777-888-9999" });

            estudiantes[2] = new Estudiante(
                3,
                "Victor Hugo",
                "Mena Mendoza",
                "Calle S29C",
                new string[] { "999-888-7777", "666-555-4444", "333-222-1111" });

            // Mostrar la información de cada estudiante
            for (int i = 0; i < estudiantes.Length; i++)
            {
                Console.WriteLine($"Información del estudiante {i + 1}:");
                estudiantes[i].MostrarInformacion();
            }
        }
    }
}
