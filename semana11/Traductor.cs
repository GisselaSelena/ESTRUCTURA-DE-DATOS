using System.Text;
using System.Text.RegularExpressions;

namespace semana11
{
    /// <summary>
    /// Clase Traductor: utiliza un objeto Diccionario
    /// para traducir frases completas palabra por palabra.
    /// </summary>
    public class Traductor
    {
        private readonly Diccionario diccionario;

        /// <summary>
        /// Recibe un diccionario en el constructor.
        /// </summary>
        public Traductor(Diccionario dic)
        {
            diccionario = dic;
        }

        /// <summary>
        /// Traduce una frase completa.
        /// Solo reemplaza las palabras que existen en el diccionario.
        /// Respeta puntuación y espacios.
        /// </summary>
        public string TraducirFrase(string frase)
        {
            if (string.IsNullOrWhiteSpace(frase))
                return frase;

            // Separamos palabras y signos preservando acentos
            var tokens = Regex.Split(frase, @"(?<=\P{L})|(?=\P{L})");
            var sb = new StringBuilder();

            foreach (var t in tokens)
            {
                // Si es palabra (letras), intentamos traducir
                if (Regex.IsMatch(t, @"^\p{L}+$"))
                {
                    var tr = diccionario.TraducirPalabra(t);
                    sb.Append(tr ?? t);
                }
                else
                {
                    // Si es espacio, número o puntuación, se mantiene igual
                    sb.Append(t);
                }
            }

            return sb.ToString();
        }
    }
}
