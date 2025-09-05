using System.Collections.Generic;

namespace RegistroBiblioteca
{
    // Comparador personalizado para comparar libros por ISBN normalizado
    // Se usa para evitar duplicados en colecciones como HashSet
    public class ComparadorLibro : IEqualityComparer<Libro>
    {
        // Compara dos libros por su ISBN normalizado
        public bool Equals(Libro? x, Libro? y)
        {
            if (ReferenceEquals(x, y)) return true; // Mismo objeto o ambos null
            if (x is null || y is null) return false; // Uno es null y otro no
            return Libro.NormalizarISBN(x.ISBN) == Libro.NormalizarISBN(y.ISBN);
        }

        // Genera código hash basado en el ISBN normalizado
        public int GetHashCode(Libro obj)
        {
            var key = Libro.NormalizarISBN(obj?.ISBN ?? "");
            return key.GetHashCode();
        }
    }
}


