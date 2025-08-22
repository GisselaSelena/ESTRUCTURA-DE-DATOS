// Clase que representa a un ciudadano dentro del programa de vacunación
public class Ciudadano
{
    // Identificador único del ciudadano
    public int Id { get; }

    // Nombre del ciudadano (ejemplo: "Ciudadano 1")
    public string Nombre { get; }

    // Banderas para reflejar si fue vacunado con Pfizer o AstraZeneca
    public bool VacunadoConPfizer { get; private set; }
    public bool VacunadoConAstraZeneca { get; private set; }

    // Constructor que recibe el ID y nombre
    public Ciudadano(int id, string nombre)
    {
        Id = id;
        Nombre = nombre;
    }

    // Marca al ciudadano como vacunado con Pfizer
    public void MarcarPfizer() => VacunadoConPfizer = true;

    // Marca al ciudadano como vacunado con AstraZeneca
    public void MarcarAstraZeneca() => VacunadoConAstraZeneca = true;

    // Retorna true si recibió ambas vacunas (Pfizer y AstraZeneca)
    public bool AmbasDosisAmbasMarcas() => VacunadoConPfizer && VacunadoConAstraZeneca;

    // Representación en texto del ciudadano (solo su nombre)
    public override string ToString() => Nombre;
}


