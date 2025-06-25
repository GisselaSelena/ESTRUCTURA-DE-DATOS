public class GestorAsignaturas
{
    private List<Asignatura> asignaturas;

    public GestorAsignaturas()
    {
        asignaturas = new List<Asignatura>();
    }

    // Método para cargar las asignaturas iniciales
    public void CargarAsignaturasBasicas()
    {
        asignaturas.Add(new Asignatura("Matemáticas"));
        asignaturas.Add(new Asignatura("Física"));
        asignaturas.Add(new Asignatura("Química"));
        asignaturas.Add(new Asignatura("Historia"));
        asignaturas.Add(new Asignatura("Lengua"));
    }

    // Método para solicitar las notas al usuario
    public void SolicitarNotas()
    {
        Console.WriteLine("Ingrese las notas obtenidas en cada asignatura:");
        
        foreach (var asignatura in asignaturas)
        {
            Console.Write($"Nota en {asignatura.Nombre}: ");
            string input = Console.ReadLine();
            
            if (double.TryParse(input, out double nota))
            {
                asignatura.Nota = nota;
            }
            else
            {
                Console.WriteLine("¡Valor inválido! Se asignará 0.");
                asignatura.Nota = 0.0;
            }
        }
    }

    // Método para eliminar las asignaturas aprobadas
    public void EliminarAprobadas()
    {
        asignaturas.RemoveAll(a => a.EstaAprobada());
    }

    // Método para mostrar las asignaturas pendientes
    public void MostrarPendientes()
    {
        if (asignaturas.Count == 0)
        {
            Console.WriteLine("¡Felicidades! No tienes asignaturas pendientes.");
            return;
        }

        Console.WriteLine("\nAsignaturas que debes repetir:");
        Console.WriteLine("---------------------------");
        
        foreach (var asignatura in asignaturas)
        {
            Console.WriteLine($"- {asignatura}");
        }
    }
}