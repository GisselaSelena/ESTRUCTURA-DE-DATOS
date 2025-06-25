// Clase que representa un Curso con asignaturas
public class Curso
{
    // Lista de asignaturas (composición)
    public List<Asignatura> Asignaturas { get; } = new List<Asignatura>();

    // Método para agregar una asignatura
    public void AgregarAsignatura(Asignatura asignatura)
    {
        Asignaturas.Add(asignatura);
    }

    // Método para mostrar todas las asignaturas
    public void MostrarAsignaturas()
    {
        Console.WriteLine("Asignaturas del curso:");
        Console.WriteLine("---------------------");
        
        foreach (var asignatura in Asignaturas)
        {
            Console.WriteLine($"- {asignatura}");
        }
    }
}