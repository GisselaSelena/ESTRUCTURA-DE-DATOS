   using System.Text;
using System.Text.RegularExpressions;

namespace semana11
{
    public class Traductor
    {
        private readonly Diccionario diccionario;

        public Traductor(Diccionario dic)
        {
            diccionario = dic;
        }

        // Traduce frase palabra por palabra; solo reemplaza las que existan en el diccionario
        public string TraducirFrase(string frase)
        {
            if (string.IsNullOrWhiteSpace(frase))
                return frase;

            // Mejor tokenización con Unicode: \p{L} = letras (incluye á, é, í, ó, ú, ñ)
            // Separa en "palabras" y "no letras" (espacios, comas, puntos, etc.)
            var tokens = Regex.Split(frase, @"(?<=\P{L})|(?=\P{L})");

            var sb = new StringBuilder();

            foreach (var t in tokens)
            {
                if (Regex.IsMatch(t, @"^\p{L}+$"))   // solo letras
                {
                    var tr = diccionario.TraducirPalabra(t);
                    sb.Append(tr ?? t);
                }
                else
                {
                    sb.Append(t); // puntuación, espacios, números, etc.
                }
            }

            return sb.ToString();
        }
    }
}
