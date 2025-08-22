// Clase principal que arranca el programa
class Program
{
    static void Main()
    {
        // Instanciamos el programa de vacunación
        var programa = new ProgramaVacunacion();

        // Generamos los datos ficticios:
        // - 500 ciudadanos
        // - 75 Pfizer
        // - 75 AstraZeneca
        // - Semilla fija para reproducibilidad
        programa.GenerarDatosFicticios(
            totalCiudadanos: 500,
            vacunadosPfizer: 75,
            vacunadosAstra: 75,
            seed: 20250822
        );

        // Mostramos los resultados en consola
        programa.MostrarResultados();
    }
}
