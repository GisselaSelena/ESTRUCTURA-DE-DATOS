class Program
{
    static void Main(string[] args)
    {
        GestorAsignaturas gestor = new GestorAsignaturas();
        
        // 1. Cargar las asignaturas básicas
        gestor.CargarAsignaturasBasicas();
        
        // 2. Solicitar las notas al usuario
        gestor.SolicitarNotas();
        
        // 3. Eliminar las asignaturas aprobadas
        gestor.EliminarAprobadas();
        
        // 4. Mostrar las asignaturas pendientes
        gestor.MostrarPendientes();
    }
}