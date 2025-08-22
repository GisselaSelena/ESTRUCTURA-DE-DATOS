using System;
using System.Collections.Generic;
using System.Linq;

// Clase que maneja todo el programa de vacunación
public class ProgramaVacunacion
{
    // Lista completa de ciudadanos (500 en total)
    private readonly List<Ciudadano> _ciudadanos = new();

    // Conjuntos para representar los vacunados con Pfizer y AstraZeneca
    // -> Usamos HashSet para aplicar operaciones de teoría de conjuntos
    private readonly HashSet<int> _pfizer = new();
    private readonly HashSet<int> _astrazeneca = new();

    // Permite consultar la lista de ciudadanos (solo lectura)
    public IReadOnlyList<Ciudadano> Ciudadanos => _ciudadanos;

    // Método que genera los datos ficticios de prueba
    public void GenerarDatosFicticios(
        int totalCiudadanos = 500,
        int vacunadosPfizer = 75,
        int vacunadosAstra = 75,
        int seed = 12345) // semilla para reproducibilidad
    {
        _ciudadanos.Clear();
        _pfizer.Clear();
        _astrazeneca.Clear();

        // 1) Generar 500 ciudadanos ficticios
        for (int i = 1; i <= totalCiudadanos; i++)
            _ciudadanos.Add(new Ciudadano(i, $"Ciudadano {i}"));

        // 2) Selección de 75 IDs para Pfizer usando un Random
        var rnd = new Random(seed);

        var universo = Enumerable.Range(1, totalCiudadanos).ToList();
        Barajar(universo, rnd);
        foreach (var id in universo.Take(vacunadosPfizer)) _pfizer.Add(id);

        // 3) Selección de 75 IDs para AstraZeneca (puede haber intersección)
        var universo2 = Enumerable.Range(1, totalCiudadanos).ToList();
        Barajar(universo2, rnd);
        foreach (var id in universo2.Take(vacunadosAstra)) _astrazeneca.Add(id);

        // 4) Actualizar banderas POO de cada ciudadano en función de los conjuntos
        foreach (var c in _ciudadanos)
        {
            if (_pfizer.Contains(c.Id)) c.MarcarPfizer();
            if (_astrazeneca.Contains(c.Id)) c.MarcarAstraZeneca();
        }
    }

    // Método auxiliar para barajar listas (Fisher-Yates)
    private static void Barajar(List<int> lista, Random rnd)
    {
        for (int i = lista.Count - 1; i > 0; i--)
        {
            int j = rnd.Next(i + 1);
            (lista[i], lista[j]) = (lista[j], lista[i]);
        }
    }

    // -------- Operaciones de teoría de conjuntos --------

    // No vacunados = Universo U \ (Pfizer ∪ AstraZeneca)
    public IEnumerable<Ciudadano> ObtenerNoVacunados()
    {
        var union = new HashSet<int>(_pfizer);
        union.UnionWith(_astrazeneca); // Unión
        return _ciudadanos.Where(c => !union.Contains(c.Id)).OrderBy(c => c.Id);
    }

    // Ambas dosis (ambas marcas) = Pfizer ∩ AstraZeneca
    public IEnumerable<Ciudadano> ObtenerAmbasDosis()
    {
        var inter = new HashSet<int>(_pfizer);
        inter.IntersectWith(_astrazeneca); // Intersección
        return FiltrarPorIds(inter);
    }

    // Solo Pfizer = Pfizer \ AstraZeneca
    public IEnumerable<Ciudadano> ObtenerSoloPfizer()
    {
        var solo = new HashSet<int>(_pfizer);
        solo.ExceptWith(_astrazeneca); // Diferencia
        return FiltrarPorIds(solo);
    }

    // Solo AstraZeneca = AstraZeneca \ Pfizer
    public IEnumerable<Ciudadano> ObtenerSoloAstraZeneca()
    {
        var solo = new HashSet<int>(_astrazeneca);
        solo.ExceptWith(_pfizer); // Diferencia
        return FiltrarPorIds(solo);
    }

    // Método auxiliar para convertir un conjunto de IDs a objetos Ciudadano
    private IEnumerable<Ciudadano> FiltrarPorIds(HashSet<int> ids) =>
        _ciudadanos.Where(c => ids.Contains(c.Id)).OrderBy(c => c.Id);

    // -------- Presentación en consola --------
    public void MostrarResultados(int verPrimeros = 10)
    {
        // Explicación teórica
        Console.WriteLine("Definición: Un conjunto es una colección de elementos únicos sin orden específico.");
        Console.WriteLine("En C#, los conjuntos se implementan con HashSet<T>.\n");

        // Obtener cada listado
        var noVac = ObtenerNoVacunados().ToList();
        var ambas = ObtenerAmbasDosis().ToList();
        var pfOnly = ObtenerSoloPfizer().ToList();
        var azOnly = ObtenerSoloAstraZeneca().ToList();

        // Mostrar resumen
        Console.WriteLine("=== Resumen de Vacunación (datos ficticios) ===");
        Console.WriteLine($"Total de ciudadanos:                 {_ciudadanos.Count}");
        Console.WriteLine($"Vacunados con Pfizer (set):          {_pfizer.Count}");
        Console.WriteLine($"Vacunados con AstraZeneca (set):     {_astrazeneca.Count}");
        Console.WriteLine($"Intersección (ambas marcas):         {ambas.Count}\n");

        // Imprimir los primeros resultados de cada conjunto
        Imprimir("1) No vacunados", noVac, verPrimeros);
        Imprimir("2) Con ambas dosis (ambas marcas)", ambas, verPrimeros);
        Imprimir("3) Solo Pfizer", pfOnly, verPrimeros);
        Imprimir("4) Solo AstraZeneca", azOnly, verPrimeros);
    }

    // Imprime una lista con un límite de elementos visibles
    private static void Imprimir(string titulo, IList<Ciudadano> lista, int verPrimeros)
    {
        Console.WriteLine($"{titulo}: {lista.Count}");
        foreach (var c in lista.Take(verPrimeros))
            Console.WriteLine($"   - {c}");
        if (lista.Count > verPrimeros)
            Console.WriteLine($"   ... (+{lista.Count - verPrimeros} más)\n");
        else
            Console.WriteLine();
    }
}
