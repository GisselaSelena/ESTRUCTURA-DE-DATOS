// Programa principal
class Program
{
    static void Main(string[] args)
    {
        // Crear un nuevo curso
        Curso curso = new Curso();

        // Agregar asignaturas al curso
        curso.AgregarAsignatura(new Asignatura("Matemáticas"));
        curso.AgregarAsignatura(new Asignatura("Física"));
        curso.AgregarAsignatura(new Asignatura("Química"));
        curso.AgregarAsignatura(new Asignatura("Historia"));
        curso.AgregarAsignatura(new Asignatura("Lengua"));

        // Mostrar las asignaturas
        curso.MostrarAsignaturas();
    }
}