using System;
using System.Linq;

namespace RegistroBiblioteca
{
    // Clase que representa un libro con sus propiedades y métodos básicos
    public class Libro
    {
        // Propiedades públicas con acceso para lectura y escritura, excepto ISBN que es solo lectura externa
        public string Titulo { get; set; }
        public string Autor  { get; set; }
        public string ISBN   { get; private set; } // ISBN es inmutable desde fuera de la clase
        public int Anio      { get; set; }
        public bool Prestado { get; set; }

        // Constructor que inicializa el libro, normalizando y limpiando datos
        public Libro(string titulo, string autor, string isbn, int anio)
        {
            Titulo   = (titulo ?? "").Trim(); // Evita null y elimina espacios
            Autor    = (autor ?? "").Trim();
            ISBN     = NormalizarISBN(isbn); // Normaliza el ISBN (solo dígitos)
            Anio     = anio;
            Prestado = false; // Por defecto, el libro no está prestado
        }

        // Método estático que elimina todo lo que no sea dígito del ISBN
        // Útil para comparar ISBN-10 y ISBN-13 sin guiones ni espacios
        public static string NormalizarISBN(string? isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn)) return "";
            return new string(isbn.Where(char.IsDigit).ToArray());
        }

        // Sobrescribe ToString para mostrar información legible del libro
        public override string ToString()
        {
            string prest = Prestado ? "Sí" : "No";
            return $"Título: {Titulo}, Autor: {Autor}, ISBN: {ISBN}, Año: {Anio}, Prestado: {prest}";
        }
    }
}
