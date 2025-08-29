using System;
using System.Collections.Generic;

namespace semana11
{
    // Diccionario bilingüe ES <-> EN
    public class Diccionario
    {
        // ES -> EN y EN -> ES (ambos sentidos)
        private readonly Dictionary<string, string> espToEng =
            new(StringComparer.OrdinalIgnoreCase);

        private readonly Dictionary<string, string> engToEsp =
            new(StringComparer.OrdinalIgnoreCase);

        public Diccionario()
        {
            // Palabras base sugeridas
            AgregarPalabra("tiempo", "time");
            AgregarPalabra("persona", "person");
            AgregarPalabra("año", "year");
            AgregarPalabra("camino", "way");
            AgregarPalabra("forma", "way");      // sinónimo útil
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

        // Agrega en ambos sentidos (ES->EN y EN->ES). Devuelve false si ya existía la clave ES.
        public bool AgregarPalabra(string esp, string eng)
        {
            if (string.IsNullOrWhiteSpace(esp) || string.IsNullOrWhiteSpace(eng))
                return false;

            esp = esp.Trim();
            eng = eng.Trim();

            // Evita duplicados en ES
            if (espToEng.ContainsKey(esp))
                return false;

            espToEng[esp] = eng;
            engToEsp[eng] = esp;
            return true;
        }

        // Traduce palabra en cualquiera de los dos sentidos. Devuelve null si no existe.
        public string? TraducirPalabra(string palabra)
        {
            if (string.IsNullOrWhiteSpace(palabra))
                return null;

            // Buscamos ignorando mayúsculas/minúsculas
            var key = palabra;

            if (espToEng.TryGetValue(key, out var en))
                return AjustarCapitalizacion(palabra, en);

            if (engToEsp.TryGetValue(key, out var es))
                return AjustarCapitalizacion(palabra, es);

            // Intento plural simple en inglés (eyes -> eye, hands -> hand)
            if (key.EndsWith("s", StringComparison.OrdinalIgnoreCase))
            {
                var singular = key[..^1];
                if (engToEsp.TryGetValue(singular, out var esSing))
                    return AjustarCapitalizacion(palabra, esSing);
            }

            return null;
        }

        private static string AjustarCapitalizacion(string original, string traduccion)
        {
            // Si la primera letra de la original es mayúscula, capitalizamos la traducción
            return char.IsUpper(original[0])
                ? char.ToUpper(traduccion[0]) + traduccion.Substring(1)
                : traduccion.ToLower();
        }
    }
}

