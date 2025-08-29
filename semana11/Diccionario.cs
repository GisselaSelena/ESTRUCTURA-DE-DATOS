using System;
using System.Collections.Generic;

namespace semana11
{
    /// <summary>
    /// Clase Diccionario: almacena pares de palabras en español e inglés,
    /// permitiendo traducir en ambos sentidos (ES->EN y EN->ES).
    /// </summary>
    public class Diccionario
    {
        // Diccionario Español → Inglés
        private readonly Dictionary<string, string> espToEng =
            new(StringComparer.OrdinalIgnoreCase);

        // Diccionario Inglés → Español
        private readonly Dictionary<string, string> engToEsp =
            new(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Constructor: inicializa el diccionario con al menos 10 palabras base.
        /// </summary>
        public Diccionario()
        {
            // Palabras sugeridas en el enunciado
            AgregarPalabra("tiempo", "time");
            AgregarPalabra("persona", "person");
            AgregarPalabra("año", "year");
            AgregarPalabra("camino", "way");
            AgregarPalabra("forma", "way");   // sinónimo
            AgregarPalabra("día", "day");
            AgregarPalabra("cosa", "thing");
            AgregarPalabra("hombre", "man");
            AgregarPalabra("mundo", "world");
            AgregarPalabra("vida", "life");
            AgregarPalabra("mano", "hand");
            AgregarPalabra("parte", "part");
            AgregarPalabra("niño", "child");
            AgregarPalabra("niña", "child");
            AgregarPalabra("ojo", "eye");
            AgregarPalabra("mujer", "woman");
            AgregarPalabra("lugar", "place");
            AgregarPalabra("trabajo", "work");
            AgregarPalabra("semana", "week");
            AgregarPalabra("caso", "case");
            AgregarPalabra("punto", "point");
            AgregarPalabra("tema", "point");
            AgregarPalabra("gobierno", "government");
            AgregarPalabra("empresa", "company");
            AgregarPalabra("compañía", "company");
        }

        /// <summary>
        /// Agrega una nueva palabra al diccionario en ambos sentidos.
        /// Devuelve false si ya existía en español.
        /// </summary>
        public bool AgregarPalabra(string esp, string eng)
        {
            if (string.IsNullOrWhiteSpace(esp) || string.IsNullOrWhiteSpace(eng))
                return false;

            esp = esp.Trim();
            eng = eng.Trim();

            if (espToEng.ContainsKey(esp))
                return false; // ya existe en español

            espToEng[esp] = eng;
            engToEsp[eng] = esp;
            return true;
        }

        /// <summary>
        /// Traduce una palabra en cualquier dirección.
        /// Devuelve null si no existe en el diccionario.
        /// </summary>
        public string? TraducirPalabra(string palabra)
        {
            if (string.IsNullOrWhiteSpace(palabra))
                return null;

            var key = palabra;

            // Español → Inglés
            if (espToEng.TryGetValue(key, out var en))
                return AjustarCapitalizacion(palabra, en);

            // Inglés → Español
            if (engToEsp.TryGetValue(key, out var es))
                return AjustarCapitalizacion(palabra, es);

            // Caso especial: plural en inglés (ej: "eyes" → "eye")
            if (key.EndsWith("s", StringComparison.OrdinalIgnoreCase))
            {
                var singular = key[..^1];
                if (engToEsp.TryGetValue(singular, out var esSing))
                    return AjustarCapitalizacion(palabra, esSing);
            }

            return null; // palabra no encontrada
        }

        /// <summary>
        /// Conserva la capitalización original al traducir.
        /// </summary>
        private static string AjustarCapitalizacion(string original, string traduccion)
        {
            return char.IsUpper(original[0])
                ? char.ToUpper(traduccion[0]) + traduccion.Substring(1)
                : traduccion.ToLower();
        }
    }
}

